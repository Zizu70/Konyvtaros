using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konzolos
{
    internal class Statisztika
    {
        public static List<Book> bookList = new List<Book>();
        static MySqlConnection conn = null;
        static MySqlCommand comm = null;
        public Statisztika()
        {

        }
        public static void beolvas()
        {
            MySqlConnectionStringBuilder sb = new MySqlConnectionStringBuilder();
            sb.Clear();
            sb.Server = "localhost";
            sb.UserID = "root";
            sb.Password = "";
            sb.Database = "book";
            sb.CharacterSet = "utf8";
            conn = new MySqlConnection(sb.ConnectionString);
            comm = conn.CreateCommand(); //
            try
            {
                conn.Open();
                //
                comm.CommandText = "SELECT * FROM `books`";
                using (MySqlDataReader dr = comm.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int id = dr.GetInt32("id");
                        string title = dr.GetString("title");
                        string author = dr.GetString("author");
                        int publishYear = dr.GetInt32("publish_year");
                        int pageCount = dr.GetInt32("page_count");
                        DateTime created_at = dr.GetDateTime("created_at");
                        DateTime updated_at = dr.GetDateTime("updated_at");

                        Book uj = new Book(id, title, author, publishYear, pageCount, created_at, updated_at);

                        bookList.Add(uj);


                    }
                }
                conn.Close();
                Console.WriteLine("\n***** Beolvasás megtörtént *****\n");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("\n----- SIKERTELEN BEOLVASÁS! -----\n");
                //Environment.Exit(0);
            }

        }

        public static void kiir()
        {
            foreach (Book item in bookList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n***** Kiiratás megtörtént *****\n");
        }

        public static void oldalSzam()
        {

            int db = bookList.FindAll(a => a.page_count > 500).Count;
            Console.WriteLine($"500 oldalnál hosszabb könyvek száma: {db}");
        }

        public static void regi()
        {
            var regi = bookList.Find(a => a.publish_year < 1950);
            if (regi == null)
            {
                Console.WriteLine("Nincs 1950-nél régebbi könyv");
            }
            else
            {
                Console.WriteLine("Van 1950-nél régebbi könyv");
            }
        }

        public static void leghosszabb()
        {

            Console.WriteLine("A leghosszabb könyv:");
            int maxOldal = bookList.Max(a => a.page_count);
            foreach (Book item in bookList.FindAll(a => a.page_count == maxOldal))
            {
                Console.WriteLine($"\tSzerző: {item.author}");
                Console.WriteLine($"\tCím: {item.title}");
                Console.WriteLine($"\tKiadás éve: {item.publish_year}");
                Console.WriteLine($"\tOldalszám: {item.page_count}");
            }

        }

        public static void legtobb()
        {
            var iro = bookList.GroupBy(a => a.author).Select(b => new { iro = b.Key, db = b.Count() }).OrderByDescending(c => c.db).First().iro;
            Console.WriteLine($"A legtöbb könyvvel rendelkező szerző: {iro}");


        }

        /*public static void megadas(string title)
        {
            Console.Write("Adjon meg egy könyv címet: ");
            string title = Console.ReadLine();
            //return kolcsonzesek.FindAll(a => a.Title.Equals(cim)).Count();

            if (title != null)
            {
                Console.WriteLine($"A(z) megadott könyv szerzője: {bookList.author}");
            }
            else
            {
                Console.WriteLine("Nincs ilyen könyv az adatok között.");
            }
        }*/
    }
}
