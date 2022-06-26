using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Grid
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public float price { get; set; }
    }
    public class ProductLayer
    {
        public static List<Product> GetallProducts()
        {
            List<Product> products = new List<Product>();
            string cs = ConfigurationManager.ConnectionStrings["Taskdbconn2"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("Select * from Product", con);
                con.Open();
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    Product product = new Product();
                    product.id = Convert.ToInt32(sqlDataReader["ID"]);
                    product.name = sqlDataReader["Name"].ToString();
                    product.price = Convert.ToInt32(sqlDataReader["Price"]);
                    products.Add(product);
                }
                return products;
            }
        }
    }
}