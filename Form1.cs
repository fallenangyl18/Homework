using System;
using System.Windows.Forms;


namespace sdev460
{
    public partial class Form1 : Form
    {

        User aUser = new User();
        Log log = new Log();

        public Form1()
        {
            InitializeComponent();                
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {

                aUser.UserName = txtUser.Text;
                aUser.Pw = txtPassword.Text;
                aUser.validateLogin();

                if (aUser.IsValid)
                {                    
                    panLogin.Visible = false;
                    lblWelcome.Visible = true;
                }
                else
                {
                    clearFields();
                    lblMsg.Text = "Login Failed";

                }
            }
            // oops it broke
            catch (Exception ex)
            {
                
                log.SbLog.AppendLine("User: " + aUser.UserName + " Timestamp: " + DateTime.Now + " Success? " + aUser.IsValid + " Exeception:" + ex.ToString());
                log.writeToLog();
            }
          
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearFields();
            log.SbLog.AppendLine("User: " + aUser.UserName + " Timestamp: " + DateTime.Now + " Success? " + aUser.IsValid);
            log.writeToLog();
        }


        private void clearFields()
        {
            txtUser.Text = "";
            txtPassword.Text  = "";
            lblWelcome.Visible = false;
            panLogin.Visible = true;
            aUser.UserName = "";
            aUser.Pw = "";
            aUser.IsValid = false;

        }

  
    }
}
