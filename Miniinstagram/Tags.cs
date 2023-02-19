using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniinstagram
{
    public class Tags
    {
        
        public int Id { get; set; }
        public string Tag { get; set; }

        public List<Post> Posts { get; set; } = new();

    }
}
