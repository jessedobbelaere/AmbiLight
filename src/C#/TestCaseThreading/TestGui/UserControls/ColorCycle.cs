using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestGui.UserControls {
    public partial class ColorCycleUC : ArduinoUC {
        public ColorCycleUC() {
            InitializeComponent();
        }

        private void SetSpeed(object sender, EventArgs e) {
            this.Options = (byte) this.trackBarSpeed.Value;
            System.Diagnostics.Debug.Print(this.trackBarSpeed.Value.ToString());
        }
    }
}
