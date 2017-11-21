using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Dapper;

namespace DBTest
{
    public class Database
    {
        public static string conVal(string connection)
        {
            return ConfigurationManager.ConnectionStrings[connection].ConnectionString;
        }
    }
}
