using System;
using System.Windows.Forms;
using AppConfigSE;

namespace DBScriptDeploymentTools
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            var obj = new AppConfigBAL();

            this.Text = obj.ReadTitle();

        }

        private void btnProcess_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (lvView.Items.Count == 0)
                {

                }
                else
                {

                }
            }
            catch (Exception ex)
            {

            }
        }

        private DialogResult ShowMessage(string messages, int boxType, string caption = "Information")
        {
            var result = new DialogResult();


            switch (boxType)
            {
                case 0:
                    result = MessageBox.Show(messages, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    break;
                case 1:
                    break;

            }

           


            return result;
        }
    }
}
