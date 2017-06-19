namespace DBScriptDeploymentTools
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lvView = new System.Windows.Forms.ListView();
            this.colFiles = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLocation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colServer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Duration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnProcess = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblHelp = new System.Windows.Forms.LinkLabel();
            this.btnShowLog = new System.Windows.Forms.Button();
            this.bg1 = new System.ComponentModel.BackgroundWorker();
            this.tm1 = new System.Windows.Forms.Timer(this.components);
            this.lblElapsed = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runThisScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customAssignServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.neptune122ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.neptune124ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClearSelection = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.tm2 = new System.Windows.Forms.Timer(this.components);
            this.bg2 = new System.ComponentModel.BackgroundWorker();
            this.serverCntrl1 = new DBScriptDeploymentTools.ServerCntrl();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvView
            // 
            this.lvView.AllowDrop = true;
            this.lvView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFiles,
            this.colLocation,
            this.colServer,
            this.colStatus,
            this.Duration});
            this.lvView.FullRowSelect = true;
            this.lvView.GridLines = true;
            this.lvView.Location = new System.Drawing.Point(166, 36);
            this.lvView.Name = "lvView";
            this.lvView.ShowItemToolTips = true;
            this.lvView.Size = new System.Drawing.Size(1042, 449);
            this.lvView.TabIndex = 1;
            this.lvView.UseCompatibleStateImageBehavior = false;
            this.lvView.View = System.Windows.Forms.View.Details;
            this.lvView.DoubleClick += new System.EventHandler(this.lvView_DoubleClick);
            this.lvView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvView_KeyDown);
            this.lvView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvView_MouseClick);
            // 
            // colFiles
            // 
            this.colFiles.Text = "Files";
            this.colFiles.Width = 500;
            // 
            // colLocation
            // 
            this.colLocation.Text = "Location";
            this.colLocation.Width = 0;
            // 
            // colServer
            // 
            this.colServer.Text = "Server";
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 600;
            // 
            // Duration
            // 
            this.Duration.Text = "Duration";
            this.Duration.Width = 100;
            // 
            // btnProcess
            // 
            this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcess.Location = new System.Drawing.Point(1133, 492);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 32);
            this.btnProcess.TabIndex = 2;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F);
            this.lblTotal.Location = new System.Drawing.Point(166, 492);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(101, 20);
            this.lblTotal.TabIndex = 3;
            this.lblTotal.Text = "Total files: 0";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(1052, 492);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 32);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblHelp
            // 
            this.lblHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblHelp.AutoSize = true;
            this.lblHelp.Font = new System.Drawing.Font("Monotype Corsiva", 6F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHelp.Location = new System.Drawing.Point(10, 511);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Size = new System.Drawing.Size(65, 11);
            this.lblHelp.TabIndex = 10;
            this.lblHelp.TabStop = true;
            this.lblHelp.Text = "Created By Se^0^ng";
            this.lblHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblHelp_LinkClicked);
            // 
            // btnShowLog
            // 
            this.btnShowLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowLog.Location = new System.Drawing.Point(896, 492);
            this.btnShowLog.Name = "btnShowLog";
            this.btnShowLog.Size = new System.Drawing.Size(150, 32);
            this.btnShowLog.TabIndex = 11;
            this.btnShowLog.Text = "Copy Error To Clipboard";
            this.btnShowLog.UseVisualStyleBackColor = true;
            this.btnShowLog.Click += new System.EventHandler(this.btnShowLog_Click);
            // 
            // bg1
            // 
            this.bg1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bg1_DoWork);
            this.bg1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bg1_ProgressChanged);
            this.bg1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bg1_RunWorkerCompleted);
            // 
            // tm1
            // 
            this.tm1.Interval = 1000;
            this.tm1.Tick += new System.EventHandler(this.tm1_Tick);
            // 
            // lblElapsed
            // 
            this.lblElapsed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblElapsed.AutoSize = true;
            this.lblElapsed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F);
            this.lblElapsed.Location = new System.Drawing.Point(321, 492);
            this.lblElapsed.Name = "lblElapsed";
            this.lblElapsed.Size = new System.Drawing.Size(116, 20);
            this.lblElapsed.TabIndex = 12;
            this.lblElapsed.Text = "Elapsed Time:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLocationToolStripMenuItem,
            this.runThisScriptToolStripMenuItem,
            this.customAssignServerToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(187, 70);
            // 
            // showLocationToolStripMenuItem
            // 
            this.showLocationToolStripMenuItem.Name = "showLocationToolStripMenuItem";
            this.showLocationToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.showLocationToolStripMenuItem.Text = "Show location";
            this.showLocationToolStripMenuItem.Click += new System.EventHandler(this.showLocationToolStripMenuItem_Click);
            // 
            // runThisScriptToolStripMenuItem
            // 
            this.runThisScriptToolStripMenuItem.Name = "runThisScriptToolStripMenuItem";
            this.runThisScriptToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.runThisScriptToolStripMenuItem.Text = "Run this script";
            this.runThisScriptToolStripMenuItem.Click += new System.EventHandler(this.runThisScriptToolStripMenuItem_Click);
            // 
            // customAssignServerToolStripMenuItem
            // 
            this.customAssignServerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.neptune122ToolStripMenuItem,
            this.neptune124ToolStripMenuItem});
            this.customAssignServerToolStripMenuItem.Name = "customAssignServerToolStripMenuItem";
            this.customAssignServerToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.customAssignServerToolStripMenuItem.Text = "Custom assign server";
            // 
            // neptune122ToolStripMenuItem
            // 
            this.neptune122ToolStripMenuItem.Name = "neptune122ToolStripMenuItem";
            this.neptune122ToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.neptune122ToolStripMenuItem.Text = "Neptune 122";
            this.neptune122ToolStripMenuItem.Click += new System.EventHandler(this.neptune122ToolStripMenuItem_Click);
            // 
            // neptune124ToolStripMenuItem
            // 
            this.neptune124ToolStripMenuItem.Name = "neptune124ToolStripMenuItem";
            this.neptune124ToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.neptune124ToolStripMenuItem.Text = "Neptune 144";
            this.neptune124ToolStripMenuItem.Click += new System.EventHandler(this.neptune124ToolStripMenuItem_Click);
            // 
            // btnClearSelection
            // 
            this.btnClearSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearSelection.Location = new System.Drawing.Point(788, 492);
            this.btnClearSelection.Name = "btnClearSelection";
            this.btnClearSelection.Size = new System.Drawing.Size(102, 32);
            this.btnClearSelection.TabIndex = 14;
            this.btnClearSelection.Text = "Clear Selection";
            this.btnClearSelection.UseVisualStyleBackColor = true;
            this.btnClearSelection.Click += new System.EventHandler(this.btnClearSelection_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(13, 13);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 13);
            this.lblMessage.TabIndex = 15;
            // 
            // tm2
            // 
            this.tm2.Interval = 3000;
            // 
            // bg2
            // 
            this.bg2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bg2_DoWork);
            this.bg2.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bg2_ProgressChanged);
            this.bg2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bg2_RunWorkerCompleted);
            // 
            // serverCntrl1
            // 
            this.serverCntrl1.Location = new System.Drawing.Point(12, 36);
            this.serverCntrl1.Name = "serverCntrl1";
            this.serverCntrl1.Size = new System.Drawing.Size(148, 449);
            this.serverCntrl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 531);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnClearSelection);
            this.Controls.Add(this.lblElapsed);
            this.Controls.Add(this.btnShowLog);
            this.Controls.Add(this.lblHelp);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.lvView);
            this.Controls.Add(this.serverCntrl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(1236, 570);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ServerCntrl serverCntrl1;
        private System.Windows.Forms.ListView lvView;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.ColumnHeader colFiles;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.LinkLabel lblHelp;
        private System.Windows.Forms.Button btnShowLog;
        private System.ComponentModel.BackgroundWorker bg1;
        private System.Windows.Forms.Timer tm1;
        private System.Windows.Forms.Label lblElapsed;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showLocationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runThisScriptToolStripMenuItem;
        private System.Windows.Forms.Button btnClearSelection;
        private System.Windows.Forms.ColumnHeader colLocation;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Timer tm2;
        private System.Windows.Forms.ColumnHeader colServer;
        private System.ComponentModel.BackgroundWorker bg2;
        private System.Windows.Forms.ToolStripMenuItem customAssignServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem neptune122ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem neptune124ToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader Duration;
    }
}

