namespace LightA
{
    partial class LightA
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
            this.textBoxApplicationName = new System.Windows.Forms.TextBox();
            this.richTextBoxLightBulb = new System.Windows.Forms.RichTextBox();
            this.textBoxModuleName = new System.Windows.Forms.TextBox();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.textBoxSubscriptionName = new System.Windows.Forms.TextBox();
            this.comboBoxEventType = new System.Windows.Forms.ComboBox();
            this.textBoxSubscriptionEndPoint = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxApplicationName
            // 
            this.textBoxApplicationName.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxApplicationName.Location = new System.Drawing.Point(12, 12);
            this.textBoxApplicationName.Name = "textBoxApplicationName";
            this.textBoxApplicationName.Size = new System.Drawing.Size(252, 20);
            this.textBoxApplicationName.TabIndex = 0;
            this.textBoxApplicationName.Text = "Application Name";
            // 
            // richTextBoxLightBulb
            // 
            this.richTextBoxLightBulb.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.richTextBoxLightBulb.Location = new System.Drawing.Point(65, 173);
            this.richTextBoxLightBulb.Name = "richTextBoxLightBulb";
            this.richTextBoxLightBulb.Size = new System.Drawing.Size(141, 124);
            this.richTextBoxLightBulb.TabIndex = 1;
            this.richTextBoxLightBulb.Text = "";
            // 
            // textBoxModuleName
            // 
            this.textBoxModuleName.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxModuleName.Location = new System.Drawing.Point(12, 38);
            this.textBoxModuleName.Name = "textBoxModuleName";
            this.textBoxModuleName.Size = new System.Drawing.Size(252, 20);
            this.textBoxModuleName.TabIndex = 3;
            this.textBoxModuleName.Text = "Module Name";
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(189, 143);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(75, 23);
            this.buttonCreate.TabIndex = 4;
            this.buttonCreate.Text = "Create";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // textBoxSubscriptionName
            // 
            this.textBoxSubscriptionName.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxSubscriptionName.Location = new System.Drawing.Point(12, 64);
            this.textBoxSubscriptionName.Name = "textBoxSubscriptionName";
            this.textBoxSubscriptionName.Size = new System.Drawing.Size(252, 20);
            this.textBoxSubscriptionName.TabIndex = 5;
            this.textBoxSubscriptionName.Text = "Subscription Name";
            // 
            // comboBoxEventType
            // 
            this.comboBoxEventType.FormattingEnabled = true;
            this.comboBoxEventType.Items.AddRange(new object[] {
            "creation",
            "deletion",
            "creation and deletion"});
            this.comboBoxEventType.Location = new System.Drawing.Point(12, 90);
            this.comboBoxEventType.Name = "comboBoxEventType";
            this.comboBoxEventType.Size = new System.Drawing.Size(252, 21);
            this.comboBoxEventType.TabIndex = 6;
            this.comboBoxEventType.Text = "Subscription Event Type";
            // 
            // textBoxSubscriptionEndPoint
            // 
            this.textBoxSubscriptionEndPoint.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxSubscriptionEndPoint.Location = new System.Drawing.Point(12, 117);
            this.textBoxSubscriptionEndPoint.Name = "textBoxSubscriptionEndPoint";
            this.textBoxSubscriptionEndPoint.Size = new System.Drawing.Size(252, 20);
            this.textBoxSubscriptionEndPoint.TabIndex = 7;
            this.textBoxSubscriptionEndPoint.Text = "Subscription EndPoint";
            // 
            // LightA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(276, 309);
            this.Controls.Add(this.textBoxSubscriptionEndPoint);
            this.Controls.Add(this.comboBoxEventType);
            this.Controls.Add(this.textBoxSubscriptionName);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.textBoxModuleName);
            this.Controls.Add(this.richTextBoxLightBulb);
            this.Controls.Add(this.textBoxApplicationName);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "LightA";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxApplicationName;
        private System.Windows.Forms.RichTextBox richTextBoxLightBulb;
        private System.Windows.Forms.TextBox textBoxModuleName;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.TextBox textBoxSubscriptionName;
        private System.Windows.Forms.ComboBox comboBoxEventType;
        private System.Windows.Forms.TextBox textBoxSubscriptionEndPoint;
    }
}

