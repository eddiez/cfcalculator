using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CFcalculator;

namespace TestCodiceFiscale
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class TestCFCalculator
    {
        

        public TestCFCalculator()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void getCodiceFiscaleTest()
        {
            //
            // TODO: Add test logic here
            //
            var cfcalc = new CFcalculator.CFcalculator();
            cfcalc.Nome = "Edoardo";
            cfcalc.Cognome = "Guzzetti";
            cfcalc.Anno = 1981;
            cfcalc.Mese = 9;
            cfcalc.Giorno = 7;
            cfcalc.Comune = "Roma";
            cfcalc.Provincia = "RM";
            cfcalc.isMaschio = true;
            string result = cfcalc.GetCodiceFiscale();

            Assert.AreEqual<string>("GZZDRD81P07H501H", result);

            cfcalc.Nome = "Angelo";
            cfcalc.Cognome = "Guzzetti";
            cfcalc.Anno = 1980;
            cfcalc.Mese = 7;
            cfcalc.Giorno = 18;
            cfcalc.Comune = "Roma";
            cfcalc.Provincia = "RM";
            cfcalc.isMaschio = true;
            result = cfcalc.GetCodiceFiscale();

            Assert.AreEqual<string>("GZZNGL80L18H501J", result);

            cfcalc.Nome = "MARIA VITTORIA";
            cfcalc.Cognome = "BAGNAIA BRUZZICHINI";
            cfcalc.Anno = 1949;
            cfcalc.Mese = 11;
            cfcalc.Giorno = 4;
            cfcalc.Comune = "Vetralla";
            cfcalc.Provincia = "VT";
            cfcalc.isMaschio = false;
            result = cfcalc.GetCodiceFiscale();

            Assert.AreEqual<string>("BGNMVT49S44L814U", result);

            cfcalc.Nome = "Roberto";
            cfcalc.Cognome = "Guzzetti";
            cfcalc.Anno = 1977;
            cfcalc.Mese = 1;
            cfcalc.Giorno = 18;
            cfcalc.Comune = "Roma";
            cfcalc.Provincia = "RM";
            cfcalc.isMaschio = true;
            result = cfcalc.GetCodiceFiscale();

            Assert.AreEqual<string>("GZZRRT77A18H501Q", result);

            cfcalc.Nome = "Pier Angelo";
            cfcalc.Cognome = "Guzzetti";
            cfcalc.Anno = 1946;
            cfcalc.Mese = 10;
            cfcalc.Giorno = 4;
            cfcalc.Comune = "Gorla Minore";
            cfcalc.Provincia = "VA";
            cfcalc.isMaschio = true;
            result = cfcalc.GetCodiceFiscale();

            Assert.AreEqual<string>("GZZPNG46R04E102P", result);
        }

        [TestMethod]
        public void estraiCognomeTest()
        {
            var cfcalc = new CFcalculator.CFcalculator();
            string expected = "Gzz";
            string actual = cfcalc.estraiCognome("Guzzetti");
            Assert.AreEqual<string>(expected, actual);

            expected = "RSS";
            actual = cfcalc.estraiCognome("ROSSI");
            Assert.AreEqual<string>(expected, actual);

            expected = "RVI";
            actual = cfcalc.estraiCognome("RIVA");
            Assert.AreEqual<string>(expected, actual);

            expected = "REX";
            actual = cfcalc.estraiCognome("RE");
            Assert.AreEqual<string>(expected, actual);

            expected = "DCR";
            actual = cfcalc.estraiCognome("DE CRESCENZO");
            Assert.AreEqual<string>(expected, actual);
        }

        [TestMethod]
        public void estraiNomeTest()
        {
            var cfcalc = new CFcalculator.CFcalculator();
            string expected = "drd";
            string actual = cfcalc.estraiNome("Edoardo");
            Assert.AreEqual<string>(expected, actual);

            expected = "MRT";
            actual = cfcalc.estraiNome("MARTA");
            Assert.AreEqual<string>(expected, actual);

            expected = "SLA";
            actual = cfcalc.estraiNome("SALA");
            Assert.AreEqual<string>(expected, actual);

            expected = "LAX";
            actual = cfcalc.estraiNome("AL");
            Assert.AreEqual<string>(expected, actual);

            expected = "MRP";
            actual = cfcalc.estraiNome("MARIA PIA");
            Assert.AreEqual<string>(expected, actual);
        }

        [TestMethod]
        public void estraiAnnoTest()
        {
            var cfcalc = new CFcalculator.CFcalculator();
            string expected = "81";
            string actual = cfcalc.estraiAnno(1981);
            Assert.AreEqual<string>(expected, actual);
        }

        [TestMethod]
        public void estraiMeseTest()
        {
            var cfcalc = new CFcalculator.CFcalculator();
            string expected = "R";
            string actual = cfcalc.estraiMese(10);
            Assert.AreEqual<string>(expected, actual);
        }

        [TestMethod]
        public void estraiGiornoTest()
        {
            var cfcalc = new CFcalculator.CFcalculator();
            cfcalc.isMaschio = true;
            string expected = "07";
            string actual = cfcalc.estraiGiorno(7);
            Assert.AreEqual<string>(expected, actual);

            cfcalc.isMaschio = false;
            expected = "47";
            actual = cfcalc.estraiGiorno(7);
            Assert.AreEqual<string>(expected, actual);
        }

        [TestMethod]
        public void estraiComuneTest()
        {
            var cfcalc = new CFcalculator.CFcalculator();
            cfcalc.Comune = "CA' DE' BONAVOGLI";
            cfcalc.Provincia = "CR";
            string expected = "B322";
            string actual = cfcalc.estraiComune(cfcalc.Comune, cfcalc.Provincia);
            Assert.AreEqual<string>(expected, actual);
        }
    }
}
