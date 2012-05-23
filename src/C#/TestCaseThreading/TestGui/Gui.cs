using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TestGui;
using TestGui.UserControls;
using System.Text.RegularExpressions;

namespace TestCaseThreading {
   
    /// <summary>
    /// The Ambilight App GUI
    /// </summary>
    public partial class Gui : Form {
        
        // Variables
        private BL bl;
        private UpdateLogDelegate deleg;
        private ArduinoUC modeconfigUC;
        private RegiosUC regiosUC;

        /// <summary>
        /// Constructor
        /// </summary>
        public Gui() {
            InitializeComponent();

            FillCombobox(comboBoxSource, typeof(Source)); //screencap combobox
            comboBoxSource.SelectedIndex = 1;
            FillCombobox(comboBoxAMode, typeof(ArduinoModes)); //arduino modes combobox
            FillCombobox(comboBoxMethode, typeof(RegioMethodes)); //select regio combobox

            deleg = new UpdateLogDelegate(addToLog);
            deleg("Application started");

            // make business layer object
            bl = new BL(deleg);                   
        }

        #region GUI code

        /// <summary>
        /// Add line to log
        /// </summary>
        /// <param name="s">String with text for the log</param>
        private void addToLog(string s) {

            if (textBoxLog.InvokeRequired) {
                textBoxLog.BeginInvoke(new Action(delegate {
                    addToLog(s);
                }));
                return; 
            }

            String text = "(" + DateTime.Now + ") " + s + Environment.NewLine;
            this.textBoxLog.Text += text;

            checkForAction(s);
        }

        /// <summary>
        /// Check if an action was sent within the delegate message
        /// </summary>
        /// <param name="message">The sent message</param>
        private void checkForAction(string message) {

            if (message.StartsWith("Received message: msg:")) {
                string msg = message.TrimEnd(new char[] { '\0' });
                string[] action = Regex.Split(msg, "msg:");

                if(action[1].StartsWith("rgb:")){
                    string[] splitt = Regex.Split(action[1], "rgb:");
                    string[] rgb = Regex.Split(splitt[1], ",");
                    byte rood = byte.Parse(rgb[0]);
                    byte groen = byte.Parse(rgb[1]);
                    byte blauw = byte.Parse(rgb[2]);
                    bl.StartFx(15,0,new byte[]{rood,groen,blauw});
                    System.Diagnostics.Debug.Print(rood.ToString() +  groen.ToString() + blauw.ToString());
                }
                switch (action[1]) {
                    // Ambilight controls
                    case "StartAmbilight":
                        buttonStartScreen_Click(null, null); // Lets cheat a little, this wasn't called from a button... Doesn't matter!
                        break;
                    case "StopAmbilight":
                        buttonStopScreen_Click(null, null);
                        break;

                    // Effects
                    case "StartFxCycle":
                        bl.StartFx(1);
                        addToLog("Started the color cycle mode");
                        break;
                    case "StartFxStrobe":
                        bl.StartFx(2);
                        addToLog("Started the Strobe");
                        break;
                    case "StartFxPolice":
                        bl.StartFx(3);
                        addToLog("Started Police Light mode");
                        break;
                    case "StopFx":
                        buttonModeStop_Click(null, null);
                        break;
                }

            }
        }

        /// <summary>
        /// Fill a combobox with enum items
        /// </summary>
        /// <param name="cb">Combobox to fill</param>
        /// <param name="enumeratieType">Enum with items</param>
        private void FillCombobox(ComboBox cb, Type enumeratieType) {
            foreach (string name in Enum.GetNames(enumeratieType)) {
                if (name != "NN") {
                    cb.Items.Add(name);
                }
            }
            cb.SelectedIndex = 0;
        }

        /// <summary>
        /// Open the connectionsettings popup
        /// </summary>
        private void ShowConnectDialog(){
            ConnectSettings connectsettings = new ConnectSettings();
            connectsettings.ShowDialog();

            if (connectsettings.DialogResult == DialogResult.OK) {
                bl.SetSerial(connectsettings.ComPort);
            } else if (connectsettings.DialogResult == DialogResult.Retry) {
                ShowConnectDialog();
            }
        }

