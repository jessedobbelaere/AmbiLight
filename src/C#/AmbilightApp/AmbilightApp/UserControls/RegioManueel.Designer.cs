namespace TestGui.UserControls {
    partial class RegioManueel {
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
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonOpslaan = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(27, 3);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(97, 23);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "Voeg ledstrip toe";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonOpslaan
            // 
            this.buttonOpslaan.Location = new System.Drawing.Point(130, 3);
            this.buttonOpslaan.Name = "buttonOpslaan";
            this.buttonOpslaan.Size = new System.Drawing.Size(97, 23);
            this.buttonOpslaan.TabIndex = 1;
            this.buttonOpslaan.Text = "Sla regio\'s op";
            this.buttonOpslaan.UseVisualStyleBackColor = true;
            this.buttonOpslaan.Click += new System.EventHandler(this.buttonOpslaan_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(233, 3);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(97, 23);
            this.buttonReset.TabIndex = 2;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // RegioManueel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonOpslaan);
            this.Controls.Add(this.buttonAdd);
            this.Name = "RegioManueel";
            this.Size = new System.Drawing.Size(343, 83);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonOpslaan;
        private System.Windows.Forms.Button buttonReset;
    }
}
