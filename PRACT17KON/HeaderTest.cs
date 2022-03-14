using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Chromium;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace PRACT17KON
{
    [TestFixture]
    public class HeaderTest
    {
        IWebDriver webDriver = new ChromeDriver();
        [TestCase]
        public void MainTitle()
        {
            webDriver.Url = "https://esia.gosuslugi.ru/login/";
            Assert.AreEqual("Портал государственных услуг Российской Федерации", webDriver.Title);
            webDriver.Close();
        }
        [TestCase]
        public void NameButton()
        {
            webDriver.Url = "https://esia.gosuslugi.ru/login/";
            if (IsLoaded("html/body/esia-root/div/esia-idp/div/div[1]/form/div[4]/button"))
            {
                IWebElement input = webDriver.FindElement(By.XPath("html/body/esia-root/div/esia-idp/div/div[1]/form/div[4]/button"));
                Assert.AreEqual("Войти", input.Text);
            }
            webDriver.Close();
        }
        [TestCase]
        public void IsLogAndPass()
        {
            webDriver.Url = "https://esia.gosuslugi.ru/login/";
                IWebElement button = webDriver.FindElement(By.XPath("html/body/esia-root/div/esia-idp/div/div[1]/form/div[4]/button"));
                button.Click();
                IWebElement str = webDriver.FindElement(By.XPath("/html/body/esia-root/div/esia-idp/div/div[1]/form/div[2]/esia-input-password/div/div"));
                Assert.IsTrue(str.Displayed == true);
            webDriver.Close();
        }
        public bool IsLoaded(string XPath)
        {
            var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, 30));
            //установка условия окончания ожидания
            var element = wait.Until(condition =>
            {
                try
                {
                    //до тех пор, пока указанный элемент не станет видим (Displayed == true)
                    var elementToBeDisplayed =
                        webDriver.FindElement(By.XPath("/html/body/table/tbody/tr[2]/td/form/div[2]/button"));
                    return elementToBeDisplayed.Displayed;
                }
                //в случае, если такого элемента нет
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
            return element;
        }
    }
}
