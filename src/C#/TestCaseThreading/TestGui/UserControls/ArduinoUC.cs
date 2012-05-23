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
    /// Basic UserControl for arduino mode settings
    /// </summary>
    public partial class ArduinoUC : UserControl {
        private byte options;
        private byte[] bytes;

        /// <summary>
        /// Property for the options
        /// </summary>
        public byte Options{
            get{
                return options;
            }
            set {
                options = value;
            }
        }

        /// <summary>
        /// Property for the bytes
        /// </summary>
        public byte[] Bytes {
            get {
                return bytes;
            }
            set {
                bytes = value;
            }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public ArduinoUC() {
            InitializeComponent();
        }
    }
}
