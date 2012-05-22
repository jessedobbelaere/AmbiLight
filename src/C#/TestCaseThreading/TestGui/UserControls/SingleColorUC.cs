using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestGui.UserControls {
    public partial class SingleColorUC : ArduinoUC {
        private ColorDialog colorDialog;

        public SingleColorUC() {
            InitializeComponent();
            this.Bytes = new byte[] { 0, 0, 0 };

            colorDialog = new ColorDialog();
        }

        /// <summary>
        /// Choose a color
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonChooseColor_Click(object sender, EventArgs e) {
            DialogResult result = colorDialog.ShowDialog();
            
            if (result == DialogResult.OK) {
                this.panelColor.BackColor = colorDialog.Color;

                byte rood = colorDialog.Color.R;
                byte groen = colorDialog.Color.G;
                byte blauw = colorDialog.Color.B;

                this.Bytes = new byte[]{rood,groen,blauw};
            }
        }

    }
}
