using DBSD_CW2_00011669_00012121_00010269.Models;
using System.Data;
using System.Data.SqlClient;

namespace DBSD_CW2_00011669_00012121_00010269.DAL
{
    public class ProductRepositorty : IProductRepository
    {
        private const string SQL_SELECT = @"select
                                        [id],
                                        [productName],
                                        [describtion],
                                        [price],
                                        [characterictics],
                                        [briefInfo],
                                        [productionDate],
                                        [isCertified]from products";
        public List<Product> GetProducts()
        {
            var result = new List<Product>();
            using (var conn = new SqlConnection(@"(localdb)\\MSSQLLocalDB;Initial Catalog=olcha_uz_db;Integrated Security=True"))
            {
                conn.Open();
                using(var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = SQL_SELECT;
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                      while (reader.Read()) {
                            var product = new Product()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("id")),
                                ProductName = reader.GetString(reader.GetOrdinal("productName")),
                                Description = reader.GetString(reader.GetOrdinal("description")),
                                Price = reader.GetFloat(reader.GetOrdinal("price")),
                                Characteristics = reader.GetString(reader.GetOrdinal("characteristics")),
                                BriefInfo = reader.GetString(reader.GetOrdinal("briefInfo")),
                                ProductionDate = reader.GetDateTime(reader.GetOrdinal("productionDate")),
                                IsCertified = reader.GetBoolean(reader.GetOrdinal("isCertifield"))

                            };
                            result.Add(product);
                        }
                    }
                }
            } 

            return result;
        }
    }
}
