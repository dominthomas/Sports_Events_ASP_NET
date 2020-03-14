using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sports_Events_ASP_NET.Models
{
    public class Event
    {
        public int EventID { get; set; }

        public string Title { get; set; }

        public int AddressID { get; set; }

        public string Category { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }
    }
}
