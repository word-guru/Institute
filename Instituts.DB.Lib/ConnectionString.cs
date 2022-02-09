using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instituts.DB.Lib
{
    public class ConnectionString
    {
        public string Server { get; set; }
        public string Database { get; set; }

        public override string ToString()
        {
            return $"Server={Server};Database={Database};";
        }
    }
}
