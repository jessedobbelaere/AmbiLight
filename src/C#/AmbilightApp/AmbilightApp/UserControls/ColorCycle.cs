using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestGui.UserControls {
    
    /// <summary>
    /// The Color Cycle usercontrol
    /// </summary>
    public partial class ColorCycleUC : ArduinoUC {
        
        /// <summary>
        /// Default constructor
        /// </summary>
        public ColorCycleUC() {
            InitializeComponent();
        }

        /// <summary>
        /// Set the speed
        /// </summary>
        /// <param name="sender">Object that has sent the event</param>
        /// <param name="e">Event args</param>
        private void SetSpeed(object sender, EventArgs e) {
            this.Options = (byte) this.trackBarSpeed.Value;
            System.Diagnostics.Debug.Print(this.trackBarSpeed.Value.ToString());
        }
    }
}