        /// <summary>
        /// Show an error message
        /// </summary>
        /// <param name="s">The error message string</param>
        private void ShowErrorMessage(string s) {
            MessageBox.Show(s, "Foutmelding", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Load a new usercontrol each time a new mode is chosen in the combobox
        /// </summary>
        /// <param name="sender">The object that raised the event</param>
        /// <param name="e">Event args</param>
        private void updateAModeConfigUC(object sender, EventArgs e) {
            switch ((ArduinoModes)Enum.Parse(typeof(ArduinoModes), this.comboBoxAMode.SelectedItem.ToString())) {
                case ArduinoModes.Colorcycle:
                    this.groupBoxAModeConfig.Controls.Clear();
                    modeconfigUC = new ColorCycleUC();
                    this.groupBoxAModeConfig.Controls.Add(new ColorCycleUC());
                    break;
                case ArduinoModes.Strobe:
                    this.groupBoxAModeConfig.Controls.Clear();
                    modeconfigUC = new StrobeUC();
                    this.groupBoxAModeConfig.Controls.Add(modeconfigUC);
                    break;
                case ArduinoModes.PoliceLight:
                    this.groupBoxAModeConfig.Controls.Clear();
                    modeconfigUC = new PoliceUC();
                    this.groupBoxAModeConfig.Controls.Add(modeconfigUC);
                    break;
                case ArduinoModes.SingelColor:
                    this.groupBoxAModeConfig.Controls.Clear();
                    modeconfigUC = new SingleColorUC();
                    this.groupBoxAModeConfig.Controls.Add(modeconfigUC);
                    break;
            }
        }

        #endregion

        /// <summary>
        /// Start the ambilight effects
        /// </summary>
        /// <param name="sender">The object that raised the event</param>
        /// <param name="e">The event args</param>
        private void buttonModeStartClick(object sender, EventArgs e) {
            if (bl.SerialWorks) {
                switch ((ArduinoModes)Enum.Parse(typeof(ArduinoModes), this.comboBoxAMode.SelectedItem.ToString())) {
                    case ArduinoModes.Colorcycle:
                        bl.StartFx(1);
                        addToLog("Started the color cycle mode");
                        break;
                    case ArduinoModes.Strobe:
                        bl.StartFx(2);
                        addToLog("Started the Strobe");
                        break;
                    case ArduinoModes.PoliceLight:
                        bl.StartFx(3);
                        addToLog("Started Police Light mode");
                        break;
                    case ArduinoModes.SingelColor:
                        bl.StartFx(15, 0, modeconfigUC.Bytes);
                        addToLog("Started Single Color Mode");
                        break;
                    default:
                        System.Diagnostics.Debug.Print("Something went awfuly wrong with the Arduino Mode dropdown. Are you a magician?");
                        break;
                }
            }
            else {
                ShowErrorMessage("Please connect to a serial port before starting. Use File > Connect from the menu");
                ShowConnectDialog();
            }
        }

        /// <summary>
        /// Stop the Ambilight effects
        /// </summary>
        /// <param name="sender">The object that raised the event</param>
        /// <param name="e">Event args</param>
        private void buttonModeStop_Click(object sender, EventArgs e) {
            if (bl.SerialWorks) {
                bl.StopFX();
            }
            else {
                ShowErrorMessage("Please connect to a serial port before starting. Use File > Connect from the menu");
            }
        }


        /// <summary>
        /// Connect to a selected COM Port from the popup.
        /// </summary>
        /// <param name="sender">Object that raised the event</param>
        /// <param name="e">Event arguments</param>
        private void connectToolStripMenuItem_Click(object sender, EventArgs e) {
            ShowConnectDialog();
        }

        /// <summary>
        /// Disconnect the serial connection (DOESN'T WORK?)
        /// </summary>
        /// <param name="sender">Object that raised the event</param>
        /// <param name="e">Event arguments</param>
        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e) {
            if (bl.SerialWorks) {
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
            if (bl.SerialWorks) {
                bl.SetColorSource((Source)Enum.Parse(typeof(Source), this.comboBoxSource.SelectedItem.ToString()), regiosUC.GetRegions());
                bl.StartSource(); 
            }
            else {
                ShowErrorMessage("Please connect to a serial port before starting. Use File > Connect from the menu");
                ShowConnectDialog();
            }
        }

        
        /// <summary>
        /// Stop the screen observation
        /// </summary>
        /// <param name="sender">Object that raised the event</param>
        /// <param name="e">Event arguments</param>
        private void buttonStopScreen_Click(object sender, EventArgs e) {
            if (bl.SerialWorks) {
                bl.StopSource(); 
            }
        }

        
        /// <summary>
        /// Start the server
        /// </summary>
        /// <param name="sender">Object that raised the event</param>
        /// <param name="e">Event arguments</param>
        private void startToolStripMenuItem_Click_1(object sender, EventArgs e) {
            if (bl.SerialWorks) {
                bl.StartServer(); 
            }
            else {
                ShowErrorMessage("Please connect to a serial port before starting. Use File > Connect from the menu");
                ShowConnectDialog();
            }
        }

        /// <summary>
        /// Stop the server
        /// </summary>
        /// <param name="sender">Object that raised the event</param>
        /// <param name="e">Event arguments</param>
        private void stopToolStripMenuItem_Click(object sender, EventArgs e) {
            if (bl.SerialWorks) {
                bl.StopServer();
            }
            else {
                ShowErrorMessage("Please connect to a serial port before starting. Use File > Connect from the menu");
                ShowConnectDialog();
            }
        }

        /// <summary>
        /// Combobox index changed
        /// </summary>
        /// <param name="sender">The object that raised the event</param>
        /// <param name="e">Event args</param>
        private void comboBoxMethode_SelectedIndexChanged(object sender, EventArgs e) {
            switch ((RegioMethodes)Enum.Parse(typeof(RegioMethodes), this.comboBoxMethode.SelectedItem.ToString())) {
                case RegioMethodes.Manueel:
                    this.panelRegioConfig.Controls.Clear();
                    regiosUC = new RegioManueel();
                    this.panelRegioConfig.Controls.Add(regiosUC);
                    break;
                case RegioMethodes.Automatisch:
                    this.panelRegioConfig.Controls.Clear();
                    regiosUC = new RegioAutomatisch();
                    this.panelRegioConfig.Controls.Add(regiosUC);
                    break;
            }
        }


    }
}
