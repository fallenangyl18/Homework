using System;

namespace sdev460
{
    public class User
    {
        private bool isValid;
        private string userName;
        private string pw;
        Log log = new Log();

        public User(Log log)
        {
            this.log = log;
        }
        public User()
        {
            
        }

        public string Pw { get => pw; set => pw = value; }
        public string UserName { get => userName; set => userName = value; }
        public bool IsValid { get => isValid; set => isValid = value; }


        public void validateLogin()
        {
            try
            {

                //check user
                if (UserName == "SDevAdmin")
                {
                    // check password
                    if (Pw == "Password01!")
                    {

                        IsValid = true;
                    }
                    else
                    {
                        //login fail
                        IsValid = false;
                    }
                }
                else
                {
                    //login failed
                    IsValid = false;
                }
            }
            // oops it broke
            catch (Exception ex)
            {
                isValid = false;
                log.SbLog.AppendLine("User: " + UserName + " Timestamp: " + DateTime.Now + " Success? " + IsValid + " Exeception:" + ex.ToString());
                log.writeToLog();
            }
            // 
            finally
            {
                log.SbLog.AppendLine("User: " + UserName + " TimeStamp: " + DateTime.Now + " Success? " + IsValid + " Log in attempt");
                log.writeToLog();
                
            }
        }
    }
}
