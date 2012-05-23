using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace TestGui.UserControls {
    
    /// <summary>
    /// The manual region usercontrol
    /// </summary>
    public partial class RegioManueel : RegiosUC {
        
        // Variables
        public List<SingleRegioUC> ambilightRegions;

        /// <summary>
        /// The default-constructor
        /// </summary>
        public RegioManueel() {
            InitializeComponent();
            ambilightRegions = new List<SingleRegioUC>();
            
            GetXmlData();
            ReplaceUC();
        }

        /// <summary>
        /// Get the regions
        /// </summary>
        /// <returns>Regions rectangle</returns>
        public override Rectangle[] GetRegions() {
            Rectangle[] regions = new Rectangle[ambilightRegions.Count];

            for (int i = 0; i < ambilightRegions.Count; i++) {
                int x = ambilightRegions[i].X;
                int y = ambilightRegions[i].Y;
                int width = ambilightRegions[i].Breedte;
                int height = ambilightRegions[i].Hoogte;

                regions[i] = new Rectangle(x, y, width, height);
            }

            return regions;
        }

        /// <summary>
        /// Add new singleRegioUC
        /// </summary>
        /// <param name="sender">The object that raised the event</param>
        /// <param name="e">Event args</param>
        private void buttonAdd_Click(object sender, EventArgs e) {
            ambilightRegions.Add(new SingleRegioUC(ambilightRegions.Count));
            this.Controls.Add(ambilightRegions[ambilightRegions.Count - 1]);
            ReplaceUC();
            
            this.Height += ambilightRegions[0].Height;
        }

        /// <summary>
        /// Replace the single region Usercontrols
        /// </summary>
        private void ReplaceUC() {
            int y = 0;
            foreach (SingleRegioUC ambiLightRegion in ambilightRegions) {
                ambiLightRegion.Location = new Point(0, y);
                y += ambiLightRegion.Height;
            }

            this.buttonAdd.Location = new Point(27, (ambilightRegions.Count * ambilightRegions[0].Height) + 10);
            this.buttonOpslaan.Location = new Point(130, (ambilightRegions.Count * ambilightRegions[0].Height) + 10);
            this.buttonReset.Location = new Point(233, (ambilightRegions.Count * ambilightRegions[0].Height) + 10);
        }
        
        /// <summary>
        /// Reset regio's
        /// </summary>
        /// <param name="sender">The object that raised the event</param>
        /// <param name="e">Event args</param>
        private void buttonReset_Click(object sender, EventArgs e) {
            foreach (SingleRegioUC ambiLightRegion in ambilightRegions) {
                this.Controls.Remove(ambiLightRegion);
            }
            this.Height = 83;
            ambilightRegions = new List<SingleRegioUC>();           

            ambilightRegions.Add(new SingleRegioUC(ambilightRegions.Count));
            this.Controls.Add(ambilightRegions[0]);

            ReplaceUC();
        }

        /// <summary>
        /// Save regio's to xml file
        /// </summary>
        /// <param name="sender">The object that raised the event</param>
        /// <param name="e">Event args</param>
        private void buttonOpslaan_Click(object sender, EventArgs e) {
            Rectangle[] regions = this.GetRegions();

            using (FileStream bestand = File.Open(@".\test.xml", FileMode.Create)) {
                XmlSerializer serializer = new XmlSerializer(regions.GetType());
                serializer.Serialize(bestand, regions);
            }
        }

        /// <summary>
        /// Get regio data from xml file
        /// </summary>
        private void GetXmlData() {
            Rectangle[] regions = new Rectangle[0];

            using (FileStream bestand = File.Open(@".\test.xml", FileMode.Open)) {
                XmlSerializer serializer = new XmlSerializer(regions.GetType());
                regions = (Rectangle[])serializer.Deserialize(bestand);
            }

            foreach (Rectangle regio in regions) {
                SingleRegioUC regioUC = new SingleRegioUC(ambilightRegions.Count);
                regioUC.X = regio.X;
                regioUC.Y = regio.Y;
                regioUC.Breedte = regio.Width;
                regioUC.Hoogte = regio.Height;
                this.Controls.Add(regioUC);
                this.Height += regioUC.Height;
                ambilightRegions.Add(regioUC);
            }
        }

    }
}
