using ConsoleApp1.Models;
using Npgsql;
namespace Shopping_Project.Services;

public class CustomerService
{
    #region CreateCustomerTable
    
    public void CreateCustomerTable()
    {
        try
        {
            using(NpgsqlConnection conn = new NpgsqlConnection(SqlCommand.connectionstring))
            {
                conn.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = SqlCommand.CreateCustomerTable;
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
    
    #region CreateCustomer
    public void CreateCustomer(Customers customer)
    {
        try
        {
            
            using(NpgsqlConnection connection = new NpgsqlConnection(SqlCommand.connectionstring))
            {
                connection.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = SqlCommand.InsertToCustomer;
                    cmd.Parameters.AddWithValue("@name", customer.first_name);
                    cmd.Parameters.AddWithValue("@lastname", customer.last_name);
                    cmd.Parameters.AddWithValue("@email", customer.email);
                    cmd.Parameters.AddWithValue("@phonenumber", customer.phonenumber);
                    cmd.Parameters.AddWithValue("@address", customer.address);
                    
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

    #region GetCustomers
    
    public List<Customers> GetCustomers()
    {
        List<Customers> customerslist = new();
        
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommand.connectionstring))
            {
                connection.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = SqlCommand.GetAllCustomers;
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Customers customers = new();
                            customers.Id = reader.GetInt32(0);
                            customers.first_name = reader.GetString(1);
                            customers.last_name = reader.GetString(2);
                            customers.email = reader.GetString(3);
                            customers.phonenumber = reader.GetString(4);
                            customers.address = reader.GetString(5);
                            
                            customerslist.Add(customers);
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
        
        return customerslist;
    }
    #endregion
    
    #region GetCustomerById
    public Customers GetCustomerById(int Id)
    {
        Customers customer = new();
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommand.connectionstring))
            {
                connection.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = SqlCommand.GetCustomerById;
                    cmd.Parameters.AddWithValue("@Id", Id);

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customer.Id = reader.GetInt32(0);
                            customer.first_name = reader.GetString(1);
                            customer.last_name = reader.GetString(2);
                            customer.email = reader.GetString(3);
                            customer.phonenumber = reader.GetString(4);
                            customer.address = reader.GetString(5);
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

        return customer;
    }
    #endregion
    
    #region UpdateCustomer
    public Customers UpdateCustomer(Customers customer)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommand.connectionstring))
            {
                connection.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = SqlCommand.UpdateCustomer;
                    cmd.Parameters.AddWithValue("@id", customer.Id);
                    cmd.Parameters.AddWithValue("@name", customer.first_name);
                    cmd.Parameters.AddWithValue("@lastname", customer.last_name);
                    cmd.Parameters.AddWithValue("@email", customer.email);
                    cmd.Parameters.AddWithValue("@phonenumber", customer.phonenumber);
                    cmd.Parameters.AddWithValue("@address", customer.address);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }

        return customer;
    }
    #endregion
    
    #region DeleteCustomer
    
    public void DeleteCustomer(int id)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommand.connectionstring))
            {
                connection.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = SqlCommand.DeleteCustomer;
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