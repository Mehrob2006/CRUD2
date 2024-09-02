using System.Data;
using ConsoleApp1.Models;
using Npgsql;
namespace Shopping_Project.Services;

public class DiscountService
{
    #region CreateDiscountTable
    
    public void CreateDiscountTable()
    {
        try
        {
            using(NpgsqlConnection conn = new NpgsqlConnection(SqlCommand.connectionstring))
            {
                conn.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = SqlCommand.CreateDiscountTable;
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
    
    #region CreateDiscount
    public void CreateDiscount(Discounts discount)
    {
        try
        {
            using(NpgsqlConnection connection = new NpgsqlConnection(SqlCommand.connectionstring))
            {
                connection.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = SqlCommand.InsertToDiscounts;
                    cmd.Parameters.AddWithValue("@name", discount.name);
                    cmd.Parameters.AddWithValue("@start", discount.start_date);
                    cmd.Parameters.AddWithValue("@end", discount.end_date);
                    cmd.Parameters.AddWithValue("@percentage", discount.percentage);
                    
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
    
    #region GetDiscounts
    public List<Discounts> GetDiscounts()
    {
        List<Discounts> discounts = new();
        
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommand.connectionstring))
            {
                connection.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = SqlCommand.GetAllDiscounts;
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Discounts discount = new();
                            discount.Id = reader.GetInt32(0);
                            discount.name = reader.GetString(1);
                            discount.start_date = reader.GetDateTime(2);
                            discount.end_date = reader.GetDateTime(3);
                            discount.percentage = reader.GetInt32(4);
                            
                            discounts.Add(discount);
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
        
        return discounts;
    }
    #endregion
    
    #region GetDiscountById
    public Discounts GetDiscountById(int Id)
    {
        Discounts discounts = new();
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommand.connectionstring))
            {
                connection.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = SqlCommand.GetDiscountById;
                    cmd.Parameters.AddWithValue("@Id", Id);

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            discounts.Id = reader.GetInt32(0);
                            discounts.name = reader.GetString(1);
                            discounts.start_date = reader.GetDateTime(2);
                            discounts.end_date = reader.GetDateTime(3);
                            discounts.percentage = reader.GetInt32(4);
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

        return discounts;
    }
    #endregion
    
    #region UpdateDiscount
    public Discounts UpdateDiscount(Discounts discount)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommand.connectionstring))
            {
                connection.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = SqlCommand.UpdateDiscount;
                    cmd.Parameters.AddWithValue("@id", discount.Id);
                    cmd.Parameters.AddWithValue("@name", discount.name);
                    cmd.Parameters.AddWithValue("@start_date", discount.start_date);
                    cmd.Parameters.AddWithValue("@end_date", discount.end_date);
                    cmd.Parameters.AddWithValue("@percentage", discount.percentage);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }

        return discount;
    }
    #endregion
    
    #region DeleteDiscount
    
    public void DeleteDiscount(int id)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommand.connectionstring))
            {
                connection.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = SqlCommand.DeleteDiscount;
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