using ComputerSystemIntegration.Domain.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ComputerSystemIntegration.DataRetriver
{
    public class Crawler
    {
        public IEnumerable<News> Crawl()
        {
            string homeUrl = "https://djinni.co/jobs/?location=%D0%9B%D1%8C%D0%B2%D0%BE%D0%B2&primary_keyword=.NET";
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--headless");

            IWebDriver driver = new ChromeDriver(@"C:\Users\zhere\OneDrive\Документи\GitHub", chromeOptions);
            driver.Navigate().GoToUrl(homeUrl);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(d => d.FindElement(By.CssSelector(".page-header h1")));

            var elements = driver.FindElements(By.CssSelector(".list-jobs__item"));

            List<News> news = elements
                .Select(el => new News
                {
                    Description = el.FindElement(By.CssSelector(".list-jobs__description")).GetAttribute("content"),
                    Title = el.FindElement(By.CssSelector(".list-jobs__title")).GetAttribute("content"),
                    PublishDate = el.FindElement(By.CssSelector(".inbox-date pull-right")).GetAttribute("content"),
                    //  el.GetAttribute("href")
                    Author = el.FindElement(By.CssSelector(".list-jobs__details a")
                }).ToList();

            //for (int i = 0; i < news.Count; i++)
            //{
            //    Thread.Sleep(TimeSpan.FromSeconds(5));
            //    var n = news[i];
            //    try
            //    {
            //        driver.Navigate().GoToUrl(n.Url);
            //        wait.Until(d => d.FindElement(By.CssSelector(".c-page-title")));

            //        n.Author = driver.FindElement(By.CssSelector("meta[property^=author]")).GetAttribute("content");
            //        n.Description = driver.FindElement(By.CssSelector("meta[name^=description]")).GetAttribute("content");
            //        n.PublishDate = DateTime.Parse(driver.FindElement(By.CssSelector("meta[property^=\"article:published_time\"]")).GetAttribute("content"));
            //    }
            //    catch (Exception)
            //    {
            //        //log exception
            //    }
            //    yield return n;
            //}
            driver.Close();
            return news;

           
        }
    }
}
