using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.Models
{
    public class BlogItem
    {
        public int Id { get; set; }
        public string Yazi { get; set; }
        public string Category { get; set; }
        public int? OkunmaSayisi { get; set; }
    }
}
