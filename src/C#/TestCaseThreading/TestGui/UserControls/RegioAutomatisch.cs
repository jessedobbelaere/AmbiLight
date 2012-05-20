using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestGui.UserControls {
    public partial class RegioAutomatisch : RegiosUC {
        public RegioAutomatisch() {
            InitializeComponent();
            this.Height += 50;
        }

        public override Rectangle[] GetRegions() {
            Rectangle[] regions = new Rectangle[2];

            // automatisch bepalen van regio's via resolutie en ingave aantal ledstrips links, boven en rechts

            return regions;
        }

    }
}
