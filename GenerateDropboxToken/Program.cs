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
    public class Program
    {
      
        static void Main(string[] args)
        {
            Login();
        }

       

        static void Login()
        {
            string url = "https://www.dropbox.com/developers/apps/info/vk3fbzlssw9nsrs#settings";

            ChromeOptions option = new ChromeOptions();
            var service = ChromeDriverService.CreateDefaultService(AppDomain.CurrentDomain.BaseDirectory);
            IWebDriver chrome = new ChromeDriver(service, option, TimeSpan.FromMinutes(10));

            chrome.Url = url;

            string username = "office@capital-knowledge.co.jp"; string password = "capitaloo13";
            chrome.Url = url;

            Thread.Sleep(3000);
            //// method Keys.chord            
            chrome.FindElement(By.Name("login_email")).SendKeys(username);
            chrome.FindElement(By.Name("login_password")).SendKeys(password);

            Thread.Sleep(10000);
            chrome.FindElement(By.XPath("//button[@type='submit']")).Click();
            Thread.Sleep(200000);
            chrome.FindElement(By.Id("generate-token-button")).Click();
            Thread.Sleep(150000);


            WebElement l = (WebElement)chrome.FindElement(By.Id("generated-token"));
            // enter texts
            l.SendKeys("Selenium");
            // get value attribute with getAttribute()
            String val = l.GetAttribute("value");
            Console.Write("Entered text is: " + val);


        }
    }
}
