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
            this.lvView = new System.Windows.Forms.ListView();
            this.serverCntrl1 = new DBScriptDeploymentTools.ServerCntrl();
            this.btnProcess = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvView
            // 
            this.lvView.AllowDrop = true;
            this.lvView.FullRowSelect = true;
            this.lvView.Location = new System.Drawing.Point(166, 12);
            this.lvView.Name = "lvView";
            this.lvView.Size = new System.Drawing.Size(570, 449);
            this.lvView.TabIndex = 1;
            this.lvView.UseCompatibleStateImageBehavior = false;
            this.lvView.View = System.Windows.Forms.View.List;
            // 
            // serverCntrl1
            // 
            this.serverCntrl1.Location = new System.Drawing.Point(12, 12);
            this.serverCntrl1.Name = "serverCntrl1";
            this.serverCntrl1.ServerName = null;
            this.serverCntrl1.ServerTag = null;
            this.serverCntrl1.Size = new System.Drawing.Size(148, 247);
            this.serverCntrl1.TabIndex = 0;
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(661, 467);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 32);
            this.btnProcess.TabIndex = 2;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 507);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.lvView);
            this.Controls.Add(this.serverCntrl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ServerCntrl serverCntrl1;
        private System.Windows.Forms.ListView lvView;
        private System.Windows.Forms.Button btnProcess;
    }
}

