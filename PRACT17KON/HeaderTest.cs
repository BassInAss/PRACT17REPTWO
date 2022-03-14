using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Chromium;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PRACT17KON
{
    [TestFixture]
    public class HeaderTest
    {
        [TestCase]
        public void MainTitle()
        {
            IWebDriver webDriver = new ChromeDriver();
            webDriver.Url = "https://esia.gosuslugi.ru/login/";
            Assert.AreEqual("Портал государственных услуг Российской Федерации", webDriver.Title);
            ///html/body/esia-root/div/esia-idp/div/div[1]/form/div[4]/button
            webDriver.Close();
        }
    }
}
