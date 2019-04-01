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
            string homeUrl = "";
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--headless");

            IWebDriver driver = new ChromeDriver(chromeOptions);
            driver.Navigate().GoToUrl(homeUrl);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(d => d.FindElement(By.CssSelector(".p-page-title ")));

            var elements = driver.FindElements(By.CssSelector(".c-entry-box--compact__title a"));

            List<News> news = elements
                .Select(el => new News
                {
                    Title = el.Text,
                    Url = el.GetAttribute("href")
                })
                .ToList();

            for (int i = 0; i < news.Count; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(5));
                var n = news[i];
                try
                {
                    driver.Navigate().GoToUrl(n.Url);
                    wait.Until(d => d.FindElement(By.CssSelector(".c-page-title")));

                    n.Author = driver.FindElement(By.CssSelector("meta[property^=author]")).GetAttribute("content");
                    n.Description = driver.FindElement(By.CssSelector("meta[name^=description]")).GetAttribute("content");
                    n.PublishDate = DateTime.Parse(driver.FindElement(By.CssSelector("meta[property^=\"article:published_time\"]")).GetAttribute("content"));
                }
                catch (Exception)
                {
                    //log exception
                }
                yield return n;
            }

            driver.Close();
        }
    }
}
