namespace TestGui.UserControls {
    partial class RegioAutomatisch {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownLinks = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMidden = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownRechts = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLinks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMidden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRechts)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Links";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Midden";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Rechts";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Aantal ledstrips:";
            // 
            // numericUpDownLinks
            // 
            this.numericUpDownLinks.Location = new System.Drawing.Point(82, 43);
            this.numericUpDownLinks.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownLinks.Name = "numericUpDownLinks";
            this.numericUpDownLinks.Size = new System.Drawing.Size(42, 20);
            this.numericUpDownLinks.TabIndex = 7;
            // 
            // numericUpDownMidden
            // 
            this.numericUpDownMidden.Location = new System.Drawing.Point(82, 73);
            this.numericUpDownMidden.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownMidden.Name = "numericUpDownMidden";
            this.numericUpDownMidden.Size = new System.Drawing.Size(42, 20);
            this.numericUpDownMidden.TabIndex = 8;
            // 
            // numericUpDownRechts
            // 
            this.numericUpDownRechts.Location = new System.Drawing.Point(82, 103);
            this.numericUpDownRechts.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownRechts.Name = "numericUpDownRechts";
            this.numericUpDownRechts.Size = new System.Drawing.Size(42, 20);
            this.numericUpDownRechts.TabIndex = 9;
            // 
            // RegioAutomatisch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numericUpDownRechts);
            this.Controls.Add(this.numericUpDownMidden);
            this.Controls.Add(this.numericUpDownLinks);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RegioAutomatisch";
            this.Size = new System.Drawing.Size(283, 164);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLinks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMidden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRechts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownLinks;
        private System.Windows.Forms.NumericUpDown numericUpDownMidden;
        private System.Windows.Forms.NumericUpDown numericUpDownRechts;
    }
}
