using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TestGui;

namespace TestCaseThreading {
    public partial class Gui : Form {
        
        // Variables
        private BL bl;

        /// <summary>
        /// Constructor
        /// </summary>
        public Gui() {
            InitializeComponent();

            Opvullen(comboBoxSource, typeof(Source));
            addToLog("Application started.");            
        }

        /// <summary>
        /// Add text to the logscreen
        /// </summary>
        /// <param name="s">String with textinfo</param>
        private void addToLog(string s) {
            this.textBoxLog.Text += s;
            this.textBoxLog.Text += "\n";
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

        /// <summary>
        /// Start a colorcycle FX
        /// </summary>
        /// <param name="sender">Object that raised the event</param>
        /// <param name="e">Event arguments</param>
        private void buttonColorCycle_Click(object sender, EventArgs e) {
            if (bl != null) {
                bl.StartFx(1);
                addToLog("Started the color cycle");
            }
        }

        /// <summary>
        /// Start a strobelight FX
        /// </summary>
        /// <param name="sender">Object that raised the event</param>
        /// <param name="e">Event arguments</param>
        private void buttonStrobeLight_Click(object sender, EventArgs e) {
            if (bl != null) {
                bl.StartFx(2);
                addToLog("\nStarted the Stroboscope"); 
            }
        }

        /// <summary>
        /// Start a police light FX
        /// </summary>
        /// <param name="sender">Object that raised the event</param>
        /// <param name="e">Event arguments</param>
        private void buttonPoliceLight_Click(object sender, EventArgs e) {
            if (bl != null) {
                bl.StartFx(3);
                addToLog("Started the Police Light"); 
            }
        }

        /// <summary>
        /// Connect to a selected COM Port from the popup.
        /// </summary>
        /// <param name="sender">Object that raised the event</param>
        /// <param name="e">Event arguments</param>
        private void connectToolStripMenuItem_Click(object sender, EventArgs e) {
            ConnectSettings connectsettings = new ConnectSettings();
            connectsettings.ShowDialog();

            if (connectsettings.DialogResult == DialogResult.OK) {
                bl = new BL(connectsettings.ComPort);
                addToLog("Connected to " + connectsettings.ComPort);
            }
        }

        /// <summary>
        /// Disconnect the serial connection (DOESN'T WORK?)
        /// </summary>
        /// <param name="sender">Object that raised the event</param>
        /// <param name="e">Event arguments</param>
        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e) {
            if (bl != null) {
                bl.StopSerial(); 
            }
        }

        /// <summary>
        /// Exit the application
        /// </summary>
        /// <param name="sender">Object that raised the event</param>
        /// <param name="e">Event arguments</param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Environment.Exit(0);
        }

        /// <summary>
        /// Start the screen observation
        /// </summary>
        /// <param name="sender">Object that raised the event</param>
        /// <param name="e">Event arguments</param>
        private void buttonStartScreen_Click(object sender, EventArgs e) {
            if (bl != null) {
                bl.SetColorSource((Source)Enum.Parse(typeof(Source), this.comboBoxSource.SelectedItem.ToString()));
                bl.Start(); 
            }
        }

        /// <summary>
        /// Stop the screen observation
        /// </summary>
        /// <param name="sender">Object that raised the event</param>
        /// <param name="e">Event arguments</param>
        private void buttonStopScreen_Click(object sender, EventArgs e) {
            if (bl != null) {
                bl.Stop(); 
            }
        }




    }
}
