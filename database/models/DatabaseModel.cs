using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;

namespace database.models
{
    class DatabaseModel
    {
        private SqlConnection connection;

        public DatabaseModel()
        {
            connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|data.mdf;Integrated Security=True");
        }

        public string TryConnect()
        {
            try
            {
                connection.Open();
            }

            catch(SqlException e)
            {
                return e.Message;
            }

            return null;
        }
    }
}
