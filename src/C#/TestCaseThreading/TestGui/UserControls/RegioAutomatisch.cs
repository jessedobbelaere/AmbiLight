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

        /// <summary>
        /// Get the regions
        /// </summary>
        /// <returns></returns>
        public override Rectangle[] GetRegions() {
            int links = (int)numericUpDownLinks.Value;
            int midden = (int)numericUpDownMidden.Value;
            int rechts = (int)numericUpDownRechts.Value;

            Rectangle resolution = Screen.PrimaryScreen.Bounds;
            
            Rectangle[] regions = new Rectangle[links + midden + rechts];

            for (int i = 0; i < links; i++) {
                regions[i] = new Rectangle(resolution.X, (resolution.Height / links) * (links - (i + 1) ) , resolution.Width / 2, resolution.Height / links);
            }

            for (int i = links; i < midden + links; i++) {
                regions[i] = new Rectangle((resolution.Width / midden) * (i - links), resolution.Y, resolution.Width / midden, resolution.Height / 2);
            }

            for (int i = midden + links; i < rechts + midden + links; i++) {
                regions[i] = new Rectangle(resolution.Width / 2, (resolution.Height / rechts) * (i - midden - links), resolution.Width / 2, resolution.Height / rechts);
            }
            

            return regions;
        }

    }
}
