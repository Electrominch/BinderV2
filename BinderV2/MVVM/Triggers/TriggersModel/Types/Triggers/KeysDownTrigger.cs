﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Hooks.Keyboard;

using System.Threading;
using System.Windows.Forms;

namespace Trigger.Types
{
    public class KeysDownTrigger : BaseTrigger
    {
        private HashSet<Key> keys;
        public HashSet<Key> Keys 
        { 
            get { return keys; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));
                keys = value;
            }
        }

        public KeysDownTrigger(string name, ICollection<Key> keys) : base(name)
        {
            Keys = new HashSet<Key>();
            if (keys == null)
                throw new ArgumentNullException(nameof(keys));
            foreach (Key k in keys)
            {
                this.Keys.Add(k);
            }
            AllKeyDownTriggers.Add(this);
        }

        public KeysDownTrigger() : this("Новый триггер", new HashSet<Key>())
        {}

        private void InvokeIfHaveNeedKeys(HashSet<Key> pressedKeys)
        {
            if (HaveNeedKeys(pressedKeys))
                Invoke();
        }

        private bool HaveNeedKeys(HashSet<Key> pressedKeys)
        {
            if (Keys.Count == 0)//если у нас не настроены кнопки, чтобы не срабатывало
                return false;
            foreach (Key k in Keys)
                if (!pressedKeys.Contains(k))
                    return false;
            return true;
        }

        public override void Dispose()
        {
            AllKeyDownTriggers.Remove(this);
            GC.SuppressFinalize(this);
        }

        ~KeysDownTrigger()
        {
            AllKeyDownTriggers.Remove(this);
        }

        private static HashSet<KeysDownTrigger> AllKeyDownTriggers = new HashSet<KeysDownTrigger>();
        private static HashSet<Key> pressedKeys = new HashSet<Key>();
        static KeysDownTrigger()
        {
            KeyboardHook.KeyDown += KeysDown;
            KeyboardHook.KeyUp += KeysUp;
        }

        private static void KeysDown(object sender, KeyEventArgsCustom e)
        {
            if (pressedKeys.Contains(e.Key))
                return;

            pressedKeys.Add(e.Key);
            //проверяем все триггеры
            AllKeyDownTriggers.AsParallel().ForAll(trig =>
            {
                trig.InvokeIfHaveNeedKeys(pressedKeys);//если есть необходимые кнопки - запускаем
            });
            
        }
        private static void KeysUp(object sender, KeyEventArgsCustom e)
        {
            pressedKeys.Remove(e.Key);
        }

        
    }
}