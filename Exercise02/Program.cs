using System;
using System.Numerics;
using Exercise01.NumberService;

namespace Exercise02
{
    class Program
    {
        static void Main(string[] args)
        {
            var dr = new NumberDescriber();
            //BigInteger test = BigInteger.Parse("18456002032011000007");// tests


            var res= dr.Towards(1245);
            Console.WriteLine(res);
            Console.Read();
        }
    }
}
