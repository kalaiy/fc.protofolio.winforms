using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fc.Protofolio.Winforms.Models
{
    public class Holdings
    {
        public string Symbol { get; set; } = "";
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
        public decimal LTP { get; set; }
        public int Count { get; set; }
    }
}
