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

namespace TestCaseThreading {
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

            Opvullen(comboBoxSource, typeof(Source)); //screencap combobox
            Opvullen(comboBoxAMode, typeof(ArduinoModes)); //arduino modes combobox
            Opvullen(comboBoxMethode, typeof(RegioMethodes)); //select regio combobox

            deleg = new UpdateLogDelegate(addToLog);
            deleg("Application started");

            //aanmaken businesslayer
            bl = new BL(deleg);                   
        }

        #region GUI code

        /// <summary>
        /// Lijn toevoegen aan log
        /// </summary>
        /// <param name="s">String met text voor log</param>
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
        /// Opent het comport connectie venster
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

        private void ShowErrorMessage(string s) {
            MessageBox.Show(s, "Foutmelding", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Laadt nieuwe usercontrol in wanneer mode veranderd word in de combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            }
        }

        #endregion

        private void buttonModeStartClick(object sender, EventArgs e) {
            if (bl.SerialWorks) {
                switch ((ArduinoModes)Enum.Parse(typeof(ArduinoModes), this.comboBoxAMode.SelectedItem.ToString())) {
                    //TODO: hier options en bytes meegeven v instellingen user controls
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
                    default:
                        System.Diagnostics.Debug.Print("Something went awfuly wrong with the Arduino Mode dropdown. Are you a magician?");
                        break;
                }
            }
            else {
                ShowErrorMessage("Please connect to a serial port before starting. Use File > Connect from the menu");
            }
        }

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
            }
        }

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
