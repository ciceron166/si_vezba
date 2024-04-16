using DataLayer.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ProductRepository : IProductRepository
    {
        private string ConnectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=ShopDB;";
        public async Task<List<Product>> GetAll()
        {
            List<Product> lista = new List<Product>();
            using(SqlConnection connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();
                SqlCommand sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText = "SELECT * FROM Products";
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    Product product = new Product();
                    product.Id = reader.GetInt32(0);
                    product.Name = reader.GetString(1);
                    product.Description = reader.GetString(2);
                    product.Price = reader.GetDecimal(3);
                    lista.Add(product);
                }

            }
            return lista;
        }

        public bool Insert(Product product)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText = $"INSERT INTO Products(Name, Description, Price) " +
                    $"VALUES('{product.Name}', '{product.Description}', '{product.Price}')";

                int res = sqlCommand.ExecuteNonQuery();

                return res > 0;

            }
        }
    }
}
