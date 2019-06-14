using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcon.SyncFerrero
{
    class Program
    {
        
        static void Main(string[] args)
        {
            List<OrdProduzione> righe;
            righe = OrdProduzione.GetAll();
            foreach (var c in righe )
            {
                string filename = $"ORDPRO_{c.NUMERO}.txt";
                using (StreamWriter sw = new StreamWriter(Path.Combine(Global.DEFAULTPATH, filename)))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("TES");
                    sb.Append(";");
                    sb.Append("100");
                    sb.Append(";");
                    sb.Append($"{c.dt_agg}");
                    sb.Append(";");
                    sb.Append($"{c.NUMERO-1000000000}");
                    sb.Append(";");
                    sb.Append("100");
                    sb.Append(";");
                    sb.Append($"{c.dt_agg}");
                    sb.Append(";");
                    sb.Append($"{c.NUMERO}");
                    sb.Append(";");
                    sb.Append($"{c.codlinea}");
                    sb.Append(";");
                    sb.Append($"AA{c.risorsaprimaria}");
                    sb.Append(";");
                    sb.Append($"{c.usage}");
                    sb.Append(";");
                    sw.WriteLine(sb.ToString());
                }
            }
        }
    }
}



















































