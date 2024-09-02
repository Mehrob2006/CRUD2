using ConsoleApp1.Models;
using Npgsql;
namespace Shopping_Project.Services;

public class ProductService
{
    #region CreateProductTable
    
    public void CreateProductTable()
    {
        try
        {
            using(NpgsqlConnection conn = new NpgsqlConnection(SqlCommand.connectionstring))
            {
                conn.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = SqlCommand.CreateProductTable;
                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
    #endregion

    #region CreatePRoduct
    public void CreatePRoduct(Product product)
    {
        try
        {
            
            using(NpgsqlConnection connection = new NpgsqlConnection(SqlCommand.connectionstring))
            {
                connection.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = SqlCommand.InsertToProduct;
                    cmd.Parameters.AddWithValue("@name", product.ProductName);
                    cmd.Parameters.AddWithValue("@description", product.Description);
                    cmd.Parameters.AddWithValue("@price", product.Price);
                    cmd.Parameters.AddWithValue("@quantity", product.Quantity);
                    
                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
    #endregion

    #region GetProducts
    public List<Product> GetProducts()
    {
        List<Product> products = new();
        
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommand.connectionstring))
            {
                connection.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = SqlCommand.GetAllProducts;
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product product = new();
                            product.Id = reader.GetInt32(0);
                            product.ProductName = reader.GetString(1);
                            product.Description = reader.GetString(2);
                            product.Price = reader.GetInt32(3);
                            product.Quantity = reader.GetInt32(4);
                            
                            products.Add(product);
                        }
                    }
                }
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
        
        return products;
    }
    #endregion

    #region GetProductById
    public Product GetProductById(int Id)
    {
        Product product = new Product();
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommand.connectionstring))
            {
                connection.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = SqlCommand.GetProductById;
                    cmd.Parameters.AddWithValue("@Id", Id);

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            product.Id = reader.GetInt32(0);
                            product.ProductName = reader.GetString(1);
                            product.Description = reader.GetString(2);
                            product.Price = reader.GetInt32(3);
                            product.Quantity = reader.GetInt32(4);
                        }
                    }
                }
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine("Found Error");
            Console.WriteLine(e.Message);
            throw;
        }

        return product;
    }
    #endregion

    #region UpdateProduct
    public Product UpdateProduct(Product product)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommand.connectionstring))
            {
                connection.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = SqlCommand.UpdateProduct;
                    cmd.Parameters.AddWithValue("@id", product.Id);
                    cmd.Parameters.AddWithValue("@name", product.ProductName);
                    cmd.Parameters.AddWithValue("@description", product.Description);
                    cmd.Parameters.AddWithValue("@price", product.Price);
                    cmd.Parameters.AddWithValue("@quantity", product.Quantity);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }

        return product;
    }
    #endregion

    #region DeleteProduct
    
    public void DeleteProduct(int id)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommand.connectionstring))
            {
                connection.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = SqlCommand.DeleteProduct;
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
    #endregion
    
}
