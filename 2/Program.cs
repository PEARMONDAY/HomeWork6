using System;

namespace HomeWork6_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int Money ;
            int Price;
            Console.Write("InPut Price :");
            Price = int.Parse(Console.ReadLine());
            int Pay;
            Console.Write("InPut Pay :");
            Pay = int.Parse(Console.ReadLine());
            int Change;
            Change = Pay - Price  ;

            Console.Write("My Money = {0}",Change);
            Console.ReadLine();
        }
    }
}
