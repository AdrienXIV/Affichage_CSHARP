using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Data;

namespace WS
{
    /// <summary>
    /// Description résumée de WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {
        public static String database = "database=test; server=localhost; user id=root; pwd=";
        public static MySqlCommand sql;
        public static MySqlDataReader dr;

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        MySqlConnection connexion = new MySqlConnection(database);

        [WebMethod]
        public DataTable LoadData(string query, string[] parametre, object[] valeurs, string table)
        {
            connexion.Open();
            var cmd = new MySqlCommand(query, connexion);
            if (parametre != null)
                for (var i = 0; i < parametre.Length; i++)
                    cmd.Parameters.AddWithValue(parametre[i], valeurs[i]);
            var dr = cmd.ExecuteReader();
            var dt = new DataTable(table);
            dt.Load(dr);
            connexion.Close();
            return dt;

        }
    }
}
