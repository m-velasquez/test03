using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using OpenQA.Selenium.Support.UI;

namespace SeleniumFinders
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new FirefoxDriver();
            //Findings(driver);
            driver.Url = @"C:\SeleniumDemos\SeleniumFinders\SeleniumFinders\HTMLAdvanced.html";

            //RadioButtonExample(driver);
            //CheckBoxExample(driver);
            SelectItem(driver);
        }

        private static void SelectItem(IWebDriver driver)
        {            
            var select = driver.FindElement(By.Id("select1"));

            var selectItem = new SelectElement(select);
            selectItem.SelectByText("Tom");

        }

        private static void CheckBoxExample(IWebDriver driver)
        {
            var checkBox = driver.FindElement(By.Id("check1"));
            if (!checkBox.Selected)
            {               
                Console.WriteLine(checkBox.GetAttribute("value"));
                checkBox.Click();
            }
        }

        private static void RadioButtonExample(IWebDriver driver)
        {
            var radioButton = driver.FindElements(By.Name("color"));
            foreach (var item in radioButton)
            {
                if (item.Selected)
                {
                    Console.WriteLine(item.GetAttribute("value"));
                    break;
                }
            }
        }

        private static void Findings(IWebDriver driver)
        {
            driver.Url = @"C:\SeleniumDemos\SeleniumFinders\SeleniumFinders\HTMLDemo.html";
            //ClassName
            var elements = driver.FindElements(By.ClassName("cheese"));
            foreach (var item in elements)
            {
                Console.WriteLine(item.Text);
            }
            //TagName
            var iframe = driver.FindElement(By.TagName("iframe"));
            Console.WriteLine(iframe.Text);

            //LinkText
            var linkText = driver.FindElement(By.LinkText("Demo"));
            linkText.Click();

            Console.WriteLine(driver.Title);


            //Back
            driver.Navigate().Back();
            Thread.Sleep(2000);

            //Open browser
            driver.Url = @"C:\SeleniumDemos\SeleniumFinders\SeleniumFinders\HTMLDemo.html";
            //Partial LinkText
            var plinkText = driver.FindElement(By.PartialLinkText("cheese"));
            plinkText.Click();

            //Back
            driver.Navigate().Back();

            //driver.FindElement(By.CssSelector("#food span.dairy.aged"));

            //Close driver
            driver.Quit();
        }
    }
}
