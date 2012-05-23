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
    /// The Regions usercontrol
    /// </summary>
    public partial class RegiosUC : UserControl {
        
        /// <summary>
        /// The default constructor
        /// </summary>
        public RegiosUC() {
            InitializeComponent();
        }

        /// <summary>
        /// Get the regions
        /// </summary>
        /// <returns>null</returns>
        public virtual Rectangle[] GetRegions() {
            return null;
        }

    }
}
