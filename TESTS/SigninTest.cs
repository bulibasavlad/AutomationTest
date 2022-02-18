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

            //Identificam Sign In button
            IWebElement signInElement = Driver.FindElement(By.Id("btn1"));
            signInElement.Click();
            
            //Varianta cu CSS Selectorpentru identificarea field-ului pt User/e mail
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


            
        }


    }
}
