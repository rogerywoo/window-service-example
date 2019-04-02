namespace my_service_form_app
{
    partial class MyServiceForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyServiceForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fbd_InputFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.fbd_OutputFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.tb_InputFolder = new System.Windows.Forms.TextBox();
            this.tb_OutputFolder = new System.Windows.Forms.TextBox();
            this.btn_Run = new System.Windows.Forms.Button();
            this.btn_SelectInputFolder = new System.Windows.Forms.Button();
            this.btn_SelectOutputFolder = new System.Windows.Forms.Button();
            this.tb_Output = new System.Windows.Forms.TextBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIconMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_UpdateSettings = new System.Windows.Forms.Button();
            this.btn_StopService = new System.Windows.Forms.Button();
            this.btn_StartService = new System.Windows.Forms.Button();
            this.btn_RestartService = new System.Windows.Forms.Button();
            this.notifyIconMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Input Folder";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Output Folder";
            // 
            // tb_InputFolder
            // 
            this.tb_InputFolder.Location = new System.Drawing.Point(166, 37);
            this.tb_InputFolder.Name = "tb_InputFolder";
            this.tb_InputFolder.Size = new System.Drawing.Size(300, 20);
            this.tb_InputFolder.TabIndex = 2;
            // 
            // tb_OutputFolder
            // 
            this.tb_OutputFolder.Location = new System.Drawing.Point(166, 85);
            this.tb_OutputFolder.Name = "tb_OutputFolder";
            this.tb_OutputFolder.Size = new System.Drawing.Size(300, 20);
            this.tb_OutputFolder.TabIndex = 3;
            // 
            // btn_Run
            // 
            this.btn_Run.Location = new System.Drawing.Point(76, 388);
            this.btn_Run.Name = "btn_Run";
            this.btn_Run.Size = new System.Drawing.Size(191, 23);
            this.btn_Run.TabIndex = 4;
            this.btn_Run.Text = "Run";
            this.btn_Run.UseVisualStyleBackColor = true;
            this.btn_Run.Visible = false;
            this.btn_Run.Click += new System.EventHandler(this.btn_Run_Click);
            // 
            // btn_SelectInputFolder
            // 
            this.btn_SelectInputFolder.Location = new System.Drawing.Point(482, 34);
            this.btn_SelectInputFolder.Name = "btn_SelectInputFolder";
            this.btn_SelectInputFolder.Size = new System.Drawing.Size(75, 23);
            this.btn_SelectInputFolder.TabIndex = 5;
            this.btn_SelectInputFolder.Text = "Select";
            this.btn_SelectInputFolder.UseVisualStyleBackColor = true;
            this.btn_SelectInputFolder.Click += new System.EventHandler(this.btn_SelectInputFolder_Click);
            // 
            // btn_SelectOutputFolder
            // 
            this.btn_SelectOutputFolder.Location = new System.Drawing.Point(482, 82);
            this.btn_SelectOutputFolder.Name = "btn_SelectOutputFolder";
            this.btn_SelectOutputFolder.Size = new System.Drawing.Size(75, 23);
            this.btn_SelectOutputFolder.TabIndex = 6;
            this.btn_SelectOutputFolder.Text = "Select";
            this.btn_SelectOutputFolder.UseVisualStyleBackColor = true;
            this.btn_SelectOutputFolder.Click += new System.EventHandler(this.btn_SelectOutputFolder_Click);
            // 
            // tb_Output
            // 
            this.tb_Output.Location = new System.Drawing.Point(166, 274);
            this.tb_Output.Multiline = true;
            this.tb_Output.Name = "tb_Output";
            this.tb_Output.Size = new System.Drawing.Size(422, 72);
            this.tb_Output.TabIndex = 7;
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.notifyIconMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "My Service";
            this.notifyIcon.Visible = true;
            this.notifyIcon.Click += new System.EventHandler(this.notifyIcon_Click);
            // 
            // notifyIconMenuStrip
            // 
            this.notifyIconMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.notifyIconMenuStrip.Name = "notifyIconMenuStrip";
            this.notifyIconMenuStrip.Size = new System.Drawing.Size(104, 48);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click_1);
            // 
            // btn_UpdateSettings
            // 
            this.btn_UpdateSettings.Location = new System.Drawing.Point(275, 131);
            this.btn_UpdateSettings.Name = "btn_UpdateSettings";
            this.btn_UpdateSettings.Size = new System.Drawing.Size(191, 23);
            this.btn_UpdateSettings.TabIndex = 8;
            this.btn_UpdateSettings.Text = "Update Settings";
            this.btn_UpdateSettings.UseVisualStyleBackColor = true;
            this.btn_UpdateSettings.Click += new System.EventHandler(this.btn_UpdateSettings_Click);
            // 
            // btn_StopService
            // 
            this.btn_StopService.Location = new System.Drawing.Point(275, 161);
            this.btn_StopService.Name = "btn_StopService";
            this.btn_StopService.Size = new System.Drawing.Size(191, 23);
            this.btn_StopService.TabIndex = 9;
            this.btn_StopService.Text = "Stop Service";
            this.btn_StopService.UseVisualStyleBackColor = true;
            this.btn_StopService.Visible = false;
            this.btn_StopService.Click += new System.EventHandler(this.btn_StopService_Click);
            // 
            // btn_StartService
            // 
            this.btn_StartService.Location = new System.Drawing.Point(275, 191);
            this.btn_StartService.Name = "btn_StartService";
            this.btn_StartService.Size = new System.Drawing.Size(191, 23);
            this.btn_StartService.TabIndex = 10;
            this.btn_StartService.Text = "Start Service";
            this.btn_StartService.UseVisualStyleBackColor = true;
            this.btn_StartService.Visible = false;
            this.btn_StartService.Click += new System.EventHandler(this.btn_StartService_Click);
            // 
            // btn_RestartService
            // 
            this.btn_RestartService.Location = new System.Drawing.Point(275, 220);
            this.btn_RestartService.Name = "btn_RestartService";
            this.btn_RestartService.Size = new System.Drawing.Size(191, 23);
            this.btn_RestartService.TabIndex = 11;
            this.btn_RestartService.Text = "ReStart Service";
            this.btn_RestartService.UseVisualStyleBackColor = true;
            this.btn_RestartService.Visible = false;
            this.btn_RestartService.Click += new System.EventHandler(this.btn_RestartService_Click);
            // 
            // MyServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_RestartService);
            this.Controls.Add(this.btn_StartService);
            this.Controls.Add(this.btn_StopService);
            this.Controls.Add(this.btn_UpdateSettings);
            this.Controls.Add(this.tb_Output);
            this.Controls.Add(this.btn_SelectOutputFolder);
            this.Controls.Add(this.btn_SelectInputFolder);
            this.Controls.Add(this.btn_Run);
            this.Controls.Add(this.tb_OutputFolder);
            this.Controls.Add(this.tb_InputFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MyServiceForm";
            this.Text = "My Service";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MyServiceForm_FormClosing);
            this.Load += new System.EventHandler(this.MyServiceForm_Load);
            this.notifyIconMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog fbd_InputFolder;
        private System.Windows.Forms.FolderBrowserDialog fbd_OutputFolder;
        private System.Windows.Forms.TextBox tb_InputFolder;
        private System.Windows.Forms.TextBox tb_OutputFolder;
        private System.Windows.Forms.Button btn_Run;
        private System.Windows.Forms.Button btn_SelectInputFolder;
        private System.Windows.Forms.Button btn_SelectOutputFolder;
        private System.Windows.Forms.TextBox tb_Output;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Button btn_UpdateSettings;
        private System.Windows.Forms.ContextMenuStrip notifyIconMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button btn_StopService;
        private System.Windows.Forms.Button btn_StartService;
        private System.Windows.Forms.Button btn_RestartService;
    }
}

