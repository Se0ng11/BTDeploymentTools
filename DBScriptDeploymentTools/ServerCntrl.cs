using AppConfigSE;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace DBScriptDeploymentTools
{
    public partial class ServerCntrl : UserControl
    {
        #region property
        private List<AppConfigEntity> _appConfig = new List<AppConfigEntity>();

        public List<AppConfigEntity> ServerTag
        {
            get { return _appConfig; }
        }
        #endregion

        public ServerCntrl()
        {
            InitializeComponent();
            GenerateConnectionButton();

        }
        private void GenerateConnectionButton()
        {
            var s = new AppConfigBAL();
            var result = s.ListOfConnection();
            Point newLoc = new Point(10, 20);

            foreach (var t in result)
            {
                var chk = new CheckBox();
                chk.Text = t.Name.Substring(0, t.Name.IndexOf("|"));
                chk.Name = chk.Text.Trim();
                chk.Location = newLoc;
                chk.Size = new Size(100, 20);
                newLoc.Offset(0, chk.Height + 5);
                if (t.Name == s.ReadDefaultServer())
                {
                    chk.Checked = true;
                    _appConfig.Add(new AppConfigEntity
                    {
                        Name = chk.Text
                    });
                }

                chk.Click += new EventHandler(this.CheckBox_Click);

                if (this.grpServer.Controls.Find(chk.Name, true).Count() < 1)
                {
                    this.grpServer.Controls.Add(chk);
                    this.grpServer.Size = new Size(145, newLoc.Y + 10);
                }
            }
        }

        private void CheckBox_Click(object sender, EventArgs e)
        {
            var chk = (sender as CheckBox);

            if (chk.Checked)
            {
                _appConfig.Add(new AppConfigEntity
                {
                    Name = chk.Text
                });
            }
            else
            {
                _appConfig.RemoveAll(x => x.Name == chk.Text);
            }
        }
    }
}
