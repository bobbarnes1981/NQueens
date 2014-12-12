using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NQueensLibrary;

namespace NQueensCLISolver
{
    class Program
    {
        static void Main(string[] args)
        {
            Solver s = new Solver(8);
            s.Solve();
            Console.WriteLine(s.ToString());
        }
    }
}
