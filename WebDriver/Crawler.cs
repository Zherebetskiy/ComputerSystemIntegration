using ComputerSystemIntegration.Domain.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ComputerSystemIntegration.DataRetriver
{
    public class Crawler
    {
        static readonly string englishLanguageUrl = "https://djinni.co/set_lang?code=en&next=/jobs/";
        static readonly string dotNetJobFilterUrl = "https://djinni.co/jobs/?primary_keyword=.NET";

        public IEnumerable<Vacancy> Crawl()
        {
            
            string homeUrl = "https://djinni.co/jobs/?location=%D0%9B%D1%8C%D0%B2%D0%BE%D0%B2&primary_keyword=.NET";
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--headless");

            IWebDriver driver = new ChromeDriver(@"C:\Users\zhere\OneDrive\Документи\GitHub", chromeOptions);
            driver.Navigate().GoToUrl(homeUrl);

           // ChangeLanguageToEnglish(driver);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(d => d.FindElement(By.CssSelector(".page-header h1")));

            var elements = driver.FindElements(By.CssSelector("li.list-jobs__item"));

            List<Vacancy> news = elements
                .Select(el => new Vacancy
                {
                    Description = el.FindElement(By.CssSelector(".list-jobs__description p")).Text,
                    Title = el.FindElement(By.CssSelector(".list-jobs__title a")).Text,
                    PublishDate = el.FindElement(By.CssSelector(".inbox-date.pull-right")).Text,
                    Author = GetAuthorName(el)
                }).ToList();

            driver.Close();
            return news;
        }

        private static string GetAuthorName(IWebElement element)
        {
            return element.FindElements(By.CssSelector(".list-jobs__details a"))[1].Text;
        }

        private static void ChangeLanguageToEnglish(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(englishLanguageUrl);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(d => d.FindElement(By.CssSelector(".page-header h1")));

            driver.Navigate().GoToUrl(dotNetJobFilterUrl);
        }
    }
}
