using Exercise01.NumberService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Numerics;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ConvertBigIntToWords()
        {
            var dr = new NumberDescriber();
            BigInteger test = BigInteger.Parse("18456002032011000007");// tests


            var res = dr.Towards(test);
            Console.WriteLine(res);
           // Console.Read();
        }
    }
}
