using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace TestCaseThreading.ColorSources {
    
    /// <summary>
    /// Color source interface
    /// </summary>
    interface ColorSource {          
        void Start();
        void Stop();
        void Output(byte channel, byte r, byte g, byte b);
    }
}
