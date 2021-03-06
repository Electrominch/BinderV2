﻿using Hooks.Keyboard;
using Hooks.Mouse;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Drawing;
using Trigger.Types;

namespace BinderV2.MVVM.Models
{
    class RecordModel : INotifyPropertyChanged
    {
        private readonly KeysDownTrigger KeysDownTriggerToRecord = new KeysDownTrigger();
        private readonly Stopwatch stopwatch = new Stopwatch();
        private readonly Queue<string> Commands = new Queue<string>();

        private bool isRecording;
        public bool IsRecording
        {
            get { return isRecording; }
            private set 
            {
                isRecording = value;
                if (isRecording)
                    StartRecording();
                else
                    StopRecording();
                OnPropertyChanged("IsRecording");
            }
        }

        private string enableHotkeyKeys;
        public string RecordHotkeyString 
        {
            get { return enableHotkeyKeys; }
            private set 
            {
                enableHotkeyKeys = value;
                OnPropertyChanged("RecordHotkeyString");
            } 
        }

        private string recordedScript;
        public string RecordedScript 
        { 
            get { return recordedScript; }
            set { recordedScript = value; OnPropertyChanged("RecordedScript"); } 
        }

        public int SelectedKeyboardImitationIndex { get; set; }
        public int SelectedMouseMoveImitationIndex { get; set; }

        private string percentMouseMoveToRecord_string = "100";
        public string PercentMouseMoveToRecord_string
        {
            get { return percentMouseMoveToRecord.ToString(); }
            set
            {
                percentMouseMoveToRecord_string = value;

                if (int.TryParse(percentMouseMoveToRecord_string, out int res))
                {
                    if (res < 0)
                        percentMouseMoveToRecord_string = "0";
                    if (res > 100)
                        percentMouseMoveToRecord_string = "100";
                    percentMouseMoveToRecord = int.Parse(percentMouseMoveToRecord_string);
                }
                else
                {
                    System.Windows.MessageBox.Show("Введите проценты верно.", "Ошибка");
                    PercentMouseMoveToRecord_string = "100";
                    percentMouseMoveToRecord = 100;
                }
                OnPropertyChanged("PercentMouseMoveToRecord_string");
            }
        }
        int percentMouseMoveToRecord = 100;

        public void ClearScript()
        {
            RecordedScript = "";
        }

        public void CopyScriptToClipboard()
        {
            var data = new System.Windows.Forms.DataObject();
            Thread thread;
            data.SetData(System.Windows.Forms.DataFormats.UnicodeText, true, RecordedScript);
            thread = new Thread(() => System.Windows.Forms.Clipboard.SetDataObject(data, true));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
        }

        private void StartRecording()
        {
            if (isRecording == false)
            {
                isRecording = true;
                OnPropertyChanged("IsRecording");
            }

            Commands.Clear();
            lastCursorRecordedPosition = System.Windows.Forms.Cursor.Position;
            AddCommand($"SetCursorPos({lastCursorRecordedPosition.X}, {lastCursorRecordedPosition.Y})");
        }

        private void StopRecording()
        {
            if (isRecording == true)
            {
                isRecording = false;
                OnPropertyChanged("IsRecording");
            }

            stopwatch.Reset();
            while (Commands.Count > 0)
                RecordedScript += Commands.Dequeue();
            OnPropertyChanged("RecordedScript");
        }

        int mouseMoveCount = 0;
        Point lastCursorRecordedPosition;
        private void AddMouseMoveCommand(int absX, int absY)
        {
            switch (SelectedMouseMoveImitationIndex)
            {
                case 0://SetCursorPos
                    {
                        AddCommand($"SetCursorPos({absX}, {absY})");
                        break;
                    }
                case 1://MoveCursor
                    {
                        AddCommand($"MoveCursor({absX}, {absY}, 0)");
                        break;
                    }
                case 2://MoveCursorBy
                    {
                        AddCommand($"MoveCursorBy({absX-lastCursorRecordedPosition.X}, {absY-lastCursorRecordedPosition.Y})");
                        break;
                    }

            }
            lastCursorRecordedPosition = new Point(absX, absY);
        }

