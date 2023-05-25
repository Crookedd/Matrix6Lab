using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix6Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MatrixCalculator calculator = new MatrixCalculator();
            calculator.Start();
            Console.ReadKey();
        }
    }
}
