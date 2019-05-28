using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace MyClassKpiz

{
    [TestFixture]
    public class Class1
    {
        public IWebDriver driver;
        [SetUp]
        public void SetUp()
        {
            var options = new ChromeOptions();
            options.AddArguments
                (
                    "--start-maximized",
                    "--disable-extensions",
                    "--disable-notifications",
                    "--disable-application-cache"
                );
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("https://www.goldtoe.com/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            IWebElement LogIn = driver.FindElement(By.PartialLinkText("Sign In/Register"));
            LogIn = LogIn.FindElement(By.XPath("./parent::*"));
            try
            {
                IWebElement Ad = driver.FindElement(By.Id("popup-subcription-closes-icon-85d6dd11-dc2e-4949-bd75-0a9ec85091bf"));
                Ad.Click();
            }
            catch { }
            System.Threading.Thread.Sleep(1000);
            LogIn.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement email = driver.FindElement(By.XPath("//*[@id='main']/div[1]/form/div[1]/div/input"));
            email.SendKeys("Vasiliy_Fatyuk@hotmail.com");
            IWebElement password = driver.FindElement(By.XPath("//*[@id='main']/div[1]/form/div[2]/div/input"));
            password.SendKeys("Qwertyuiop1@");
            IWebElement SingInButton = driver.FindElement(By.XPath("//*[@id='main']/div[1]/form/div[3]/div[2]/button"));
            SingInButton.Click();
        }

        [TearDown]
        public void TearDown()
        {
            System.Threading.Thread.Sleep(1000);
            IWebElement UserButton = driver.FindElement(By.XPath("//*[@id='top-tools-div']/ul/li[2]/a"));
            UserButton.Click();
            System.Threading.Thread.Sleep(1000);
            IWebElement LogOut = driver.FindElement(By.XPath("//*[@id='top-tools-div']/ul/li[2]/ul/li[9]/a"));
            LogOut.Click();
        }


        [Test]
        public void AddProductToTheShoppingCart() 
        {
            System.Threading.Thread.Sleep(4000);
            IWebElement ShopMens = driver.FindElement(By.XPath("//*[@id=\"homepg-banner-us\"]/div[1]/div[1]/div[3]/div/a/img[1]"));
            ShopMens.Click();
            System.Threading.Thread.Sleep(13000);
            IWebElement ShopSocks = driver.FindElement(By.XPath("//*[@id=\"grid\"]/div[5]/div/div[4]/div[2]/a"));
            ShopSocks.Click();
            System.Threading.Thread.Sleep(2000);
            IWebElement AddToCard = driver.FindElement(By.XPath("//*[@id=\"modal-quickview\"]/div/div[3]/div[2]/div/div[2]/form/div[2]/div[1]/button"));
            AddToCard.Click();
            System.Threading.Thread.Sleep(2000);
            IWebElement AddItems = driver.FindElement(By.XPath("//*[@id=\"header\"]/div/div/div[2]/a/i"));
            AddItems.Click();
            System.Threading.Thread.Sleep(1000);
            IWebElement IconCart = driver.FindElement(By.XPath("//*[@id=\"minicart-wrapper\"]/a/i"));
            IconCart.Click();
            System.Threading.Thread.Sleep(1000);
            IWebElement ViewCart = driver.FindElement(By.XPath("//*[@id=\"minicart\"]/div[2]/div[2]/button"));
            ViewCart.Click();

            System.Threading.Thread.Sleep(1000);
            Boolean alert = false;
            try
            {
                IWebElement alerttext = driver.FindElement(By.XPath("//*[@id=\"main\"]/div[8]/ol/li/div[2]/div[1]"));
                alert = true;

            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
                driver.Quit();
            }
            Assert.AreEqual(alert, true);

            System.Threading.Thread.Sleep(5000);
            IWebElement RemoveButton = driver.FindElement(By.XPath("//*[@id=\"main\"]/div[8]/ol/li/div[6]/button[3]"));
            RemoveButton.Click();
            Assert.AreEqual("", "");
        }
    }
}