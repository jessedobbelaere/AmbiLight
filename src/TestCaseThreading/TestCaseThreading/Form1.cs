using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestCaseThreading {
    public partial class Form1 : Form {
        private BL bl;

        public Form1() {
            InitializeComponent();

            Opvullen(comboBoxSource, typeof(Source));
            addToLog("Application started.");            
        }

        private void button1_Click(object sender, EventArgs e) {
            bl = new BL(textBoxCom.Text);
            bl.SetColorSource((Source)Enum.Parse(typeof(Source), this.comboBoxSource.SelectedItem.ToString()));

            bl.Start();
            
        }

        private void button2_Click(object sender, EventArgs e) {
            bl.Stop();
        }

        private void addToLog(string s) {
            this.textBoxLog.Text += s +"\n";
        }

        /// <summary>
        /// Vult een combobox met meegegeven items
        /// </summary>
        /// <param name="cb">Op te vullen ComboBox</param>
        /// <param name="enumeratieType">type enum</param>
        private void Opvullen(ComboBox cb, Type enumeratieType) {
            foreach (string name in Enum.GetNames(enumeratieType)) {
                if (name != "NN") {
                    cb.Items.Add(name);
                }
            }
            cb.SelectedIndex = 0;
        }

        private void button3_Click(object sender, EventArgs e) {
            bl.StartMode();
        }


    }
}
