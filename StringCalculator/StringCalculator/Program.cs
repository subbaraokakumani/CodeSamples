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
            Console.WriteLine("Please enter numbers\n");
            string numbers = Console.ReadLine();

            StringCalc objStringCalc = new StringCalc();
            int sum = objStringCalc.Add(numbers);

            Console.WriteLine("The sum of given numbers is: " + sum.ToString());
            Console.ReadKey();
        }
    }
}
