using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Jupiter
{
    class CartTests
    {
        IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
          //  new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver("C:/Users/laila/Downloads/chromedriver_win32");
        }

        [Test]
        public void test1()
        {
            driver.Navigate().GoToUrl("https://jupiter.cloud.planittesting.com/#/");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.LinkText("Start Shopping »")).Click();
            driver.FindElement(By.XPath("//a[@href='#/shop']"));
            System.Threading.Thread.Sleep(5000);
            WebElement liTag = (WebElement)driver.FindElement(By.Id("product-1"));
            liTag.FindElement(By.XPath("//a[text()='Buy']")).Click();
            WebElement liTag1 = (WebElement)driver.FindElement(By.Id("nav-cart"));
            string test = liTag1.FindElement(By.ClassName("cart-count")).Text;
            Assert.AreEqual(test, "1");
        }
        [Test]
        public void test2()
        {
            driver.Navigate().GoToUrl("https://jupiter.cloud.planittesting.com/#/");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.LinkText("Start Shopping »")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//a[@href='#/shop']"));
            WebElement liTag = (WebElement)driver.FindElement(By.Id("product-1"));
            liTag.FindElement(By.XPath("//a[text()='Buy']")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//a[@href='#/cart']")).Click();
            Thread.Sleep(5000);
            string imageText= driver.FindElement(By.XPath("//table/tbody/tr/td[1]")).Text;
            Assert.AreEqual(imageText, "Teddy Bear");
        }
        [Test]
        public void test3()
        {
            driver.Navigate().GoToUrl("https://jupiter.cloud.planittesting.com/#/");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.LinkText("Start Shopping »")).Click();
            driver.FindElement(By.XPath("//a[@href='#/shop']"));
            System.Threading.Thread.Sleep(5000);
            WebElement liTag = (WebElement)driver.FindElement(By.Id("product-1"));
            liTag.FindElement(By.XPath("//a[text()='Buy']")).Click();
            Thread.Sleep(5000);
            liTag.FindElement(By.XPath("//a[text()='Buy']")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//a[@href='#/cart']")).Click();
            Thread.Sleep(5000);
            //WebElement quantityInput = (WebElement)driver.FindElement(By.XPath("//table/tbody/tr/td[2]"));
            WebElement quantityInput = (WebElement)driver.FindElement(By.XPath("//input[@name='quantity']"));
            //WebElement quantityInput = (WebElement)driver.FindElement(By.Name("quantity"));
            string quantity = quantityInput.GetAttribute("value");
            Assert.AreEqual(quantity, "2");
        }
        [Test]
        public void test4()
        {
            driver.Navigate().GoToUrl("https://jupiter.cloud.planittesting.com/#/");
            driver.Manage().Window.Maximize();
            System.Threading.Thread.Sleep(5000);
            driver.FindElement(By.LinkText("Start Shopping »")).Click();
            driver.FindElement(By.XPath("//a[@href='#/shop']"));
            System.Threading.Thread.Sleep(5000);
            WebElement liTag = (WebElement)driver.FindElement(By.Id("product-1"));
            liTag.FindElement(By.XPath("//a[text()='Buy']")).Click();
            Thread.Sleep(5000);
            liTag.FindElement(By.XPath("//a[text()='Buy']")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//a[@href='#/cart']")).Click();
            Thread.Sleep(5000);
            WebElement quantityInput = (WebElement)driver.FindElement(By.XPath("//input[@name='quantity']"));
            string price =driver.FindElement(By.XPath("//table/tbody/tr/td[2]")).Text;
            //string pr = price.ToString();
            price = price.Remove(0, 1);
            double p = double.Parse(price);
            int q = int.Parse(quantityInput.GetAttribute("value"));
            //double p = Convert.ToDouble(pr);
            string total =driver.FindElement(By.XPath("//table/tbody/tr/td[4]")).Text;
            double expectedTotal =p* q;
             string test="$"+expectedTotal.ToString();
            Assert.AreEqual(total, test);
        }
        [Test]
        public void test5()
        {
            driver.Navigate().GoToUrl("https://jupiter.cloud.planittesting.com/#/");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.LinkText("Start Shopping »")).Click();
            driver.FindElement(By.XPath("//a[@href='#/shop']"));
            System.Threading.Thread.Sleep(5000);
            WebElement liTag = (WebElement)driver.FindElement(By.Id("product-1"));
            liTag.FindElement(By.XPath("//a[text()='Buy']")).Click();
            Thread.Sleep(5000);
            liTag.FindElement(By.XPath("//a[text()='Buy']")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//a[@href='#/cart']")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.LinkText("Check Out")).Click();
            driver.FindElement(By.XPath("//a[@href='#/checkout']"));
            Thread.Sleep(5000);
            WebElement forename = (WebElement)driver.FindElement(By.Id("forename"));
            driver.FindElement(By.Id("checkout-submit-btn")).Click();
            Thread.Sleep(5000);
            WebElement errorMsg = (WebElement)driver.FindElement(By.Id("forename-err"));
            string name = forename.GetAttribute("value");
            if (name==null)
            {
                Assert.AreEqual(errorMsg, "forename is required");
            }
        }
        [Test]
        public void test6()
        {
            driver.Navigate().GoToUrl("https://jupiter.cloud.planittesting.com/#/");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.LinkText("Start Shopping »")).Click();
            driver.FindElement(By.XPath("//a[@href='#/shop']"));
            System.Threading.Thread.Sleep(5000);
            WebElement liTag = (WebElement)driver.FindElement(By.Id("product-1"));
            liTag.FindElement(By.XPath("//a[text()='Buy']")).Click();
            Thread.Sleep(5000);
            liTag.FindElement(By.XPath("//a[text()='Buy']")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//a[@href='#/cart']")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.LinkText("Check Out")).Click();
            driver.FindElement(By.XPath("//a[@href='#/checkout']"));
            Thread.Sleep(5000);
            WebElement cardType = (WebElement)driver.FindElement(By.Id("cardType"));
            //WebElement errorMsg = (WebElement)driver.FindElement(By.Id("card-err"));
            string type = cardType.GetAttribute("value");
            string alert = driver.FindElement(By.Id("header-message")).Text;
            string alertexpected = "Almost there -but we can't send your items unless you complete the form correctly.";
            WebElement btn = (WebElement)driver.FindElement(By.Id("checkout-submit-btn"));
            btn.Click();
            Thread.Sleep(5000);
            Assert.AreEqual( alert, alertexpected);
        }
        [Test]
        public void test7()
        {
            driver.Navigate().GoToUrl("https://jupiter.cloud.planittesting.com/#/");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.LinkText("Start Shopping »")).Click();
            driver.FindElement(By.XPath("//a[@href='#/shop']"));
            System.Threading.Thread.Sleep(5000);
            WebElement liTag = (WebElement)driver.FindElement(By.Id("product-1"));
            liTag.FindElement(By.XPath("//a[text()='Buy']")).Click();
            Thread.Sleep(5000);
            liTag.FindElement(By.XPath("//a[text()='Buy']")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//a[@href='#/cart']")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.LinkText("Check Out")).Click();
            driver.FindElement(By.XPath("//a[@href='#/checkout']"));
            Thread.Sleep(5000);
            //WebElement cardType = (WebElement)driver.FindElement(By.Id("cardType"));
            WebElement emailMsg = (WebElement)driver.FindElement(By.Id("email"));
            string email = emailMsg.GetAttribute("value");
            string alert = driver.FindElement(By.Id("header-message")).Text;
            string alertexpected = "Almost there -but we can't send your items unless you complete the form correctly.";
            WebElement btn = (WebElement)driver.FindElement(By.Id("checkout-submit-btn"));
            btn.Click();
            Thread.Sleep(5000);
            email = "lailahotmail.com";
            if (!email.Contains("@"))
            {
                Assert.AreEqual(alert, alertexpected);
            }

        }
        [Test]
        public void test8()
        {
            driver.Navigate().GoToUrl("https://jupiter.cloud.planittesting.com/#/");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.LinkText("Start Shopping »")).Click();
            driver.FindElement(By.XPath("//a[@href='#/shop']"));
            System.Threading.Thread.Sleep(5000);
            WebElement liTag1 = (WebElement)driver.FindElement(By.Id("product-1"));
            liTag1.FindElement(By.XPath("//a[text()='Buy']")).Click();
            System.Threading.Thread.Sleep(5000);
            WebElement liTag2 = (WebElement)driver.FindElement(By.Id("product-2"));
            liTag2.FindElement(By.LinkText("Buy")).Click();
            System.Threading.Thread.Sleep(5000);
            driver.FindElement(By.XPath("//a[@href='#/cart']")).Click();
            Thread.Sleep(5000);
            WebElement emptyBtn=(WebElement)driver.FindElement(By.LinkText("Empty Cart"));
            emptyBtn.Click();
            Thread.Sleep(5000);
            driver.FindElement(By.LinkText("Yes")).Click();
            Thread.Sleep(5000);
            WebElement liTag3 = (WebElement)driver.FindElement(By.Id("nav-cart"));
            string test = liTag3.FindElement(By.ClassName("cart-count")).Text;
            Assert.AreEqual(test, "0");
        }
        [Test]
        public void test9()
        {
            driver.Navigate().GoToUrl("https://jupiter.cloud.planittesting.com/#/");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.LinkText("Start Shopping »")).Click();
            driver.FindElement(By.XPath("//a[@href='#/shop']"));
            System.Threading.Thread.Sleep(5000);
            WebElement liTag1 = (WebElement)driver.FindElement(By.Id("product-1"));
            liTag1.FindElement(By.XPath("//a[text()='Buy']")).Click();
            System.Threading.Thread.Sleep(5000);
            WebElement liTag2 = (WebElement)driver.FindElement(By.Id("product-2"));
            liTag2.FindElement(By.XPath("//a[text()='Buy']")).Click();
            System.Threading.Thread.Sleep(5000);
            driver.FindElement(By.XPath("//a[@href='#/cart']")).Click();
            Thread.Sleep(5000);
            
            WebElement emptyBtn = (WebElement)driver.FindElement(By.LinkText("Empty Cart"));
            emptyBtn.Click();
            Thread.Sleep(5000);
            driver.FindElement(By.LinkText("Yes")).Click();
            Thread.Sleep(5000);
            //int rowCount = driver.FindElements(By.ClassName("cart-item")).Count;
            int itemCount = driver.FindElements(By.ClassName("cart-item)")).Count;
            Assert.AreEqual(itemCount, 0);
           
        }
        [Test]
        public void test10()
        {
            driver.Navigate().GoToUrl("https://jupiter.cloud.planittesting.com/#/");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.LinkText("Start Shopping »")).Click();
            driver.FindElement(By.XPath("//a[@href='#/shop']"));
            System.Threading.Thread.Sleep(5000);
            WebElement liTag1 = (WebElement)driver.FindElement(By.Id("product-1"));
            liTag1.FindElement(By.XPath("//a[text()='Buy']")).Click();
            System.Threading.Thread.Sleep(5000);
            WebElement liTag2 = (WebElement)driver.FindElement(By.Id("product-2"));
            liTag2.FindElement(By.LinkText("Buy")).Click();
            System.Threading.Thread.Sleep(5000);
            driver.FindElement(By.XPath("//a[@href='#/cart']")).Click();
            Thread.Sleep(5000);
            string subtotal1=driver.FindElement(By.XPath("//table/tbody/tr/td[4]")).Text;
            subtotal1 = subtotal1.Remove(0, 1);
            double sub1 = double.Parse(subtotal1);
            string subtotal2 = driver.FindElement(By.XPath("//table/tbody/tr[2]/td[4]")).Text;
            subtotal2 = subtotal2.Remove(0, 1);
            double sub2 = double.Parse(subtotal2);
            double totalExpected =Math.Round((sub1 + sub2),2);
            string total = driver.FindElement(By.XPath("//table/tfoot/tr[1]/td")).Text;
            total = total.Remove(0, 7);
            double tot = double.Parse(total);
            Assert.AreEqual(totalExpected, tot);
        }

            [TearDown]
        public void closeBrowser()
        {
            //driver.Close();
        }
    }
}
