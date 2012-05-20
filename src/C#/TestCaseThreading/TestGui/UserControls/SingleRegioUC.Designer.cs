namespace TestGui.UserControls {
    partial class SingleRegioUC {
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
            this.textBox2y = new System.Windows.Forms.TextBox();
            this.textBox2x = new System.Windows.Forms.TextBox();
            this.textBox1y = new System.Windows.Forms.TextBox();
            this.textBox1x = new System.Windows.Forms.TextBox();
            this.buttonRegion1 = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox2y
            // 
            this.textBox2y.Location = new System.Drawing.Point(174, 24);
            this.textBox2y.Name = "textBox2y";
            this.textBox2y.Size = new System.Drawing.Size(44, 20);
            this.textBox2y.TabIndex = 11;
            // 
            // textBox2x
            // 
            this.textBox2x.Location = new System.Drawing.Point(124, 24);
            this.textBox2x.Name = "textBox2x";
            this.textBox2x.Size = new System.Drawing.Size(44, 20);
            this.textBox2x.TabIndex = 10;
            // 
            // textBox1y
            // 
            this.textBox1y.Location = new System.Drawing.Point(61, 24);
            this.textBox1y.Name = "textBox1y";
            this.textBox1y.Size = new System.Drawing.Size(44, 20);
            this.textBox1y.TabIndex = 9;
            // 
            // textBox1x
            // 
            this.textBox1x.Location = new System.Drawing.Point(8, 24);
            this.textBox1x.Name = "textBox1x";
            this.textBox1x.Size = new System.Drawing.Size(44, 20);
            this.textBox1x.TabIndex = 8;
            // 
            // buttonRegion1
            // 
            this.buttonRegion1.Location = new System.Drawing.Point(233, 20);
            this.buttonRegion1.Name = "buttonRegion1";
            this.buttonRegion1.Size = new System.Drawing.Size(97, 23);
            this.buttonRegion1.TabIndex = 7;
            this.buttonRegion1.Text = "Selecteer regio";
            this.buttonRegion1.UseVisualStyleBackColor = true;
            this.buttonRegion1.Click += new System.EventHandler(this.buttonRegion1_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(5, 8);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(27, 13);
            this.labelTitle.TabIndex = 6;
            this.labelTitle.Text = "Title";
            // 
            // SingleRegioUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox2y);
            this.Controls.Add(this.textBox2x);
            this.Controls.Add(this.textBox1y);
            this.Controls.Add(this.textBox1x);
            this.Controls.Add(this.buttonRegion1);
            this.Controls.Add(this.labelTitle);
            this.Name = "SingleRegioUC";
            this.Size = new System.Drawing.Size(334, 51);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox2y;
        private System.Windows.Forms.TextBox textBox2x;
        private System.Windows.Forms.TextBox textBox1y;
        private System.Windows.Forms.TextBox textBox1x;
        private System.Windows.Forms.Button buttonRegion1;
        private System.Windows.Forms.Label labelTitle;
    }
}
