using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            StringCalculator s = new StringCalculator();
            Console.WriteLine(s.Add("//[//][%]\n1//2%3"));
            Console.ReadKey();
        }
    }
}
