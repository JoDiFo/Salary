using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salary
{
    internal class Taxes
    {
        public enum TaxType
        {
            Contract,
            Income,
        }

        public int ID {  get; set; }
        public TaxType Type { get; set; }
        public double Tax { get; set; }
        public double Fund { get; set; }
    }
}
