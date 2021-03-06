﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trigger.Types;
using Hooks.Mouse;

namespace Triggers.Types
{
    public class MouseDownTrigger : BaseMouseTrigger
    {
        public override string TypeName { get { return "Кнопка мыши нажата"; } }

        public MouseDownTrigger()
        {
            MouseHook.MouseDown += MouseDown;
        }

        private void MouseDown(object sender, MouseEventArgs e)
        {
            Invoke(e);
        }

        public override void Dispose()
        {
            MouseHook.MouseDown -= MouseDown;
            GC.SuppressFinalize(this);
        }
    }
}
