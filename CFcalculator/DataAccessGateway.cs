using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace CFcalculator
{
    class DataAccessGateway
    {
        public List<ComuneCf> getComuniLike(string comune)
        {
            var conn = new OleDbConnection(Properties.Settings.Default.ComuniCFdbConnectionString);
            string query = "SELECT Nome, Provincia, Codice, ID FROM ComuniItalia WHERE Nome LIKE '" + comune.Replace("'", "''") + "'";

            var cmd = new OleDbCommand(query, conn);

            conn.Open();
            var reader = cmd.ExecuteReader();
            var clist = new List<ComuneCf>();
            while (reader.Read())
            {
                var com = new ComuneCf
                {
                    Nome = reader[0].ToString(),
                    Prov = reader[1].ToString(),
                    Codice = reader[2].ToString(),
                    ID = int.Parse(reader[3].ToString())
                };
                clist.Add(com);
            }
            conn.Close();
            return clist;
        }

        public string getCodiceComune(string com, string prov)
        {
            var conn = new OleDbConnection(Properties.Settings.Default.ComuniCFdbConnectionString);
            string query = "SELECT Codice FROM ComuniItalia WHERE Nome='" + com.Replace("'", "''") + "' AND Provincia = '" + prov + "'";

            var cmd = new OleDbCommand(query, conn);

            conn.Open();
            var reader = cmd.ExecuteReader();
            reader.Read();
            string codice = reader[0].ToString();
            conn.Close();
            return codice;
        }

        public string getCodiceComune(int id)
        {
            var conn = new OleDbConnection(Properties.Settings.Default.ComuniCFdbConnectionString);
            string query = "SELECT Codice FROM ComuniItalia WHERE ID='" + id.ToString() + "'";

            var cmd = new OleDbCommand(query, conn);

            conn.Open();
            var reader = cmd.ExecuteReader();
            reader.Read();
            string codice = reader[0].ToString();
            conn.Close();
            return codice;
        }
    }
}
