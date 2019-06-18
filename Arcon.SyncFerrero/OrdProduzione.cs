using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Arcon.SyncFerrero
{

    class OrdProduzione
    {
        public string dest = @"C:\Users\Stage1\Desktop\File\Consegna";
        public string fonte = @"C:\Users\Stage1\Desktop\File\Consegna\consegna";
        
        public int NUMERO { get; set; }
        public string codlinea { get; set; }
        public string risorsaprimaria { get; set; }
        public string usage { get; set; }
        public int N_OLS { get; set; }
        public int RILASCIO { get; set; }
        public string dt_agg { get; set; }
        public DateTime DataInserimento { get; set; }
        public double quantita { get; set; }
        public string dataInizio { get; set; }
        public string dataFine { get; set; }

        public OrdProduzione(SqlDataReader rd)
        {
            NUMERO = Convert.ToInt32((string)rd["NUMERO"]);
            N_OLS = (int)rd["N_OLS"];
            RILASCIO = (int)rd["RILASCIO"];
            dt_agg =Convert.ToString( (DateTime)rd["DT_AGG"]);
            codlinea = (string)rd["COD_LINEA"];
            risorsaprimaria = (string)rd["RISORSA_PRIMARIA"];
            usage = (string)rd["USAGE"];
            quantita = (double)rd["QTA_PROGRAMMATA"];
            dataInizio = Convert.ToString((DateTime)rd["DATA_INIZIO"]);
            dataFine = Convert.ToString((DateTime)rd["DATA_FINE"]);
            

        }

        

        public static void Insert(OrdProduzione c)
        {
            List<OrdProduzione> list = new List<OrdProduzione>();
            using (SqlConnection conn = new SqlConnection(Global.DB_CONNECTIONSTRING))
            {
                conn.Open();

                string query = $"INSERT INTO Persone(NUMERO,N_OLS,RILASCIO,DataInserimento) VALUES('{c.NUMERO}', '{c.N_OLS}', '{c.RILASCIO}', '{c.DataInserimento}')";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                   
                }
                
            }

        }
    }

    class DistintaBase
    {
        public string dest = @"C:\Users\Stage1\Desktop\File\DistintaBase";
        public string fonte = @"C:\Users\Stage1\Desktop\File\DistintaBase\consegna";

         public static List<OrdProduzione> GetAll()
        {
            List<OrdProduzione> list = new List<OrdProduzione>();
            using (SqlConnection conn = new SqlConnection(Global.DB_CONNECTIONSTRING))
            {
                conn.Open();

                string query = "SELECT ORDPRO.*  FROM ORDPRO LEFT JOIN FE_SyncORDPRO ON ORDPRO.NUMERO = FE_SyncORDPRO.NUMERO AND ORDPRO.N_OLS = FE_SyncORDPRO.N_OLS AND ORDPRO.RILASCIO = FE_SyncORDPRO.RILASCIO WHERE FE_SyncORDPRO.NUMERO IS NULL";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    //cmd.ExecuteNonQuery();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            list.Add(new OrdProduzione(rd));
                        }
                    }
                }
            }
            return list;
        } 
    }
    
}











