using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestGui.UserControls {
    public partial class RegioManueel : RegiosUC {
        public List<SingleRegioUC> ambilightRegions;

        public RegioManueel() {
            InitializeComponent();
            ambilightRegions = new List<SingleRegioUC>();
            
            // een eerste regio
            ambilightRegions.Add(new SingleRegioUC(ambilightRegions.Count));
            this.Controls.Add(ambilightRegions[0]);
            this.buttonAdd.Location = new Point(233, (ambilightRegions.Count * ambilightRegions[0].Height) + 10);
        }

        public override Rectangle[] GetRegions() {
            Rectangle[] regions = new Rectangle[ambilightRegions.Count];

            for (int i = 0; i < ambilightRegions.Count; i++) {
                int x = ambilightRegions[i].x;
                int y = ambilightRegions[i].y;
                int width = ambilightRegions[i].width;
                int height = ambilightRegions[i].height;

                regions[i] = new Rectangle(x, y, width, height);
            }

            return regions;
        }

        /// <summary>
        /// Toevoegen van een singleRegioUC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAdd_Click(object sender, EventArgs e) {
            ambilightRegions.Add(new SingleRegioUC(ambilightRegions.Count));
            this.Controls.Add(ambilightRegions[ambilightRegions.Count - 1]);
            ReplaceUC();
            this.buttonAdd.Location = new Point(233, (ambilightRegions.Count * ambilightRegions[0].Height) + 10);
            this.Height += ambilightRegions[0].Height;
        }

        /// <summary>
        /// Verplaatsen van singelRegioUC's 
        /// </summary>
        private void ReplaceUC() {
            int y = 0;
            foreach (SingleRegioUC ambiLightRegion in ambilightRegions) {
                ambiLightRegion.Location = new Point(0, y);
                y += ambiLightRegion.Height;
            }
        }

    }
}
