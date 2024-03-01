using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konzolos
{
    internal class Book
    {

        public int id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public int publish_year { get; set; }
        public int page_count { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

        public Book(int id, string title, string author, int publish_year, int page_count, DateTime created_at, DateTime updated_at)
        {
            this.id = id;
            this.title = title;
            this.author = author;
            this.publish_year = publish_year;
            this.page_count = page_count;
            this.created_at = created_at;
            this.updated_at = updated_at;
        }

        public override string ToString()
        {
            return $"Id: {this.id}\n" +
                   $"Könyv címe: {this.title}\n" +
                   $"Író: {this.author}\n" +
                   $"Kiadás éve: {this.publish_year}\n" +
                   $"Oldalak száma: {this.page_count}\n";
        }
    }
}
