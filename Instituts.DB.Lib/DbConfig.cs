using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Instituts.DB.Lib
{
    public class DbConfig
    {
        private ConnectionString _str;
        private string _path;


        public DbConfig() 
        {
            _path = "db_config.json";
        }
        public DbConfig(string path)
        {
            _path=path;
        }

        public string GetConnectionString()
        {
            using var file = new FileStream(_path, FileMode.Open);

            _str = JsonSerializer.DeserializeAsync<ConnectionString>(file).Result;

            return _str.ToString();
        }
    }
}
