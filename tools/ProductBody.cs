using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatlingCICD.tools
{
    public class ProductBody
    {


        public string name { get; set; }
        public string slug { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public int categoryId { get; set; }


    }
}
