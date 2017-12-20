using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoPro.Models
{
    public class Suggestion
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Text { get; set; }
        public string ImageUrl { get; set; }
    }
}
