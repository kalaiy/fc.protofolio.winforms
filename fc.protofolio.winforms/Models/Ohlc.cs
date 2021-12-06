using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fc.Protofolio.Winforms.Models
{
    public class Ohlc
    {
        public string Time { get; set; } = "";
        public decimal Open { get; set; }
        public decimal Close { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Percentage { get; set; }
        public uint Volume { get; set; }
        public override string ToString()
        {
            return $"{Time} {Open} {High} {Low} {Close}".ToString();

        }
    }
}
