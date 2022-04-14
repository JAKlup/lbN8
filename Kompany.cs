using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lbN8_Ex2
{
    class Kompany
    {

        public double количествочеловек { get; set; }
        public double заработнаяплата { get; set; }
        public string должность { get; set; }
        public double всего { get => количествочеловек * заработнаяплата; }
        public override string ToString()
        {
            return $"{должность}  {количествочеловек}  {заработнаяплата}  {всего}";
        }
        public string ToExcel()
        {
            return $" {всего};";

        }
    }
}


