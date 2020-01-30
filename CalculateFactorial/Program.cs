using System;

namespace CalculateFactorial
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter an int:");
            int anInt = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(anInt + "! =" + factorial(anInt));
        }

        public static int factorial(int theInt) {
            if(theInt <= 1) {
                return theInt;
            }
            else {
                return theInt * factorial(theInt -1);
            }
        }
    }
}
