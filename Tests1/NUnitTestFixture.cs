using NUnit.Framework;
using OpenQA.Selenium;
using System.Linq;


namespace Tests1
{
    [TestFixture]
    public class NUnitTestFixture
    {
        IWebDriver driver;
        [Test]
        public void Test()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://www.yandex.ru");
            driver.Manage().Window.Maximize();
            var marketButton = driver.FindElement(By.XPath("//div[text()='Маркет']"));
            marketButton.Click();
            driver.SwitchTo().Window(driver.WindowHandles.ToList().Last());
            IWebElement findtext = driver.FindElement(By.XPath("//input[@class='nQ8aBP7fBN']"));
            findtext.SendKeys("ноутбук xiaomi redmibook");
            var find = driver.FindElement(By.XPath("//button[@type='submit']"));
            find.Click();
            System.Threading.Thread.Sleep(500);
            var check = driver.FindElement(By.XPath("//span[@class='NVoaOvqe58']"));
            if (!check.Selected)
            {
                check.Click();
            }
            System.Threading.Thread.Sleep(1000);
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("Test.jpg", ScreenshotImageFormat.Jpeg);
            
        }
    }
}

