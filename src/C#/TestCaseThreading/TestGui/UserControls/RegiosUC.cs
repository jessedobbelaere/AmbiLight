using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestGui.UserControls {
    public partial class RegiosUC : UserControl {
        public RegiosUC() {
            InitializeComponent();
        }

        public virtual Rectangle[] GetRegions() {
            return null;
        }

    }
}
