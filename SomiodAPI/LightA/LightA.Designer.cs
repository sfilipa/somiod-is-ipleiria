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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxApplicationName
            // 
            this.textBoxApplicationName.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxApplicationName.Location = new System.Drawing.Point(132, 12);
            this.textBoxApplicationName.Name = "textBoxApplicationName";
            this.textBoxApplicationName.Size = new System.Drawing.Size(132, 20);
            this.textBoxApplicationName.TabIndex = 0;
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
            this.textBoxModuleName.Location = new System.Drawing.Point(132, 38);
            this.textBoxModuleName.Name = "textBoxModuleName";
            this.textBoxModuleName.Size = new System.Drawing.Size(132, 20);
            this.textBoxModuleName.TabIndex = 3;
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(195, 144);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(69, 23);
            this.buttonCreate.TabIndex = 4;
            this.buttonCreate.Text = "Create";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // textBoxSubscriptionName
            // 
            this.textBoxSubscriptionName.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxSubscriptionName.Location = new System.Drawing.Point(132, 64);
            this.textBoxSubscriptionName.Name = "textBoxSubscriptionName";
            this.textBoxSubscriptionName.Size = new System.Drawing.Size(132, 20);
            this.textBoxSubscriptionName.TabIndex = 5;
            // 
            // comboBoxEventType
            // 
            this.comboBoxEventType.FormattingEnabled = true;
            this.comboBoxEventType.Items.AddRange(new object[] {
            "creation",
            "deletion",
            "creation and deletion"});
            this.comboBoxEventType.Location = new System.Drawing.Point(132, 89);
            this.comboBoxEventType.Name = "comboBoxEventType";
            this.comboBoxEventType.Size = new System.Drawing.Size(132, 21);
            this.comboBoxEventType.TabIndex = 6;
            // 
            // textBoxSubscriptionEndPoint
            // 
            this.textBoxSubscriptionEndPoint.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxSubscriptionEndPoint.Location = new System.Drawing.Point(132, 117);
            this.textBoxSubscriptionEndPoint.Name = "textBoxSubscriptionEndPoint";
            this.textBoxSubscriptionEndPoint.Size = new System.Drawing.Size(132, 20);
            this.textBoxSubscriptionEndPoint.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Application Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Module Name";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Subscription Name";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Subscription Event Type";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Subscription EndPoint";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // LightA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(276, 309);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

