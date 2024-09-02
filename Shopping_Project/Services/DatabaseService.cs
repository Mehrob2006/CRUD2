using Npgsql;
namespace Shopping_Project.Services;

public class DatabaseService
{
    public void CreateDatabase()
    {
        try
        {
            const string defaultconnectionstring =
                "Server = localhost; port = 5432; username = postgres; password = Progrmmer.33";

            using (NpgsqlConnection connection = new NpgsqlConnection(defaultconnectionstring))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "CREATE DATABASE Shopping";
                    command.ExecuteNonQuery();
                }
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}