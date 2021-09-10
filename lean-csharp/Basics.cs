using System;
using System.Collections.Generic;
using System.Text;

namespace lean_csharp
{
    class Basics
    {
        public static void LoopMethod(string[] args)
        {
            //calculator
            for (int i = 0; i <= 2; i++)
            {
                Console.WriteLine("Enter two number seperated by ,");
                string line = Console.ReadLine();
                string[] arr = line.Split(",");
                int firstNumber = Convert.ToInt32(arr[0]);
                int secondNumber = Convert.ToInt32(arr[1]);

                Console.WriteLine(firstNumber + secondNumber);
            }
        }

        public void variableDeclarations()
        {
            int n = 10;
            Console.WriteLine(n);

            double d = 10.3;
            Console.WriteLine(d);

            decimal de = 123456789123456789123456789.5m;
            Console.WriteLine(de);


            string name = "Srilatha Damsani Bengaluru";
            Console.WriteLine(name);
            Console.WriteLine(name.Length);
            String[] details = name.Split(" ");
            
            for(int i = 0; i < details.Length; i++)
            {
                Console.WriteLine(details[i]);
            }

            int indexD = name.IndexOf("Dam");
            int indexB = name.IndexOf("Beng");

            String dams = name.Substring(indexD, indexB - indexD);
            Console.WriteLine(dams);
            Console.WriteLine(name.ToUpper());
            Console.WriteLine(name.ToLower());

            
             
        }
    }
}
