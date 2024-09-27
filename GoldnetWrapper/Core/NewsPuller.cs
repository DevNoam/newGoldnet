using GoldnetWrapper.Core.Properties;
using System;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Text.Json;

namespace GoldnetWrapper.Core
{
    internal class NewsPuller
    {

        static string GetDataFromAPI()
        {
            string url = ReadOnlyVariables.newsJsonWebsite;
            string data = string.Empty;
            try
            {
                WebClient client = new WebClient();
                client.Encoding = Encoding.UTF8;
                data = client.DownloadString(ReadOnlyVariables.newsJsonWebsite);
            }catch (Exception){}
            //Json variable changer
            data = data.Replace("{DATE}", DateTime.Now.ToString("d"));
            data = data.Replace("{TIME}", DateTime.Now.ToString("t"));
            data = data.Replace("{DATETIME}", DateTime.Now.ToString("g"));

            return data;
        }

        public static NewsObject PullLatestNews()
        {
            string data = GetDataFromAPI();

            NewsResponse newsResponse = null;

            try
            {
                newsResponse = JsonSerializer.Deserialize<NewsResponse>(data);
            }
            catch (Exception)
            {

                Helpers.UpdateStatus("Failed to fetch news");
            }


            return newsResponse?.news.Length > 0 ? newsResponse.news[0] : null; 
        }

        // Pull all news into an array
        public static NewsObject[] PullAllNews()
        {
            string data = GetDataFromAPI();

            NewsResponse newsResponse = null;
            try
            {
                newsResponse = JsonSerializer.Deserialize<NewsResponse>(data);
            }
            catch (Exception)
            {
                Helpers.UpdateStatus("Failed to fetch news");
            }

            return newsResponse?.news; 
        }

    }
}
