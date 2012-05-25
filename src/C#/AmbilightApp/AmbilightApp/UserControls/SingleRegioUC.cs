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
    /// The single region usercontrol
    /// </summary>
    public partial class SingleRegioUC : UserControl {
        private int x;
        private int y;
        private int width;
        private int height;

        /// <summary>
        /// The X property
        /// </summary>
        public int X {
            get {
                return this.x;
            }
            set {
                this.x = value;
                this.textBox1x.Text = this.x.ToString();
            }
        }

        /// <summary>
        /// The Y property
        /// </summary>
        public int Y {
            get {
                return this.y;
            }
            set {
                this.y = value;
                this.textBox1y.Text = this.y.ToString();
            }
        }

        /// <summary>
        /// The width property
        /// </summary>
        public int Breedte {
            get {
                return this.width;
            }
            set {
                this.width = value;
                this.textBox2x.Text = this.width.ToString();
            }
        }

        /// <summary>
        /// The height property
        /// </summary>
        public int Hoogte {
            get {
                return this.height;
            }
            set {
                this.height = value;
                this.textBox2y.Text = this.height.ToString();
            }
        }

        /// <summary>
        /// Non-default constructor
        /// </summary>
        /// <param name="label">The labelname</param>
        public SingleRegioUC(int label) {
            InitializeComponent();
            this.labelTitle.Text = "Ledstrip " + label;
        }

        /// <summary>
        /// Make new selection
        /// </summary>
        /// <param name="sender">The object that raised the event</param>
        /// <param name="e">Event args</param>
        private void buttonRegion1_Click(object sender, EventArgs e) {
            NewRegion ee = new NewRegion(AddNewSection);
            ee.Show();
        }

        /// <summary>
        /// Adding a new selection
        /// </summary>
        /// <param name="x">The x coordinate</param>
        /// <param name="y">The Y coordinate</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        private void AddNewSection(int x, int y, int width, int height) {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;

            UpdateTextBoxes();
        }

        /// <summary>
        /// Update the textboxes
        /// </summary>
        private void UpdateTextBoxes() {
            textBox1x.Text = "" + x;
            textBox1y.Text = "" + y;
            textBox2x.Text = "" + width;
            textBox2y.Text = "" + height;
        }

    }
}
