namespace myClipBoard
{
    partial class settingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(settingsForm));
            this.lblOpacity = new System.Windows.Forms.Label();
            this.updnOpacity = new System.Windows.Forms.NumericUpDown();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.updnOpacity)).BeginInit();
            this.SuspendLayout();
            // 
            // lblOpacity
            // 
            this.lblOpacity.AutoSize = true;
            this.lblOpacity.Location = new System.Drawing.Point(21, 16);
            this.lblOpacity.Name = "lblOpacity";
            this.lblOpacity.Size = new System.Drawing.Size(55, 17);
            this.lblOpacity.TabIndex = 0;
            this.lblOpacity.Text = "Opacity";
            // 
            // updnOpacity
            // 
            this.updnOpacity.Cursor = System.Windows.Forms.Cursors.Default;
            this.updnOpacity.DecimalPlaces = 2;
            this.updnOpacity.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.updnOpacity.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.updnOpacity.Location = new System.Drawing.Point(82, 14);
            this.updnOpacity.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.updnOpacity.Name = "updnOpacity";
            this.updnOpacity.Size = new System.Drawing.Size(120, 24);
            this.updnOpacity.TabIndex = 1;
            this.updnOpacity.ValueChanged += new System.EventHandler(this.updnOpacity_ValueChanged);
            this.updnOpacity.Click += new System.EventHandler(this.updnOpacity_Click);
            this.updnOpacity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.updnOpacity_KeyPress);
            this.updnOpacity.KeyUp += new System.Windows.Forms.KeyEventHandler(this.updnOpacity_KeyUp);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(18, 51);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(89, 29);
            this.btnApply.TabIndex = 3;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(113, 51);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(89, 29);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // settingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 96);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.updnOpacity);
            this.Controls.Add(this.lblOpacity);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "settingsForm";
            this.Text = "Settings";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.settingsForm_Load);
            this.Click += new System.EventHandler(this.settingsForm_Click);
            ((System.ComponentModel.ISupportInitialize)(this.updnOpacity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOpacity;
        private System.Windows.Forms.NumericUpDown updnOpacity;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCancel;
    }
}