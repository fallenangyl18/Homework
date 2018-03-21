using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using sdev460;
using System.Configuration;


namespace sdev460Tests1
{
    [TestClass]
    public class UnitTest1
    {
        // tests valid username / password data  pass
        [TestMethod]
        public void TestMethod1()
        {
            //arrange

            string expectedUserName = "SDevAdmin";
            string expectedPW = "Password01!";
            string userName = "SDevAdmin";
            string pw = "Password01!";

            User u1 = new User();

            //act
            u1.Pw = pw;
            u1.UserName = userName;
            //assert
          
            Assert.AreEqual(u1.UserName, expectedUserName);
            Assert.AreEqual(u1.Pw, expectedPW);
        }

        // tests invalid username data fail
        [TestMethod]      
        public void TestMethod2()
        {
            //arrange
            User u2 = new User();
            string expectedUserName = "SDevAdmin";
          
            string userName = "Admin";            

            //act
           
            u2.UserName = userName;

            //assert            
            Assert.AreEqual(u2.UserName, expectedUserName);
          
        }
        // tests invalid password data  fail
        [TestMethod]
        public void TestMethod3()
        {
            //arrange       
            string expectedPW = "Password01!";
            string PW = "passw0rt!";          

            User u3 = new User();

            //act
            u3.Pw = PW;
          
            //assert            
            Assert.AreEqual(u3.Pw, expectedPW);
          
        }

        // tests valid data in validateLogin method pass
        [TestMethod]
        public void TestMethod4()
        {
            //arrange          
            string userName = "SDevAdmin";
            string pw = "Password01!";
            bool expectedValid = true;

            User u4 = new User();
            u4.Pw = pw;
            u4.UserName = userName;

            //act
            u4.validateLogin();
         
            //assert
            Assert.AreEqual(u4.IsValid, expectedValid);           
        }

        // tests invalid data in validateLogin method pass
        [TestMethod]
        public void TestMethod5()
        {
            //arrange          
            string userName = "sdevadmin";
            string pw = "password";
            bool expectedValid = false;

            User u5 = new User();
            u5.Pw = pw;
            u5.UserName = userName;

            //act
            u5.validateLogin();

            //assert
            Assert.AreEqual(u5.IsValid, expectedValid);
        }

        // tests invalid data in validateLogin method pass
        [TestMethod]
        public void TestMethod6()
        {
            //arrange       
            string userName = "SDevAdmin";
            string pw = "Password01!";
            Log log1 = new Log();
            User user1 = new User(log1);
            string testPath = ConfigurationManager.AppSettings["TestDirLoc"];


            user1.Pw = pw;
            user1.UserName = userName;
            

            //act         
            File.Delete(testPath + "sdev460log.txt");
            log1.Path = testPath;
            user1.validateLogin();

            //assert            
            Assert.IsTrue(File.Exists(testPath + "sdev460log.txt"));
        }

    }
}
