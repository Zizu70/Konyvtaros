using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grafikus
{
    
    internal class Adatbazis
    {
        MySqlConnection conn = null;
        MySqlCommand sql = null;
        public Adatbazis()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "";
            builder.Database = "book";  
            builder.CharacterSet = "utf8";
            conn = new MySqlConnection(builder.ConnectionString);
            sql = conn.CreateCommand();
            try
            {
                kapcsolatNyit();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                Environment.Exit(0);
            }
            finally
            {
                    kapcsolatZar();
            }
        }

        
        private void kapcsolatZar()
        {
            if (conn.State != System.Data.ConnectionState.Closed)
            {
                conn.Close();
            }
        }

        private void kapcsolatNyit()
        {
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
        }

        internal List<Book> getAllAuto()
        {
            List<Book> books = new List<Book>();
            sql.CommandText = "SELECT * FROM `books` ORDER BY`marka`";
            try
            {
                kapcsolatNyit();
                using (MySqlDataReader dr = sql.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int Id = dr.GetInt32("id");
                        string Title = dr.GetString("title");
                        string Author = dr.GetString("author");
                        int Publish_year = dr.GetInt32("publish_year");
                        int Page_count = dr.GetInt32("page_count");
                        DateTime  Created_at = dr.GetDateTime(" created_at");
                        DateTime Updated_at = dr.GetDateTime(" update_at");

                        books.Add(new Book(Id, Title, Author, Publish_year, Page_count, Created_at, Updated_at));
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                kapcsolatZar();
            }
            return books;
        }

        internal void updateAuto(Book book)
            {
                try
                {
                    kapcsolatNyit();

                    sql.CommandText = "UPDATE `books` SET `id`=@id,`author`=@author,`publish_year`=@publish_year,`page_count`= @page_count,`created_at`=@created_at,`updated_at`=@updated_at WHERE `title`=@title";

                    sql.Parameters.Clear();

                    
                    sql.Parameters.AddWithValue("@id", book.id);
                    sql.Parameters.AddWithValue("@title", book.title);
                    sql.Parameters.AddWithValue("@author", book.author);
                    sql.Parameters.AddWithValue("@publish_year", book.publish_year);
                    sql.Parameters.AddWithValue("@page_count", book.page_count);
                    sql.Parameters.AddWithValue("@created_at", book.created_at);
                    sql.Parameters.AddWithValue("@updated_at", book.updated_at);

                    sql.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    kapcsolatZar();
                }
            }

        internal void insertAuto(Book book)
        {
            try
            {
                kapcsolatNyit();

                sql.CommandText = "INSERT INTO `books` (`id`, `title` `author`,`publish_year`, `page_count`, `created_at`, `updated_at`) VALUES (@id, @title, @author, @publish_year, @page_count,`@created_at, @updated_at)";

                sql.Parameters.Clear();

                
                sql.Parameters.AddWithValue("@id", book.id);
                sql.Parameters.AddWithValue("@title", book.title);
                sql.Parameters.AddWithValue("@author", book.author);
                sql.Parameters.AddWithValue("@publish_year", book.publish_year);
                sql.Parameters.AddWithValue("@page_count", book.page_count);
                sql.Parameters.AddWithValue("@created_at", book.created_at);
                sql.Parameters.AddWithValue("@updated_at", book.updated_at);

                sql.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                kapcsolatZar();
            }
        }

        internal void deleteAuto(Book book)
        {
            try
            {
                kapcsolatNyit();

                sql.CommandText = "DELETE FROM `books` WHERE `title`= @title";

                sql.Parameters.Clear();

                sql.Parameters.AddWithValue("@rendszam", book.title);

                sql.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                kapcsolatZar();
            }
        }
    }
}
