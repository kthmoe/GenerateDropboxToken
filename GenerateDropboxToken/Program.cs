using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenerateDropboxToken
{
    internal class Program
    {
        //static void Main(string[] args)
        //{

        //     //string url = "https://www.dropbox.com/login";
        //    string url = "https://www.dropbox.com/developers/apps/info/vk3fbzlssw9nsrs#settings";
        //    //IWebDriver driver = new ChromeDriver();
        //    EdgeOptions option = new EdgeOptions();
        //    var service = EdgeDriverService.CreateDefaultService(AppDomain.CurrentDomain.BaseDirectory);
        //    using (IWebDriver edge = new EdgeDriver(service, option, TimeSpan.FromMinutes(3)))
        //    {
        //        string username = "office@capital-knowledge.co.jp"; string password = "capitaloo13";
        //        edge.Url = url;
        //        edge.FindElement(By.Name("login_email")).SendKeys(username);
        //        edge.FindElement(By.Name("login_password")).SendKeys(password);
        //        //Thread.Sleep(3000);
        //        edge.FindElement(By.XPath("//button[@type='submit']")).Click();
        //        //edge.FindElement(By.Id("generate-token-button")).Click();
        //        //edge.FindElement(By.Name("allow_access")).Click();
        //        Thread.Sleep(5000);

        //        edge.Close();
        //    }

        //}
        private static bool completed = false;
        private static bool login = false;
        //private static EdgeOptions edge;
        [STAThread]
        static void Main(string[] args)
        {
            Login();
            //if (login)
            //{
            //    GenerateToken();
            //}
            //if (completed)
            //{
            //    CopyToken();
            //}
            //edge.Close();
        }

        static void CopyToken()
        {
                string url = "https://www.dropbox.com/developers/apps/info/vk3fbzlssw9nsrs#settings";
                ChromeOptions option = new ChromeOptions();
                var service = ChromeDriverService.CreateDefaultService(AppDomain.CurrentDomain.BaseDirectory);
                using (IWebDriver chrome = new ChromeDriver(service, option, TimeSpan.FromMinutes(3)))
                {
                    chrome.Url = url;
                    WebElement l = (WebElement)chrome.FindElement(By.Id("generated-token"));
                    // enter texts
                    l.SendKeys("Selenium");
                    // get value attribute with getAttribute()
                    String val = l.GetAttribute("value");
                    Console.Write("Entered text is: " + val);
                    
                }
            
            //Console.Write("\n\nDone with it!\n\n");
            //Console.ReadLine();
        }

        static void GenerateToken()
        {
            string url = "https://www.dropbox.com/developers/apps/info/vk3fbzlssw9nsrs#settings";
            ChromeOptions option = new ChromeOptions();
            var service = ChromeDriverService.CreateDefaultService(AppDomain.CurrentDomain.BaseDirectory);
            using (IWebDriver chrome = new ChromeDriver(service, option, TimeSpan.FromMinutes(3)))
            {
                chrome.Url = url;
                chrome.FindElement(By.Id("generate-token-button")).Click();
                //edge.FindElement(By.Id("generate-token-button")).Click();
                //edge.FindElement(By.Name("allow_access")).Click();
                Thread.Sleep(5000);

                //edge.Close();
                completed = true;
            }
            

        }

        static void Login()
        {
            string url = "https://www.dropbox.com/developers/apps/info/vk3fbzlssw9nsrs#settings";
            //IWebDriver driver = new ChromeDriver();
            ChromeOptions option = new ChromeOptions();
            var service = ChromeDriverService.CreateDefaultService(AppDomain.CurrentDomain.BaseDirectory);
            using (IWebDriver chrome = new ChromeDriver(service, option, TimeSpan.FromMinutes(3)))
            {
                string username = "office@capital-knowledge.co.jp"; string password = "capitaloo13";
                chrome.Url = url;
                // method Keys.chord
                //String n = OpenQA.Selenium.(OpenQA.Selenium.Keys.Control, OpenQA.Selenium.Keys.Enter);
                chrome.FindElement(By.Name("login_email")).SendKeys(username);
                chrome.FindElement(By.Name("login_password")).SendKeys(password);
                //Thread.Sleep(3000);
                chrome.FindElement(By.XPath("//button[@type='submit']")).Click();
                //chrome.FindElement(By.XPath("//span[@class='login-button signin-button button-primary']")).Click();
                //edge.FindElement(By.Name("allow_access")).Click();
                Thread.Sleep(3000);
                //chrome.Close();
                login = true;
            }
           
        }
    }
}
