using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace database.models
{
    class DatabaseModel
    {
        private string con_str = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|data.mdf;Integrated Security=True";

        public void CreateMaterial(string name, int amount = 0)
        {
            using (SqlConnection con = new SqlConnection(con_str))
            {
                using (SqlCommand cmd = new SqlCommand("DodajMaterial", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@nazwa", SqlDbType.VarChar).Value = name;
                    cmd.Parameters.Add("@ilosc", SqlDbType.Int).Value = amount;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void CreateWorker(Int64 PESEL, string name, string surname, string cert)
        {
            using (SqlConnection con = new SqlConnection(con_str))
            {
                using (SqlCommand cmd = new SqlCommand("DodajPracownika", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PESEL", SqlDbType.BigInt).Value = PESEL;
                    cmd.Parameters.Add("@Imie", SqlDbType.VarChar).Value = name;
                    cmd.Parameters.Add("@Nazwisko", SqlDbType.VarChar).Value = surname;
                    cmd.Parameters.Add("@Zaswiadczenie", SqlDbType.VarChar).Value = cert;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void CreateAmmo(string name, int amount)
        {
            using (SqlConnection con = new SqlConnection(con_str))
            {
                using (SqlCommand cmd = new SqlCommand("NowaAmunicja", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@kaliber", SqlDbType.VarChar).Value = name;
                    cmd.Parameters.Add("@ilosc", SqlDbType.Int).Value = amount;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void CreateWeapon(string name, string category)
        {
            using (SqlConnection con = new SqlConnection(con_str))
            {
                using (SqlCommand cmd = new SqlCommand("NowaBron", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@nazwa", SqlDbType.VarChar).Value = name;
                    cmd.Parameters.Add("@kategoria", SqlDbType.VarChar).Value = category;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Add new Supply refill
        /// </summary>
        /// <param name="materials">dict(material_name, material_amount)</param>
        /// <param name="seller"></param>
        /// <param name="price"></param>
        /// <param name="transport"></param>
        public void AddSupplyRefill(IReadOnlyDictionary<string,int> materials, string seller, decimal price, string transport)
        {
            DataTable tmp = new DataTable();
            tmp.Columns.Add("Material");
            tmp.Columns.Add("Ilosc");

            foreach(var i in materials)
                tmp.Rows.Add(i.Key, i.Value);

            using (SqlConnection con = new SqlConnection(con_str))
            {
                using (SqlCommand cmd = new SqlCommand("NowaDostawa", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter param = cmd.Parameters.Add("@materialy", SqlDbType.Structured);
                    param.Value = tmp;
                    param.TypeName = "MaterialyArr";

                    cmd.Parameters.Add("@dostawca", SqlDbType.VarChar).Value = seller;
                    cmd.Parameters.Add("@koszt", SqlDbType.Decimal).Value = price;
                    cmd.Parameters.Add("@transport", SqlDbType.VarChar).Value = transport;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void CreateCategory(string name)
        {
            using (SqlConnection con = new SqlConnection(con_str))
            {
                using (SqlCommand cmd = new SqlCommand("NowaKategoria", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@nazwa", SqlDbType.VarChar).Value = name;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Create new production data
        /// </summary>
        /// <param name="product_name"></param>
        /// <param name="amount"></param>
        /// <param name="materials">key: material name, value: material amount</param>
        public void CreateProduction(string product_name, int amount, IReadOnlyDictionary<string, int> materials)
        {
            DataTable tmp = new DataTable();
            tmp.Columns.Add("Material");
            tmp.Columns.Add("Ilosc");

            foreach (var i in materials)
                tmp.Rows.Add(i.Key, i.Value);

            using (SqlConnection con = new SqlConnection(con_str))
            {
                using (SqlCommand cmd = new SqlCommand("NowaProdukcja", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@nazwa_produktu", SqlDbType.VarChar).Value = product_name;
                    cmd.Parameters.Add("@ilosc", SqlDbType.Int).Value = amount;

                    SqlParameter param = cmd.Parameters.Add("@materialy", SqlDbType.Structured);
                    param.Value = tmp;
                    param.TypeName = "MaterialyArr";
                                       
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Create new order and assign it to new worker
        /// </summary>
        /// <param name="arrival_date">date of scheduled arrival</param>
        /// <param name="ammo">collection of pairs: (ammo id, ammo amount)</param>
        /// <param name="weapons">collection of pairs: (weapon id, weapon amount)</param>
        /// <param name="cert"></param>
        /// <param name="retail">type of order: true - retail, false - wholesail</param>
        /// <param name="adnotations">additional adnotations about order</param>
        public void CreateOrder(DateTime arrival_date, ICollection<Tuple<int,int>> ammo, ICollection<Tuple<int, int>> weapons, string cert, bool retail, string adnotations = null)
        {
            DataTable tmp_ammo = new DataTable();
            tmp_ammo.Columns.Add("numer_pudelka");
            tmp_ammo.Columns.Add("ilosc");

            foreach (var i in ammo)
                tmp_ammo.Rows.Add(i.Item1, i.Item2);

            DataTable tmp_weap = new DataTable();
            tmp_weap.Columns.Add("numer_seryjny");
            tmp_weap.Columns.Add("ilosc");

            foreach (var i in weapons)
                tmp_weap.Rows.Add(i.Item1, i.Item2);

            using (SqlConnection con = new SqlConnection(con_str))
            {
                using (SqlCommand cmd = new SqlCommand("NowaProdukcja", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@data_dostawy", SqlDbType.Date).Value = arrival_date;
                    cmd.Parameters.Add("@certyfikat", SqlDbType.VarChar).Value = cert;
                    cmd.Parameters.Add("@detaliczne", SqlDbType.Bit).Value = retail;

                    if (adnotations != null)
                        cmd.Parameters.Add("@uwagi", SqlDbType.VarChar).Value = adnotations;

                    SqlParameter param = cmd.Parameters.Add("@amunicja", SqlDbType.Structured);
                    param.Value = tmp_ammo;
                    param.TypeName = "AmmoArr";

                    SqlParameter param2 = cmd.Parameters.Add("@bron", SqlDbType.Structured);
                    param2.Value = tmp_weap;
                    param2.TypeName = "BronArr";

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<T> Query<T>(string sql_query, object parameters = null)
        {
            using (SqlConnection con = new SqlConnection(con_str))
            {
                return con.Query<T>(sql_query, parameters);
            }
        }

        public IEnumerable<dynamic> Query(string sql_query, object parameters = null)
        {
            using (SqlConnection con = new SqlConnection(con_str))
            {
                return con.Query(sql_query, parameters);
            }
        }
    }
}
