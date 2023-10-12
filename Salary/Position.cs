using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salary
{
    internal class Position
    {
        public int ID {  get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        //public Tax Taxes { get; set; } = new Tax();
        //public double Tax { get; set; }
        //public double Fund { get; set; }
        public Taxes.TaxType TaxType { get; set; }
    }
}
