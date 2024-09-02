using ConsoleApp1.Models;
using Npgsql;

namespace Shopping_Project.Services;

public class OrdersService
{
    #region CreateOrderTable
    
    public void CreateOrderTable()
    {
        try
        {
            using(NpgsqlConnection conn = new NpgsqlConnection(SqlCommand.connectionstring))
            {
                conn.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = SqlCommand.CreateOrderTable;
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
    
    #region CreateOrder
    public void CreateOrder(Orders order)
    {
        try
        {
            
            using(NpgsqlConnection connection = new NpgsqlConnection(SqlCommand.connectionstring))
            {
                connection.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = SqlCommand.InsertToOrders;
                    cmd.Parameters.AddWithValue("@orderdate", order.OrderDate);
                    cmd.Parameters.AddWithValue("@totalamount", order.TotalAmount);
                    cmd.Parameters.AddWithValue("@status", order.Status);
                    cmd.Parameters.AddWithValue("@customerid", order.Customer_Id);
                    cmd.Parameters.AddWithValue("@productid", order.Product_Id);
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
    
    #region GetOrders
    public List<Orders> GetOrders()
    {
        List<Orders> orders = new();
        
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommand.connectionstring))
            {
                connection.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = SqlCommand.GetAllOrders;
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Orders ord = new();
                            ord.Id = reader.GetInt32(0);
                            ord.Customer_Id = reader.GetInt32(1);
                            ord.Product_Id = reader.GetInt32(2);
                            ord.OrderDate = reader.GetDateTime(3);
                            ord.TotalAmount = reader.GetInt32(4);
                            ord.Status = reader.GetString(5);
                            
                            orders.Add(ord);
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
        
        return orders;
    }
    #endregion
    
    #region GetOrderById
    public Orders GetOrderById(int Id)
    {
        Orders order = new();
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommand.connectionstring))
            {
                connection.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = SqlCommand.GetAllOrders;
                    cmd.Parameters.AddWithValue("@Id", Id);

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            order.Id = reader.GetInt32(0);
                            order.Customer_Id = reader.GetInt32(1);
                            order.Product_Id = reader.GetInt32(2);
                            order.OrderDate = reader.GetDateTime(3);
                            order.TotalAmount = reader.GetInt32(4);
                            order.Status = reader.GetString(5);
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

        return order;
    }
    #endregion
    
    #region UpdateOrder
    public Orders UpdateOrder(Orders order)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommand.connectionstring))
            {
                connection.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = SqlCommand.UpdateOrder;
                    cmd.Parameters.AddWithValue("@id", order.Id);
                    cmd.Parameters.AddWithValue("@customerid", order.Customer_Id);
                    cmd.Parameters.AddWithValue("@productid", order.Product_Id);
                    cmd.Parameters.AddWithValue("@orderdate", order.OrderDate);
                    cmd.Parameters.AddWithValue("@totalamount", order.TotalAmount);
                    cmd.Parameters.AddWithValue("status", order.Status);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }

        return order;
    }
    #endregion
    
    #region DeleteOrder
    
    public void DeleteOrder(int id)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommand.connectionstring))
            {
                connection.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = SqlCommand.DeleteOrder;
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