        private Task AddCommand(string cmd)
        {
            if (!isRecording)
                return Task.FromResult(0);
            return Task.Run(() =>
            {
                long mcs = stopwatch.ElapsedMilliseconds;
                if (mcs >= 1)
                    Commands.Enqueue($"Delay({mcs});" + Environment.NewLine);
                Commands.Enqueue(cmd + ";" + Environment.NewLine);

                stopwatch.Reset();
                stopwatch.Start();
            });
        }

        #region Hooks
        private void SetHooks()
        {
            KeyboardHook.KeyDown += KeyDown;
            KeyboardHook.KeyUp += KeyUp;
            MouseHook.MouseDown += MouseDown;
            MouseHook.MouseUp += MouseUp;
            MouseHook.MouseMove += MouseMove;
        }


        private void KeyDown(object sender, KeyEventArgsCustom e)
        {
            switch (SelectedKeyboardImitationIndex)
            {
                case 0://Если AHK
                    AddCommand($"AHKKeyDown(\"{Utilities.KeyCodeToUnicode.VKCodeToUnicode((uint)KeyInterop.VirtualKeyFromKey(e.Key))}\")");
                    break;
                case 1:
                    AddCommand(string.Format(@"KeyDown(""{0}"")", e.Key));
                    break;
            }    
            
        }

        private void KeyUp(object sender, KeyEventArgsCustom e)
        {
            switch (SelectedKeyboardImitationIndex)
            {
                case 0://Если AHK
                    AddCommand($"AHKKeyUp(\"{Utilities.KeyCodeToUnicode.VKCodeToUnicode((uint)KeyInterop.VirtualKeyFromKey(e.Key))}\")");
                    break;
                case 1:
                    AddCommand(string.Format(@"KeyUp(""{0}"")", e.Key));
                    break;
            }
        }

        private void MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            AddMouseMoveCommand(e.X, e.Y);
            AddCommand($"MouseEvent(\"{e.Button.ToString().ToUpper() + "DOWN"}\")");
        }

        private void MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            AddMouseMoveCommand(e.X, e.Y);
            AddCommand($"MouseEvent(\"{e.Button.ToString().ToUpper() + "UP"}\")");
        }

        private void MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (stopwatch.ElapsedMilliseconds < 1)
                return;
            if (mouseMoveCount < percentMouseMoveToRecord)
                AddMouseMoveCommand(e.X, e.Y);
            mouseMoveCount++;
            if (mouseMoveCount >= 100)
                mouseMoveCount = 0;
        }
        #endregion


        public RecordModel()
        {
            SetHooks();
            RecordHotkeyString = "<пусто>";
            KeysDownTriggerToRecord.AddCallback((sender, e)=> 
            {
                IsRecording = !IsRecording;
            });
        }

        public void SetNewHotkeys()
        {
            KeysDownTriggerToRecord.Keys.Clear();
            KeysDownTriggerToRecord.EnableTrigger = false;
            RecordHotkeyString = "<нажмите клавиши>";

            KeyEventHandlerCustom keyDown = null;
            keyDown = (s, keyArgs) =>
            {
                KeysDownTriggerToRecord.Keys.Add(keyArgs.Key);
                RecordHotkeyString = string.Join(" + ", KeysDownTriggerToRecord.Keys);
            };

            KeyEventHandlerCustom keyUp = null;
            keyUp = (s, keyArgs) =>
            {
                KeyboardHook.KeyDown -= keyDown;
                KeyboardHook.KeyUp -= keyUp;
                KeysDownTriggerToRecord.EnableTrigger = true;
            };

            KeyboardHook.KeyDown += keyDown;
            KeyboardHook.KeyUp += keyUp;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
