using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.TESTS
{
    internal class RegisterTest
    {

        public IWebDriver Driver { get; private set; }


        [Test]
        public void RegisterMethod()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("http://demo.automationtesting.in/Index.html");

            //validam pagina, verificam daca suntem pe Index
            //In exemplul de mai jos mesajul apare doar in caz de eroare
            string expectedIndexPage = "Index";
            string actualIndexPage = Driver.Title;
            Assert.AreEqual(expectedIndexPage, actualIndexPage, "Pagina Index nu a aparut.");

            //Identificam Skip SignIn button
            IWebElement signInElement = Driver.FindElement(By.Id("btn2"));
            signInElement.Click();

            //validam pagina, verificam daca suntem pe Register
            string expectedSignInPage = "Register";
            string actualSignInPage = Driver.Title;
            Assert.AreEqual(expectedSignInPage, actualSignInPage, "Pagina de Register nu a aparut.");

            //First Name
            IWebElement firstNameElement = Driver.FindElement(By.CssSelector("input[placeholder = 'First Name']"));
            firstNameElement.SendKeys("Alex");
            //Last Name
            IWebElement lastNameElement = Driver.FindElement(By.CssSelector("input[placeholder = 'Last Name']"));
            lastNameElement.SendKeys("Dorha");
            //Address
            IWebElement addressElement = Driver.FindElement(By.CssSelector("textarea[ng-model = 'Adress']"));
            addressElement.SendKeys("V.G. Paleolog, Nr.4");
            //EmailAddress
            IWebElement emailAddressElement = Driver.FindElement(By.CssSelector("input[type='email']"));
            emailAddressElement.SendKeys("vlad@yahoo.com");
            //Phone
            IWebElement phoneElement = Driver.FindElement(By.CssSelector("input[type='tel']"));
            phoneElement.SendKeys("0737668555");
            //Gender
            IWebElement genderElement = Driver.FindElement(By.CssSelector("input[value = 'Male']"));
            genderElement.Click();
            //Hobbies
            IWebElement hobbiesElement = Driver.FindElement(By.Id("checkbox2"));
            hobbiesElement.Click();


            //Schimbam focusul
            //Actions se foloseste si pentru actiuni la nivel de mouse (click stanga/dreapta)

            IWebElement submitElement = Driver.FindElement(By.Id("submitbtn"));
            Actions actionsElement = new Actions(Driver);
            actionsElement.MoveToElement(submitElement).Perform();
            



            //Interactionam cu dropdown-uri

            //Languages
            IWebElement languageElement = Driver.FindElement(By.Id("msdd"));
            languageElement.Click();
            var languagesValues = Driver.FindElements(By.CssSelector(".ui-autocomplete.ui-front>li>a"));
            string expectedLanguage = "Spanish";
            foreach (var element in languagesValues) 
            {
                if(element.Text.Equals(expectedLanguage))
                {
                    element.Click();
                    break;
                }
            }
            //Dam click oriunde pt a lua focusul de la dropdown
            firstNameElement.Click();
            //Verificam daca s-a selectat valoare pe care noi am alss-o mai sus
            IWebElement selectedLanguageValue = Driver.FindElement(By.CssSelector("#msdd>div"));
            Assert.IsTrue(expectedLanguage.Equals(selectedLanguageValue.Text));

           











            //Skills dropdown
            IWebElement skillsDropdownElement = Driver.FindElement(By.Id("Skills"));
            SelectElement skillsDropdown = new SelectElement(skillsDropdownElement);
            skillsDropdown.SelectByText("Android");


            //Select Country

            IWebElement selectCountryElement = Driver.FindElement(By.CssSelector(".select2-selection--single"));
            selectCountryElement.Click();
            IWebElement inputSelectCountry = Driver.FindElement(By.CssSelector(".select2-search__field"));
            inputSelectCountry.SendKeys("India");
            inputSelectCountry.SendKeys(Keys.Enter);




            //Date of birth dropdown
            //year
            IWebElement yearDropdownElement = Driver.FindElement(By.Id("yearbox"));
            SelectElement yearDropdown = new SelectElement(yearDropdownElement);
            yearDropdown.SelectByValue("1989");
            //month
            IWebElement monthDropdownElement = Driver.FindElement(By.CssSelector("select[ng-model='monthbox']"));
            SelectElement monthDropdown = new SelectElement(monthDropdownElement);
            monthDropdown.SelectByValue("July");
            //Day
            IWebElement dayDropdownElement = Driver.FindElement(By.Id("daybox"));
            SelectElement dayDropdown = new SelectElement(dayDropdownElement);
            dayDropdown.SelectByValue("30");








            //Password
            IWebElement passwordElement = Driver.FindElement(By.Id("firstpassword"));
            passwordElement.SendKeys("Parolamea");
            //Confirm Password
            IWebElement cpasswordElement = Driver.FindElement(By.Id("secondpassword"));
            cpasswordElement.SendKeys("Parolamea");




            //Inchidem pagina browser-ul. 
            //Quit  - inchide browser-ul
            //Close - inchide doar tab-ul curent

            //Driver.Quit();











        }
    }
}