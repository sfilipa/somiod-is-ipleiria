namespace SomiodTestApplication
{
    partial class Form1
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
            this.buttonGetAllApplications = new System.Windows.Forms.Button();
            this.buttonGetApplication = new System.Windows.Forms.Button();
            this.richTextBoxApplication = new System.Windows.Forms.RichTextBox();
            this.textBoxGetApplicationByName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxApplicationName = new System.Windows.Forms.TextBox();
            this.buttonPOSTApplication = new System.Windows.Forms.Button();
            this.buttonDELApplication = new System.Windows.Forms.Button();
            this.buttonPUTApplication = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.richTextBoxListApplications = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxApplicationNewName = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.richTextBoxListModules = new System.Windows.Forms.RichTextBox();
            this.buttonDELModule = new System.Windows.Forms.Button();
            this.buttonPUTModule = new System.Windows.Forms.Button();
            this.buttonPOSTModule = new System.Windows.Forms.Button();
            this.textBoxModuleNewName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxModuleName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxApplicationNameModule = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxGetModuleName = new System.Windows.Forms.TextBox();
            this.richTextBoxSpecificModule = new System.Windows.Forms.RichTextBox();
            this.buttonGetModule = new System.Windows.Forms.Button();
            this.buttonGetAllModules = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.buttonDELData = new System.Windows.Forms.Button();
            this.textBoxDataID = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.buttonPOSTData = new System.Windows.Forms.Button();
            this.richTextBoxDataContent = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxModuleNameData = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxApplicationNameData = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.buttonPOSTSubscription = new System.Windows.Forms.Button();
            this.textBoxEndPoint = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textBoxSubscriptionNameDEL = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.comboBoxSubscriptionEvents = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBoxSubscriptionNamePOST = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.buttonDELSubscription = new System.Windows.Forms.Button();
            this.textBoxModuleNameSubscription = new System.Windows.Forms.TextBox();
            this.textBoxApplicationNameSubscription = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonGetAllApplications
            // 
            this.buttonGetAllApplications.Location = new System.Drawing.Point(6, 23);
            this.buttonGetAllApplications.Name = "buttonGetAllApplications";
            this.buttonGetAllApplications.Size = new System.Drawing.Size(124, 22);
            this.buttonGetAllApplications.TabIndex = 0;
            this.buttonGetAllApplications.Text = "Get All Applications";
            this.buttonGetAllApplications.UseVisualStyleBackColor = true;
            this.buttonGetAllApplications.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonGetApplication
            // 
            this.buttonGetApplication.Location = new System.Drawing.Point(6, 231);
            this.buttonGetApplication.Name = "buttonGetApplication";
            this.buttonGetApplication.Size = new System.Drawing.Size(124, 22);
            this.buttonGetApplication.TabIndex = 2;
            this.buttonGetApplication.Text = "Get Application";
            this.buttonGetApplication.UseVisualStyleBackColor = true;
            this.buttonGetApplication.Click += new System.EventHandler(this.button2_Click);
            // 
            // richTextBoxApplication
            // 
            this.richTextBoxApplication.BackColor = System.Drawing.SystemColors.MenuBar;
            this.richTextBoxApplication.Location = new System.Drawing.Point(7, 259);
            this.richTextBoxApplication.Name = "richTextBoxApplication";
            this.richTextBoxApplication.Size = new System.Drawing.Size(388, 65);
            this.richTextBoxApplication.TabIndex = 3;
            this.richTextBoxApplication.Text = "";
            // 
            // textBoxGetApplicationByName
            // 
            this.textBoxGetApplicationByName.Location = new System.Drawing.Point(208, 233);
            this.textBoxGetApplicationByName.Name = "textBoxGetApplicationByName";
            this.textBoxGetApplicationByName.Size = new System.Drawing.Size(100, 20);
            this.textBoxGetApplicationByName.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(164, 236);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Name:";
            this.label1.UseMnemonic = false;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(475, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Name:";
            this.label2.UseMnemonic = false;
            // 
            // textBoxApplicationName
            // 
            this.textBoxApplicationName.Location = new System.Drawing.Point(544, 48);
            this.textBoxApplicationName.Name = "textBoxApplicationName";
            this.textBoxApplicationName.Size = new System.Drawing.Size(124, 20);
            this.textBoxApplicationName.TabIndex = 7;
            this.textBoxApplicationName.TextChanged += new System.EventHandler(this.textBoxApplicationName_TextChanged);
            // 
            // buttonPOSTApplication
            // 
            this.buttonPOSTApplication.Location = new System.Drawing.Point(544, 120);
            this.buttonPOSTApplication.Name = "buttonPOSTApplication";
            this.buttonPOSTApplication.Size = new System.Drawing.Size(124, 22);
            this.buttonPOSTApplication.TabIndex = 8;
            this.buttonPOSTApplication.Text = "POST (Create)";
            this.buttonPOSTApplication.UseVisualStyleBackColor = true;
            this.buttonPOSTApplication.Click += new System.EventHandler(this.buttonPOSTApplication_Click);
            // 
            // buttonDELApplication
            // 
            this.buttonDELApplication.Location = new System.Drawing.Point(544, 176);
            this.buttonDELApplication.Name = "buttonDELApplication";
            this.buttonDELApplication.Size = new System.Drawing.Size(124, 22);
            this.buttonDELApplication.TabIndex = 9;
            this.buttonDELApplication.Text = "DEL (Delete)";
            this.buttonDELApplication.UseVisualStyleBackColor = true;
            this.buttonDELApplication.Click += new System.EventHandler(this.buttonDELApplication_Click);
            // 
            // buttonPUTApplication
            // 
            this.buttonPUTApplication.Location = new System.Drawing.Point(544, 148);
            this.buttonPUTApplication.Name = "buttonPUTApplication";
            this.buttonPUTApplication.Size = new System.Drawing.Size(124, 22);
            this.buttonPUTApplication.TabIndex = 10;
            this.buttonPUTApplication.Text = "PUT (Update)";
            this.buttonPUTApplication.UseVisualStyleBackColor = true;
            this.buttonPUTApplication.Click += new System.EventHandler(this.buttonPUTApplication_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(2, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(786, 413);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.richTextBoxListApplications);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.textBoxApplicationNewName);
            this.tabPage1.Controls.Add(this.buttonGetAllApplications);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.textBoxApplicationName);
            this.tabPage1.Controls.Add(this.buttonPOSTApplication);
            this.tabPage1.Controls.Add(this.buttonPUTApplication);
            this.tabPage1.Controls.Add(this.buttonDELApplication);
            this.tabPage1.Controls.Add(this.richTextBoxApplication);
            this.tabPage1.Controls.Add(this.buttonGetApplication);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.textBoxGetApplicationByName);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(778, 387);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Application";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // richTextBoxListApplications
            // 
            this.richTextBoxListApplications.BackColor = System.Drawing.SystemColors.MenuBar;
            this.richTextBoxListApplications.Location = new System.Drawing.Point(7, 48);
            this.richTextBoxListApplications.Name = "richTextBoxListApplications";
            this.richTextBoxListApplications.Size = new System.Drawing.Size(388, 179);
            this.richTextBoxListApplications.TabIndex = 13;
            this.richTextBoxListApplications.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(475, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "New Name:";
            this.label3.UseMnemonic = false;
            // 
            // textBoxApplicationNewName
            // 
            this.textBoxApplicationNewName.Location = new System.Drawing.Point(544, 74);
            this.textBoxApplicationNewName.Name = "textBoxApplicationNewName";
            this.textBoxApplicationNewName.Size = new System.Drawing.Size(124, 20);
            this.textBoxApplicationNewName.TabIndex = 11;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.richTextBoxListModules);
            this.tabPage2.Controls.Add(this.buttonDELModule);
            this.tabPage2.Controls.Add(this.buttonPUTModule);
            this.tabPage2.Controls.Add(this.buttonPOSTModule);
            this.tabPage2.Controls.Add(this.textBoxModuleNewName);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.textBoxModuleName);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.textBoxApplicationNameModule);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.textBoxGetModuleName);
            this.tabPage2.Controls.Add(this.richTextBoxSpecificModule);
            this.tabPage2.Controls.Add(this.buttonGetModule);
            this.tabPage2.Controls.Add(this.buttonGetAllModules);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(778, 387);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Module";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // richTextBoxListModules
            // 
            this.richTextBoxListModules.BackColor = System.Drawing.SystemColors.MenuBar;
            this.richTextBoxListModules.Location = new System.Drawing.Point(9, 83);
            this.richTextBoxListModules.Name = "richTextBoxListModules";
            this.richTextBoxListModules.Size = new System.Drawing.Size(388, 144);
            this.richTextBoxListModules.TabIndex = 17;
            this.richTextBoxListModules.Text = "";
            // 
            // buttonDELModule
            // 
            this.buttonDELModule.Location = new System.Drawing.Point(657, 129);
            this.buttonDELModule.Name = "buttonDELModule";
            this.buttonDELModule.Size = new System.Drawing.Size(109, 22);
            this.buttonDELModule.TabIndex = 16;
            this.buttonDELModule.Text = "DEL (Delete)";
            this.buttonDELModule.UseVisualStyleBackColor = true;
            this.buttonDELModule.Click += new System.EventHandler(this.buttonDELModule_Click);
            // 
            // buttonPUTModule
            // 
            this.buttonPUTModule.Location = new System.Drawing.Point(657, 172);
            this.buttonPUTModule.Name = "buttonPUTModule";
            this.buttonPUTModule.Size = new System.Drawing.Size(109, 22);
            this.buttonPUTModule.TabIndex = 15;
            this.buttonPUTModule.Text = "PUT (Update)";
            this.buttonPUTModule.UseVisualStyleBackColor = true;
            this.buttonPUTModule.Click += new System.EventHandler(this.buttonPUTModule_Click);
            // 
            // buttonPOSTModule
            // 
            this.buttonPOSTModule.Location = new System.Drawing.Point(657, 101);
            this.buttonPOSTModule.Name = "buttonPOSTModule";
            this.buttonPOSTModule.Size = new System.Drawing.Size(109, 22);
            this.buttonPOSTModule.TabIndex = 14;
            this.buttonPOSTModule.Text = "POST (Create)";
            this.buttonPOSTModule.UseVisualStyleBackColor = true;
            this.buttonPOSTModule.Click += new System.EventHandler(this.buttonPOSTModule_Click);
            // 
            // textBoxModuleNewName
            // 
            this.textBoxModuleNewName.Location = new System.Drawing.Point(526, 174);
            this.textBoxModuleNewName.Name = "textBoxModuleNewName";
            this.textBoxModuleNewName.Size = new System.Drawing.Size(110, 20);
            this.textBoxModuleNewName.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(419, 177);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "New Module Name:";
            this.label7.UseMnemonic = false;
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // textBoxModuleName
            // 
            this.textBoxModuleName.Location = new System.Drawing.Point(526, 101);
            this.textBoxModuleName.Name = "textBoxModuleName";
            this.textBoxModuleName.Size = new System.Drawing.Size(110, 20);
            this.textBoxModuleName.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(419, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Module Name:";
            this.label5.UseMnemonic = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Application Name:";
            this.label6.UseMnemonic = false;
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // textBoxApplicationNameModule
            // 
            this.textBoxApplicationNameModule.Location = new System.Drawing.Point(105, 12);
            this.textBoxApplicationNameModule.Name = "textBoxApplicationNameModule";
            this.textBoxApplicationNameModule.Size = new System.Drawing.Size(100, 20);
            this.textBoxApplicationNameModule.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(136, 263);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Module Name:";
            this.label4.UseMnemonic = false;
            // 
            // textBoxGetModuleName
            // 
            this.textBoxGetModuleName.Location = new System.Drawing.Point(218, 260);
            this.textBoxGetModuleName.Name = "textBoxGetModuleName";
            this.textBoxGetModuleName.Size = new System.Drawing.Size(100, 20);
            this.textBoxGetModuleName.TabIndex = 5;
            this.textBoxGetModuleName.TextChanged += new System.EventHandler(this.textBoxGetModuleName_TextChanged);
            // 
            // richTextBoxSpecificModule
            // 
            this.richTextBoxSpecificModule.BackColor = System.Drawing.SystemColors.MenuBar;
            this.richTextBoxSpecificModule.Location = new System.Drawing.Point(6, 286);
            this.richTextBoxSpecificModule.Name = "richTextBoxSpecificModule";
            this.richTextBoxSpecificModule.Size = new System.Drawing.Size(391, 84);
            this.richTextBoxSpecificModule.TabIndex = 4;
            this.richTextBoxSpecificModule.Text = "";
            // 
            // buttonGetModule
            // 
            this.buttonGetModule.Location = new System.Drawing.Point(6, 258);
            this.buttonGetModule.Name = "buttonGetModule";
            this.buttonGetModule.Size = new System.Drawing.Size(124, 22);
            this.buttonGetModule.TabIndex = 3;
            this.buttonGetModule.Text = "Get Module";
            this.buttonGetModule.UseVisualStyleBackColor = true;
            this.buttonGetModule.Click += new System.EventHandler(this.buttonGetModule_Click);
            // 
            // buttonGetAllModules
            // 
            this.buttonGetAllModules.Location = new System.Drawing.Point(6, 55);
            this.buttonGetAllModules.Name = "buttonGetAllModules";
            this.buttonGetAllModules.Size = new System.Drawing.Size(124, 22);
            this.buttonGetAllModules.TabIndex = 1;
            this.buttonGetAllModules.Text = "Get All Modules";
            this.buttonGetAllModules.UseVisualStyleBackColor = true;
            this.buttonGetAllModules.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.buttonDELData);
            this.tabPage3.Controls.Add(this.textBoxDataID);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.buttonPOSTData);
            this.tabPage3.Controls.Add(this.richTextBoxDataContent);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.textBoxModuleNameData);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.textBoxApplicationNameData);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(778, 387);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Data";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // buttonDELData
            // 
            this.buttonDELData.Location = new System.Drawing.Point(510, 11);
            this.buttonDELData.Name = "buttonDELData";
            this.buttonDELData.Size = new System.Drawing.Size(124, 22);
            this.buttonDELData.TabIndex = 19;
            this.buttonDELData.Text = "DEL (Delete)";
            this.buttonDELData.UseVisualStyleBackColor = true;
            this.buttonDELData.Click += new System.EventHandler(this.buttonDELData_Click);
            // 
            // textBoxDataID
            // 
            this.textBoxDataID.Location = new System.Drawing.Point(393, 11);
            this.textBoxDataID.Name = "textBoxDataID";
            this.textBoxDataID.Size = new System.Drawing.Size(100, 20);
            this.textBoxDataID.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(340, 14);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Data ID:";
            this.label11.UseMnemonic = false;
            // 
            // buttonPOSTData
            // 
            this.buttonPOSTData.Location = new System.Drawing.Point(9, 179);
            this.buttonPOSTData.Name = "buttonPOSTData";
            this.buttonPOSTData.Size = new System.Drawing.Size(124, 22);
            this.buttonPOSTData.TabIndex = 16;
            this.buttonPOSTData.Text = "POST (Create)";
            this.buttonPOSTData.UseVisualStyleBackColor = true;
            this.buttonPOSTData.Click += new System.EventHandler(this.buttonPOSTData_Click);
            // 
            // richTextBoxDataContent
            // 
            this.richTextBoxDataContent.BackColor = System.Drawing.SystemColors.MenuBar;
            this.richTextBoxDataContent.Location = new System.Drawing.Point(9, 105);
            this.richTextBoxDataContent.Name = "richTextBoxDataContent";
            this.richTextBoxDataContent.Size = new System.Drawing.Size(282, 68);
            this.richTextBoxDataContent.TabIndex = 15;
            this.richTextBoxDataContent.Text = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 89);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Content:";
            this.label10.UseMnemonic = false;
            // 
            // textBoxModuleNameData
            // 
            this.textBoxModuleNameData.Location = new System.Drawing.Point(105, 41);
            this.textBoxModuleNameData.Name = "textBoxModuleNameData";
            this.textBoxModuleNameData.Size = new System.Drawing.Size(100, 20);
            this.textBoxModuleNameData.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Module Name:";
            this.label9.UseMnemonic = false;
            // 
            // textBoxApplicationNameData
            // 
            this.textBoxApplicationNameData.Location = new System.Drawing.Point(105, 11);
            this.textBoxApplicationNameData.Name = "textBoxApplicationNameData";
            this.textBoxApplicationNameData.Size = new System.Drawing.Size(100, 20);
            this.textBoxApplicationNameData.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Application Name:";
            this.label8.UseMnemonic = false;
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.buttonPOSTSubscription);
            this.tabPage4.Controls.Add(this.textBoxEndPoint);
            this.tabPage4.Controls.Add(this.label17);
            this.tabPage4.Controls.Add(this.textBoxSubscriptionNameDEL);
            this.tabPage4.Controls.Add(this.label16);
            this.tabPage4.Controls.Add(this.comboBoxSubscriptionEvents);
            this.tabPage4.Controls.Add(this.label15);
            this.tabPage4.Controls.Add(this.textBoxSubscriptionNamePOST);
            this.tabPage4.Controls.Add(this.label14);
            this.tabPage4.Controls.Add(this.buttonDELSubscription);
            this.tabPage4.Controls.Add(this.textBoxModuleNameSubscription);
            this.tabPage4.Controls.Add(this.textBoxApplicationNameSubscription);
            this.tabPage4.Controls.Add(this.label13);
            this.tabPage4.Controls.Add(this.label12);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(778, 387);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Subscription";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // buttonPOSTSubscription
            // 
            this.buttonPOSTSubscription.Location = new System.Drawing.Point(6, 177);
            this.buttonPOSTSubscription.Name = "buttonPOSTSubscription";
            this.buttonPOSTSubscription.Size = new System.Drawing.Size(124, 22);
            this.buttonPOSTSubscription.TabIndex = 29;
            this.buttonPOSTSubscription.Text = "POST (Create)";
            this.buttonPOSTSubscription.UseVisualStyleBackColor = true;
            this.buttonPOSTSubscription.Click += new System.EventHandler(this.buttonPOSTSubscription_Click);
            // 
            // textBoxEndPoint
            // 
            this.textBoxEndPoint.Location = new System.Drawing.Point(123, 138);
            this.textBoxEndPoint.Name = "textBoxEndPoint";
            this.textBoxEndPoint.Size = new System.Drawing.Size(121, 20);
            this.textBoxEndPoint.TabIndex = 28;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 141);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(114, 13);
            this.label17.TabIndex = 27;
            this.label17.Text = "Subscription EndPoint:";
            this.label17.UseMnemonic = false;
            // 
            // textBoxSubscriptionNameDEL
            // 
            this.textBoxSubscriptionNameDEL.Location = new System.Drawing.Point(431, 10);
            this.textBoxSubscriptionNameDEL.Name = "textBoxSubscriptionNameDEL";
            this.textBoxSubscriptionNameDEL.Size = new System.Drawing.Size(121, 20);
            this.textBoxSubscriptionNameDEL.TabIndex = 26;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(326, 13);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(99, 13);
            this.label16.TabIndex = 25;
            this.label16.Text = "Subscription Name:";
            this.label16.UseMnemonic = false;
            // 
            // comboBoxSubscriptionEvents
            // 
            this.comboBoxSubscriptionEvents.FormattingEnabled = true;
            this.comboBoxSubscriptionEvents.Items.AddRange(new object[] {
            "creation",
            "deletion",
            "creation and deletion"});
            this.comboBoxSubscriptionEvents.Location = new System.Drawing.Point(123, 111);
            this.comboBoxSubscriptionEvents.Name = "comboBoxSubscriptionEvents";
            this.comboBoxSubscriptionEvents.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSubscriptionEvents.TabIndex = 24;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 114);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(99, 13);
            this.label15.TabIndex = 23;
            this.label15.Text = "Subscription Event:";
            this.label15.UseMnemonic = false;
            // 
            // textBoxSubscriptionNamePOST
            // 
            this.textBoxSubscriptionNamePOST.Location = new System.Drawing.Point(123, 81);
            this.textBoxSubscriptionNamePOST.Name = "textBoxSubscriptionNamePOST";
            this.textBoxSubscriptionNamePOST.Size = new System.Drawing.Size(121, 20);
            this.textBoxSubscriptionNamePOST.TabIndex = 22;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 84);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(99, 13);
            this.label14.TabIndex = 21;
            this.label14.Text = "Subscription Name:";
            this.label14.UseMnemonic = false;
            // 
            // buttonDELSubscription
            // 
            this.buttonDELSubscription.Location = new System.Drawing.Point(558, 10);
            this.buttonDELSubscription.Name = "buttonDELSubscription";
            this.buttonDELSubscription.Size = new System.Drawing.Size(124, 22);
            this.buttonDELSubscription.TabIndex = 20;
            this.buttonDELSubscription.Text = "DEL (Delete)";
            this.buttonDELSubscription.UseVisualStyleBackColor = true;
            // 
            // textBoxModuleNameSubscription
            // 
            this.textBoxModuleNameSubscription.Location = new System.Drawing.Point(123, 38);
            this.textBoxModuleNameSubscription.Name = "textBoxModuleNameSubscription";
            this.textBoxModuleNameSubscription.Size = new System.Drawing.Size(121, 20);
            this.textBoxModuleNameSubscription.TabIndex = 15;
            // 
            // textBoxApplicationNameSubscription
            // 
            this.textBoxApplicationNameSubscription.Location = new System.Drawing.Point(123, 12);
            this.textBoxApplicationNameSubscription.Name = "textBoxApplicationNameSubscription";
            this.textBoxApplicationNameSubscription.Size = new System.Drawing.Size(121, 20);
            this.textBoxApplicationNameSubscription.TabIndex = 14;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 41);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(76, 13);
            this.label13.TabIndex = 13;
            this.label13.Text = "Module Name:";
            this.label13.UseMnemonic = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Application Name:";
            this.label12.UseMnemonic = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 419);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonGetAllApplications;
        private System.Windows.Forms.Button buttonGetApplication;
        private System.Windows.Forms.RichTextBox richTextBoxApplication;
        private System.Windows.Forms.TextBox textBoxGetApplicationByName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxApplicationName;
        private System.Windows.Forms.Button buttonPOSTApplication;
        private System.Windows.Forms.Button buttonDELApplication;
        private System.Windows.Forms.Button buttonPUTApplication;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxApplicationNewName;
        private System.Windows.Forms.Button buttonGetAllModules;
        private System.Windows.Forms.Button buttonGetModule;
        private System.Windows.Forms.RichTextBox richTextBoxSpecificModule;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxGetModuleName;
        private System.Windows.Forms.TextBox textBoxApplicationNameModule;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonDELModule;
        private System.Windows.Forms.Button buttonPUTModule;
        private System.Windows.Forms.Button buttonPOSTModule;
        private System.Windows.Forms.TextBox textBoxModuleNewName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxModuleName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxApplicationNameData;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonDELData;
        private System.Windows.Forms.TextBox textBoxDataID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button buttonPOSTData;
        private System.Windows.Forms.RichTextBox richTextBoxDataContent;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxModuleNameData;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxModuleNameSubscription;
        private System.Windows.Forms.TextBox textBoxApplicationNameSubscription;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxSubscriptionNamePOST;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button buttonDELSubscription;
        private System.Windows.Forms.ComboBox comboBoxSubscriptionEvents;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button buttonPOSTSubscription;
        private System.Windows.Forms.TextBox textBoxEndPoint;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBoxSubscriptionNameDEL;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.RichTextBox richTextBoxListModules;
        private System.Windows.Forms.RichTextBox richTextBoxListApplications;
    }
}

