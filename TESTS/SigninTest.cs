using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.TESTS
{
    internal class SigninTest
    {
        public IWebDriver Driver { get; private set; }


        [Test]
        public void TestSignInMethod()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("http://demo.automationtesting.in/Index.html");

            //validam pagina, verificam daca suntem pe Index
            //In exemplul de mai jos mesajul apare doar in caz de eroare
            string expectedIndexPage = "Index";
            string actualIndexPage = Driver.Title;
            Assert.AreEqual(expectedIndexPage, actualIndexPage, "Pagina Index nu a aparut.");


            //Identificam Sign In button
            IWebElement signInElement = Driver.FindElement(By.Id("btn1"));
            signInElement.Click();
       
            //validam pagina, verificam daca suntem pe SignIn 
            string expectedSignInPage = "SignIn";
            string actualSignInPage = Driver.Title;
            Assert.AreEqual(expectedSignInPage, actualSignInPage, "Pagina LogIn nu a aparut.");


            //Varianta cu CSS Selector pentru identificarea field-ului pt User/e mail
            IWebElement emailElement = Driver.FindElement(By.CssSelector("input[placeholder= 'E mail']"));
            //Varianta cu Xpath
            //IWebElement emailElement = Driver.FindElement(By.Xpath("//input[@placeholder='E mail']"));
            string emailValue = "Alexandra.str@gmail.com";
            emailElement.SendKeys(emailValue);

            IWebElement paswordElement1 = Driver.FindElement(By.CssSelector("input[placeholder='Password']"));
            string pwValue = "anaaremere";
            paswordElement1.SendKeys(pwValue);

            IWebElement enterElement1 = Driver.FindElement(By.Id("enterbtn"));
            enterElement1.Click();

            //validam mesajul de eroare pt user/password invalide
            IWebElement errorMessageElement = Driver.FindElement(By.Id("errormsg"));
            string expectedMessage = "Invalid User Name or PassWord";
            string actualMessage = errorMessageElement.Text;
            Assert.AreEqual(expectedMessage, actualMessage, "Mesajele sunt diferite.");


            //Inchidem pagina browser-ul. 
            //Quit  - inchide browser-ul
            //Close - inchide doar tab-ul curent

            Driver.Quit();



        }

    }
}
