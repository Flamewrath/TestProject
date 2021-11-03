using System.IO;
using System.Net;
using System.Xml;
using System.Collections.Generic;
using System;

namespace RssLibrary
{
    public static class Rss
    {
        public class News
        {
            public News(string titleIn, string descrIn, string urlFileIn,
                int newsNum)
            {
                Title = titleIn;
                Descr = descrIn;
                UrlFile = urlFileIn;
                using (var client = new WebClient())
                {
                    Picture = client.DownloadData(UrlFile);
                }
                GroupTitle = $"Новость {newsNum + 1}";
                Id = Guid.NewGuid();
                // из-за отсутствия Bitmap FileStream в .NET 5.0, воспользуемся guid, чтоб не лочить файл
                PicturePath = Path.GetTempPath() + Id;

                File.WriteAllBytes(PicturePath, Picture);
            }
            //
            public Guid Id { get; }
            // Заголоовок статьи
            public string Title { get; }
            // Название для групбокса
            public string GroupTitle { get; }
            // Первый абзац статьи
            public string Descr { get; }
            // Ссылка на файл
            public string UrlFile { get; }
            // Картинка статьи (в массиве байтов)
            public byte[] Picture { get; }
            // Путь к картинке во временной папке
            public string PicturePath { get; }

            [Obsolete]
            public string SendCliNewsData()
            {
                string pictureData = String.Empty;
                for (int i = 0; i < Picture.Length; i++)
                {
                    pictureData += Picture[i].ToString();
                }
                return Title + ". " + Descr + " " +
                    UrlFile + ":" + Picture;
            }
        }
        public static List<News> GetNews()
        {
            List<News> news = new();
            string temp = Path.GetTempPath() + "rss.xml";
            using (var client = new WebClient())
            {
                client.DownloadFile("https://lenta.ru/rss", temp);
            }
            XmlDocument doc = new();
            doc.Load(temp);
            XmlNodeList nodeList = doc.SelectNodes("/rss/channel/item");
            for (int i = 0; i < 3; i++)
            {
                news.Add(new News(nodeList[i].SelectSingleNode("title").InnerText,
                    nodeList[i].SelectSingleNode("description").InnerText,
                    nodeList[i].SelectSingleNode("enclosure").Attributes["url"].Value,
                    i));
            }
            return news;
        }
    }
}
