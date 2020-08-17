using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace PriceBey.PriceUpdater
{
    public class DownloadHTML
    {
        public static string WebDriver(string url)
        {
            var html = string.Empty;

            var chromeOptions = new ChromeOptions();
            //chromeOptions.AddArguments("headless");

            IWebDriver driver = new ChromeDriver(chromeOptions);

            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(40);

            driver.Url = url;

            System.Threading.Thread.Sleep(3000);

            html = driver.PageSource;

            System.Threading.Thread.Sleep(1000);

            driver.Close();
            driver.Quit();

            return html;

        }

        public static string Client(string url)
        {
            var html = string.Empty;

            WebClient client = new WebClient();

            client.Headers.Add("user-agent", "Other");

            html = client.DownloadString(url);

            return html;

        }

        public static decimal StringToDecimal(string text)
        {
            decimal number = 0;

            try
            {
                text = text.ToUpper().Trim().Trim('.').Replace("PKR", "").Replace("RS.", "").Replace("RS", "").Replace(".00","")
                    .Replace("/-","").Trim().Replace(",", "").Replace(" ", "");

                Decimal.TryParse(text, out number);

                return number;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}