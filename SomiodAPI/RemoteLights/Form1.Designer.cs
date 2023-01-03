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
            this.button1 = new System.Windows.Forms.Button();
            this.comboBoxApplications = new System.Windows.Forms.ComboBox();
            this.comboBoxModules = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonON
            // 
            this.buttonON.Location = new System.Drawing.Point(15, 139);
            this.buttonON.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonON.Name = "buttonON";
            this.buttonON.Size = new System.Drawing.Size(273, 94);
            this.buttonON.TabIndex = 0;
            this.buttonON.Text = "ON";
            this.buttonON.UseVisualStyleBackColor = true;
            this.buttonON.Click += new System.EventHandler(this.buttonON_Click);
            // 
            // buttonOFF
            // 
            this.buttonOFF.Location = new System.Drawing.Point(15, 238);
            this.buttonOFF.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonOFF.Name = "buttonOFF";
            this.buttonOFF.Size = new System.Drawing.Size(273, 96);
            this.buttonOFF.TabIndex = 1;
            this.buttonOFF.Text = "OFF";
            this.buttonOFF.UseVisualStyleBackColor = true;
            this.buttonOFF.Click += new System.EventHandler(this.buttonOFF_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(198, 13);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 28);
            this.button1.TabIndex = 2;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBoxApplications
            // 
            this.comboBoxApplications.FormattingEnabled = true;
            this.comboBoxApplications.Location = new System.Drawing.Point(106, 49);
            this.comboBoxApplications.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxApplications.Name = "comboBoxApplications";
            this.comboBoxApplications.Size = new System.Drawing.Size(172, 24);
            this.comboBoxApplications.TabIndex = 3;
            // 
            // comboBoxModules
            // 
            this.comboBoxModules.FormattingEnabled = true;
            this.comboBoxModules.Location = new System.Drawing.Point(106, 92);
            this.comboBoxModules.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxModules.Name = "comboBoxModules";
            this.comboBoxModules.Size = new System.Drawing.Size(172, 24);
            this.comboBoxModules.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Application";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 96);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Module";
            // 
            // Remote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 347);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxModules);
            this.Controls.Add(this.comboBoxApplications);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonOFF);
            this.Controls.Add(this.buttonON);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Remote";
            this.Text = "Remote";
            this.Load += new System.EventHandler(this.Remote_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonON;
        private System.Windows.Forms.Button buttonOFF;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBoxApplications;
        private System.Windows.Forms.ComboBox comboBoxModules;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

