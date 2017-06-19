using System;
using System.Drawing;
using System.Windows.Forms;
using AppConfigSE;

namespace DBScriptDeploymentTools
{
    public partial class ServerCntrl : UserControl
    {
        #region property
        private string _serverTag;
        private string _defaultServerTag;
        private string _serverName;
        private string _defaultServerName;

        public String ServerTag
        {
            get { return _serverTag; }
            set { _serverTag = (string.IsNullOrEmpty(value)) ? _defaultServerTag : value; }
        }

        public String ServerName
        {
            get { return _serverName; }
            set { _serverName = (string.IsNullOrEmpty(value)) ? _defaultServerName : value; }
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
                var rdb = new RadioButton();

                rdb.Text = t.Name;
                rdb.Tag = t.ConnectionString;
                rdb.Location = newLoc;
                rdb.Size = new Size(100, 20);
                newLoc.Offset(0, rdb.Height + 5);
                if (rdb.Text == s.ReadDefaultServer())
                {
                    rdb.Checked = true;
                    _defaultServerTag = rdb.Tag.ToString();
                    _defaultServerName = rdb.Text;
                }

                rdb.Click += new EventHandler(this.RadioButton_Click);

                this.grpServer.Controls.Add(rdb);
                this.grpServer.Size = new Size(121, newLoc.Y + 10);
            }
        }

        private void RadioButton_Click(object sender, EventArgs e)
        {
            var rdb = (sender as RadioButton);
            _serverTag = rdb.Tag.ToString();
            _serverName = rdb.Text;
        }
    }
}
