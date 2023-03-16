using LotoClassNS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Runtime.InteropServices.WindowsRuntime;

namespace UnitTestProject1YAG2223
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void comprobarNumeroMenor()
        {

            int[] numeros = { 2, 6, -4, 60,1, 9};

            LotoYAG2223 lotoYAG2223 = new LotoYAG2223(numeros);
            bool comprobar = lotoYAG2223.ok;

            Assert.IsFalse(comprobar);
        }
        [TestMethod]
        public void comprobarNumeroMayor()
        {

            int[] numeros = { 2, 6, 50, 60, 1, 9 };

            LotoYAG2223 lotoYAG2223 = new LotoYAG2223(numeros);
            bool comprobar = lotoYAG2223.ok;

            Assert.AreEqual(comprobar,false);
        }
    }
}
