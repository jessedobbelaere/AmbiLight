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
    /// Basis UserControl voor arduino mode instellingen waar alle anderen van overerven
    /// </summary>
    public partial class ArduinoUC : UserControl {
        private byte options;
        private byte[] bytes;

        public byte Options{
            get{
                return options;
            }
            set {
                options = value;
            }
        }
        public byte[] Bytes {
            get {
                return bytes;
            }
            set {
                bytes = value;
            }
        }

        public ArduinoUC() {
            InitializeComponent();
        }
    }
}
