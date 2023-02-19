using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniinstagram
{
    public class Post
    {

        public int Id { get; set; }

        public User User { get; set; }

        public int IdUser { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        public string Text { get; set; }

        public string ImgPath { get; set; }

        public List<Tags> Tags { get; set; } = new();


    }
}
