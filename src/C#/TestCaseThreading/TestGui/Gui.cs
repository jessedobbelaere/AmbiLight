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
        private UpdateLogDelegate deleg;

        /// <summary>
        /// Constructor
        /// </summary>
        public Gui() {
            InitializeComponent();

            Opvullen(comboBoxSource, typeof(Source));

            deleg = new UpdateLogDelegate(addToLog);
            deleg("Application started");
        }

        /// <summary>
        /// Add text to the logscreen
        /// </summary>
        /// <param name="s">String with textinfo</param>
        private void addToLog(string s) {

            if (textBoxLog.InvokeRequired) {
                textBoxLog.BeginInvoke(new Action(delegate {
                    addToLog(s);
                }));
                return; 
            }


            String text = "(" + DateTime.Now + ") " + s + Environment.NewLine;
            this.textBoxLog.Text += text;
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
                deleg("Started the color cycle");
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
                deleg("Started the Stroboscope"); 
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
                bl = new BL(connectsettings.ComPort, deleg);
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

        
        /// <summary>
        /// Start the server
        /// </summary>
        /// <param name="sender">Object that raised the event</param>
        /// <param name="e">Event arguments</param>
        private void startToolStripMenuItem_Click_1(object sender, EventArgs e) {
            if (bl != null) {
                bl.StartServer(); 
            }
        }

        /// <summary>
        /// Stop the server
        /// </summary>
        /// <param name="sender">Object that raised the event</param>
        /// <param name="e">Event arguments</param>
        private void stopToolStripMenuItem_Click(object sender, EventArgs e) {
            if (bl != null) {
                bl.StopServer();
            }
        }




    }
}
