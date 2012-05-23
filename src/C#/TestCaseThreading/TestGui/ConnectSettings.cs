using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace TestGui {
    
    /// <summary>
    /// The Connectsettings popup
    /// </summary>
    public partial class ConnectSettings : Form {
        
        // Variables
        private string comPort;

        /// <summary>
        /// Property for the COM Port
        /// </summary>
        public string ComPort {
            get {
                return this.comPort;
            }
        }
        
        /// <summary>
        /// Constructor
        /// </summary>
        public ConnectSettings() {
            InitializeComponent();

            // Fill the combobox with COM port values
            fillCombobox(comboBoxComPorts);
        }

        /// <summary>
        /// Fill a combobox with COM values
        /// </summary>
        /// <param name="cb">Combobox name</param>
        private void fillCombobox(ComboBox cb) {
            //get available com ports
            string[] ports = SerialPort.GetPortNames();
            foreach(string s in ports) {
                cb.Items.Add(s);
                }
            cb.SelectedIndex = 0;
        }

        /// <summary>
        /// The connect button
        /// </summary>
        /// <param name="sender">Object that sends the event</param>
        /// <param name="e">Event arguments</param>
        private void buttonConnect_Click(object sender, EventArgs e) {
            if (comboBoxComPorts.SelectedItem != null) {
                comPort = comboBoxComPorts.SelectedItem.ToString();
            } else {
                this.DialogResult = DialogResult.Retry;
            }
           
            this.Close();
        }
    }
}
