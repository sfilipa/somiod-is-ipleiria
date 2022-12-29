namespace RemoteLights
{
    partial class Remote
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
            this.buttonON = new System.Windows.Forms.Button();
            this.buttonOFF = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonON
            // 
            this.buttonON.Location = new System.Drawing.Point(11, 11);
            this.buttonON.Margin = new System.Windows.Forms.Padding(2);
            this.buttonON.Name = "buttonON";
            this.buttonON.Size = new System.Drawing.Size(103, 66);
            this.buttonON.TabIndex = 0;
            this.buttonON.Text = "ON";
            this.buttonON.UseVisualStyleBackColor = true;
            this.buttonON.Click += new System.EventHandler(this.buttonON_Click);
            // 
            // buttonOFF
            // 
            this.buttonOFF.Location = new System.Drawing.Point(11, 81);
            this.buttonOFF.Margin = new System.Windows.Forms.Padding(2);
            this.buttonOFF.Name = "buttonOFF";
            this.buttonOFF.Size = new System.Drawing.Size(103, 66);
            this.buttonOFF.TabIndex = 1;
            this.buttonOFF.Text = "OFF";
            this.buttonOFF.UseVisualStyleBackColor = true;
            this.buttonOFF.Click += new System.EventHandler(this.buttonOFF_Click);
            // 
            // Remote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(125, 158);
            this.Controls.Add(this.buttonOFF);
            this.Controls.Add(this.buttonON);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Remote";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Remote_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonON;
        private System.Windows.Forms.Button buttonOFF;
    }
}

