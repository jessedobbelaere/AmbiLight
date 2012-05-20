using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestGui.UserControls {
    public partial class SingleRegioUC : UserControl {
        public int x;
        public int y;
        public int width;
        public int height;
        
        public SingleRegioUC(int label) {
            InitializeComponent();
            this.labelTitle.Text = "Ledstrip " + label;
        }

        /// <summary>
        /// Nieuwe selectie maken
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRegion1_Click(object sender, EventArgs e) {
            NewRegion ee = new NewRegion(AddNewSection);
            ee.Show();
        }

        /// <summary>
        /// Toevoegen van nieuwe selectie
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        private void AddNewSection(int x, int y, int width, int height) {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;

            UpdateTextBoxes();
        }

        /// <summary>
        /// Updaten van de textboxes
        /// </summary>
        private void UpdateTextBoxes() {
            textBox1x.Text = "" + x;
            textBox1y.Text = "" + y;
            textBox2x.Text = "" + width;
            textBox2y.Text = "" + height;
        }

    }
}
