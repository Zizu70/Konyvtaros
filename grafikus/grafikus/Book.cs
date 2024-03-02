using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grafikus
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
            id = id;
            title = title;
            author = author;
            publish_year = publish_year;
            page_count = page_count;
            created_at = created_at;
            updated_at = updated_at;
        }

        public override string ToString()
        {
            return $"Író: {this.author}\n" + $"Könyv címe: {this.title}\n";
                   
                   
        }
    }
}
