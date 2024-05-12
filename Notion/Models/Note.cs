using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notion.Models
{
    public class Note
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }

        public Note()
        {
            ID = 0;
            Title = string.Empty;
            Content = string.Empty;
            Created = DateTime.Now;
        }
        public override string ToString()
        {
            return $"ID : {ID}\n Title: {Title}\nContent: {Content}\n Created Date: {Created}\n";
        }
    }
}
