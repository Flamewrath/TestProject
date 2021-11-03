using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;
using RssLibrary;
using System;

namespace RssWindows
{
    public partial class MainWindow : Window
    {
        private List<Rss.News> news = new();
        public MainWindow()
        {
            InitializeComponent();
            RefreshNews();
        }

        private void RefreshNews()
        {
            news = Rss.GetNews();
            NewsIC.ItemsSource = news;
        }

        private void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            NewsIC.ItemsSource = null;
            news.Clear();
            RefreshNews();
        }

        private void ExitApp_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void UploadToDatabase_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(Properties.Resources.SqlConnectionString);
            SqlCommand cmd = new();
            try
            {
                cmd.Connection = conn;
                cmd.CommandText = @"INSERT INTO RssNews VALUES (@id, @title, @descr, @pict, @modified)";
                cmd.Connection.Open();
                foreach (Rss.News n in news)
                {
                    cmd.Parameters.Add("id", System.Data.SqlDbType.UniqueIdentifier).Value = n.Id;
                    cmd.Parameters.Add("title", System.Data.SqlDbType.VarChar).Value = n.Title;
                    cmd.Parameters.Add("descr", System.Data.SqlDbType.VarChar).Value = n.Descr;
                    cmd.Parameters.Add("pict", System.Data.SqlDbType.VarBinary).Value = n.Picture;
                    cmd.Parameters.Add("modified", System.Data.SqlDbType.DateTime).Value = DateTime.Now;
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                MessageBox.Show("Данные сохранены!");
            }
            catch(SqlException ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных в БД: {ex.Message}");
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
        }
    }
}
