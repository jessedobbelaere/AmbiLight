using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestGui {
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
            for(int i= 1; i<=12; i++) {
                cb.Items.Add("COM" + i);
            }
            cb.SelectedIndex = 0;
        }

        /// <summary>
        /// The connect button
        /// </summary>
        /// <param name="sender">Object that sends the event</param>
        /// <param name="e">Event arguments</param>
        private void buttonConnect_Click(object sender, EventArgs e) {
            comPort = comboBoxComPorts.SelectedItem.ToString();
            this.Close();
        }
    }
}
