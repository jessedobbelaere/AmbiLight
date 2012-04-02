using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace TestCaseThreading.ColorSources {
    abstract class ColorSource {
        private SerialCom serial;
        private Size size;

        public ColorSource() { }

        public ColorSource(SerialCom s) {
            this.serial = s;
            size = Screen.PrimaryScreen.Bounds.Size;
        }

        virtual public void Start() {

        }
        virtual public void Stop() {
        }
        virtual public void Output(byte channel, byte r, byte g, byte b) {
        }
    }
}
