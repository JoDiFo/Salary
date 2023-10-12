using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salary
{
    internal class Employee
    {
        public int ID { get ; set; }
        public string Name { get; set; }
        public Position Position { get; set; } = new Position();
    }
}
