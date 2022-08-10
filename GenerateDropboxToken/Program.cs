using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            try
            {
                Thread.Sleep(10000);
                chrome.Url = url;
                Thread.Sleep(10000);
                string username = "office@capital-knowledge.co.jp"; string password = "capitaloo13";

                Thread.Sleep(10000);
                chrome.FindElement(By.Name("login_email")).SendKeys(username);
                Thread.Sleep(10000);
                chrome.FindElement(By.Name("login_password")).SendKeys(password);

                Thread.Sleep(200000);
                chrome.FindElement(By.XPath("//button[@type='submit']")).Click();
                Thread.Sleep(200000);
                chrome.FindElement(By.Id("generate-token-button")).Click();
                Thread.Sleep(20000);
                WebElement l = (WebElement)chrome.FindElement(By.Id("generated-token"));
                // enter texts
                l.SendKeys("Selenium");
                // get value attribute with getAttribute()
                String val = l.GetAttribute("value");
                String path = @"C:\Backup\Dbpath.ini";
                //System.IO.File.WriteAllText(path, System.IO.File.ReadAllText(path).Replace("TokenKey=", "TokenKey=[" + val + "]"));
                string text = System.IO.File.ReadAllText(path).Replace("TokenKey=", "TokenKey=[" + val + "] ");
                string[] token = text.Split(' ');
                System.IO.File.WriteAllText(path, token[0]);
                Console.Write("Entered text is: " + val);
                chrome.Close();
                UpdateToken(val);
                chrome.Quit();
                //chrome.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Thread.Sleep(5000);
                chrome.Close();
                chrome.Quit();
            }
           
        }
        static void UpdateToken(String val)
        {
           try
            {
                DateTime datetime = DateTime.Now;
                SqlConnection Connection = new SqlConnection();
                Connection.ConnectionString = "Data Source=203.137.52.23;Initial Catalog=CapitalSMS;Persist Security Info=True;User ID=sa;Password=admin123456!;Connection Timeout=60000";
                SqlCommand myCommand = new SqlCommand("UPDATE P_Resource SET DropboxAPIToken = @token,UpdateDateTime=@datetime", Connection);
                Connection.Open();
                myCommand.Parameters.AddWithValue("@token", val);
                myCommand.Parameters.AddWithValue("@datetime", datetime);
                myCommand.ExecuteNonQuery();
                Connection.Close();
            }
            catch(Exception ex)
            { 
                Console.WriteLine(ex.ToString());
            }
        }

    }
}
