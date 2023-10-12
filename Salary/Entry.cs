using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salary
{
    internal class Entry
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public double Accrue { get; set; }
        public double Tax { get; set; }
        public double Fund { get; set; }
        public double Result { get; set; }

        public Entry() { }
        public Entry(string name, string position, double accrue, double tax, double fund, int id = 0, double result = 0.0d) 
        {
            ID = id;
            Name = name;
            Position = position;
            Accrue = accrue;
            Tax = tax;
            Fund = fund;
            Result = Math.Round(accrue * (1 - tax / 100) * (1 - fund / 100), 2);
        }

        public void CalculateResult(double accrue, double tax, double fund)
        {
            Result = Math.Round(accrue * (1 - tax / 100) * (1 - fund / 100), 2);
        }
    }
}
