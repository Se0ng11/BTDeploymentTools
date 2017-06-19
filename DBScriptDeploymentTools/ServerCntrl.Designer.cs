namespace DBScriptDeploymentTools
{
    partial class ServerCntrl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpServer = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // grpServer
            // 
            this.grpServer.Location = new System.Drawing.Point(3, 3);
            this.grpServer.Name = "grpServer";
            this.grpServer.Size = new System.Drawing.Size(141, 240);
            this.grpServer.TabIndex = 0;
            this.grpServer.TabStop = false;
            this.grpServer.Text = "Models";
            // 
            // ServerCntrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpServer);
            this.Name = "ServerCntrl";
            this.Size = new System.Drawing.Size(148, 247);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpServer;
    }
}
