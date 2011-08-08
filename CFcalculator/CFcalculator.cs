using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CFcalculator
{
    public class CFcalculator
    {
        private DataAccessGateway dag;

        private int _anno;
        private int _mese;
        private Dictionary<int, string> ConvMese;
        private int _giorno;

        public string Nome { get; set; }
        public string Cognome { get; set; }
        public int Anno
        {
            get {
                return _anno;
            }
            set {
               if (value < 1800 || value > DateTime.Now.Year) return;
               _anno = value;
            } 
        }

        public int Mese {
            get
            {
                return _mese;
            }
            set
            {
                if (value < 0 || value > 12) return;
                _mese = value;
            } 
        }

        public int Giorno {
            get
            {
                return _giorno;
            }
            set
            {
                if (value < 0 || value > 31) return;
                _giorno = value;
            }
        }
        public string Comune { get; set; }
        public string Provincia { get; set; }
        public bool isMaschio { get; set; }

        private Dictionary<string, int> dictPari;
        private Dictionary<string, int> dictDispari;
        private Dictionary<int, string> controlCharDict;


        public CFcalculator()
        {
            isMaschio = true;
            ConvMese = new Dictionary<int, string>();
            ConvMese.Add(1, "A");
            ConvMese.Add(2, "B");
            ConvMese.Add(3, "C");
            ConvMese.Add(4, "D");
            ConvMese.Add(5, "E");
            ConvMese.Add(6, "H");
            ConvMese.Add(7, "L");
            ConvMese.Add(8, "M");
            ConvMese.Add(9, "P");
            ConvMese.Add(10, "R");
            ConvMese.Add(11, "S");
            ConvMese.Add(12, "T");

            dictPari = new Dictionary<string, int>();
            dictPari.Add("0", 0);
            dictPari.Add("1", 1);
            dictPari.Add("2", 2);
            dictPari.Add("3", 3);
            dictPari.Add("4", 4);
            dictPari.Add("5", 5);
            dictPari.Add("6", 6);
            dictPari.Add("7", 7);
            dictPari.Add("8", 8);
            dictPari.Add("9", 9);
            dictPari.Add("A", 0);
            dictPari.Add("B", 1);
            dictPari.Add("C", 2);
            dictPari.Add("D", 3);
            dictPari.Add("E", 4);
            dictPari.Add("F", 5);
            dictPari.Add("G", 6);
            dictPari.Add("H", 7);
            dictPari.Add("I", 8);
            dictPari.Add("J", 9);
            dictPari.Add("K", 10);
            dictPari.Add("L", 11);
            dictPari.Add("M", 12);
            dictPari.Add("N", 13);
            dictPari.Add("O", 14);
            dictPari.Add("P", 15);
            dictPari.Add("Q", 16);
            dictPari.Add("R", 17);
            dictPari.Add("S", 18);
            dictPari.Add("T", 19);
            dictPari.Add("U", 20);
            dictPari.Add("V", 21);
            dictPari.Add("W", 22);
            dictPari.Add("X", 23);
            dictPari.Add("Y", 24);
            dictPari.Add("Z", 25);

            dictDispari = new Dictionary<string, int>();
            dictDispari.Add("0", 1);
            dictDispari.Add("1", 0);
            dictDispari.Add("2", 5);
            dictDispari.Add("3", 7);
            dictDispari.Add("4", 9);
            dictDispari.Add("5", 13);
            dictDispari.Add("6", 15);
            dictDispari.Add("7", 17);
            dictDispari.Add("8", 19);
            dictDispari.Add("9", 21);
            dictDispari.Add("A", 1);
            dictDispari.Add("B", 0);
            dictDispari.Add("C", 5);
            dictDispari.Add("D", 7);
            dictDispari.Add("E", 9);
            dictDispari.Add("F", 13);
            dictDispari.Add("G", 15);
            dictDispari.Add("H", 17);
            dictDispari.Add("I", 19);
            dictDispari.Add("J", 21);
            dictDispari.Add("K", 2);
            dictDispari.Add("L", 4);
            dictDispari.Add("M", 18);
            dictDispari.Add("N", 20);
            dictDispari.Add("O", 11);
            dictDispari.Add("P", 3);
            dictDispari.Add("Q", 6);
            dictDispari.Add("R", 8);
            dictDispari.Add("S", 12);
            dictDispari.Add("T", 14);
            dictDispari.Add("U", 16);
            dictDispari.Add("V", 10);
            dictDispari.Add("W", 22);
            dictDispari.Add("X", 25);
            dictDispari.Add("Y", 24);
            dictDispari.Add("Z", 23);

            controlCharDict = new Dictionary<int, string>();
            controlCharDict.Add(0, "A");
            controlCharDict.Add(1, "B");
            controlCharDict.Add(2, "C");
            controlCharDict.Add(3, "D");
            controlCharDict.Add(4, "E");
            controlCharDict.Add(5, "F");
            controlCharDict.Add(6, "G");
            controlCharDict.Add(7, "H");
            controlCharDict.Add(8, "I");
            controlCharDict.Add(9, "J");
            controlCharDict.Add(10, "K");
            controlCharDict.Add(11, "L");
            controlCharDict.Add(12, "M");
            controlCharDict.Add(13, "N");
            controlCharDict.Add(14, "O");
            controlCharDict.Add(15, "P");
            controlCharDict.Add(16, "Q");
            controlCharDict.Add(17, "R");
            controlCharDict.Add(18, "S");
            controlCharDict.Add(19, "T");
            controlCharDict.Add(20, "U");
            controlCharDict.Add(21, "V");
            controlCharDict.Add(22, "W");
            controlCharDict.Add(23, "X");
            controlCharDict.Add(24, "Y");
            controlCharDict.Add(25, "Z");

            dag = new DataAccessGateway();
        }

        public string GetCodiceFiscale()
        {
            if (!areCFdataComplete())
                return "";

            string cf = "";
            //calcolo codice fiscale
            //Cognome
            cf += estraiCognome(Cognome);
            //Nome
            cf += estraiNome(Nome);
            //Anno
            cf += estraiAnno(Anno);
            //Mese
            cf += estraiMese(Mese);
            //Giorno
            cf += estraiGiorno(Giorno);
            //Comune
            cf += dag.getCodiceComune(Comune, Provincia);
            //Codice Controllo
            cf += getControlChar(cf);

            return cf.ToUpper();
        }

        public string estraiComune(string Comune, string Provincia)
        {
            return dag.getCodiceComune(Comune, Provincia);
        }

        public string estraiGiorno(int Giorno)
        {
            if (Giorno == 0) return "";
            int result = Giorno;
            if (!isMaschio) result += 40;
            if (result > 0 && result < 10)
                return "0" + result.ToString();
            return result.ToString();
        }

        public string estraiMese(int Mese)
        {
            if (Mese == 0) return "";
            return ConvMese[Mese];
        }

        public string estraiAnno(int Anno)
        {
            if (Anno == 0) return "";
            return Anno.ToString().Substring(2, 2);
        }

        public string getControlChar(string cf)
        {
            cf = cf.ToUpper();
            
            int totale = 0;

            for (int i = 0; i < cf.Length; ++i)
            {
                if (((i + 1) % 2) == 1)
                {//dispari
                    totale += dictDispari[cf[i].ToString()];
                }
                else
                {//pari
                    totale += dictPari[cf[i].ToString()];
                }
            }
            return controlCharDict[totale % 26];
        }

        public string estraiNome(string nome)
        {
            //prime 3 consonanti, se non ci sono passo alle vocali, altrimenti aggiungo X
            //se però ho 4 o più consonanti prendo la prima, la terza e la quarta (invece di prima seconda e terza)
            string codiceNome = "";

            for (int i = 0; i < nome.Length; i++)
            {//parto con le consonanti
                if (!isVocale(nome[i]) && nome[i] != ' ')
                    codiceNome += nome[i];
            }

            if (codiceNome.Length < 3)
            {//passo alle vocali

                for (int i = 0; i < nome.Length; i++)
                {
                    if (isVocale(nome[i]))
                        codiceNome += nome[i];
                    if (codiceNome.Length >= 3)
                        break;
                }
            }

            if (codiceNome.Length < 3)
            {//aggiungo X
                while (codiceNome.Length < 3)
                    codiceNome += "X";
            }

            //test numero consonanti
            int numConsonanti = getNumConsonanti(nome);
            if (numConsonanti >= 4)
            {//elimino la seconda consonante
                codiceNome = codiceNome[0] + codiceNome.Substring(2);
            }

            return codiceNome.Substring(0,3);
        }

        private int getNumConsonanti(string s)
        {
            int n = 0;
            foreach(char ch in s){
                if (!isVocale(ch) && ch != ' ' && ch != '\'')
                    n++;
            }
            return n;
        }

        private bool isVocale(char c)
        {
            string vocali = "aAeEiIoOuU";
            if(vocali.Contains(c))
                return true;
            return false;
        }

        public string estraiCognome(string cognome)
        {
            //prime 3 consonanti, se non ci sono passo alle vocali, altrimenti aggiungo X
            string codiceCognome = "";

            for (int i = 0; i < cognome.Length; i++)
            {//parto con le consonanti
                if (!isVocale(cognome[i]) && cognome[i] != ' ')
                    codiceCognome += cognome[i];
            }

            if (codiceCognome.Length < 3)
            {//passo alle vocali

                for (int i = 0; i < cognome.Length; i++)
                {
                    if (isVocale(cognome[i]))
                        codiceCognome += cognome[i];
                    if (codiceCognome.Length >= 3)
                        break;
                }
            }

            if (codiceCognome.Length < 3)
            {//aggiungo X
                while (codiceCognome.Length < 3)
                    codiceCognome += "X";
            }

            return codiceCognome.Substring(0,3);
        }

        private bool areCFdataComplete()
        {
            if (Nome == "") return false;
            if (Cognome == "") return false;
            if (Anno == 0) return false;
            if (Mese == 0) return false;
            if (Giorno == 0) return false;
            if (Comune == "") return false;
            if (Provincia == "") return false;
            return true;
        }
    }
}
