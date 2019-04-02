using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifications.Models
{
    public class Inventory
    {
        public int BookId { get; set; }
        public string Author { get; set; }
        public string BookName { get; set; }
        public bool ReadStatus { get; set; }
    }
}
