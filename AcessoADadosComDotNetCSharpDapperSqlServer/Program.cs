using Microsoft.Data.SqlClient;

// See https://aka.ms/new-console-template for more information
const string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=balta;Trusted_Connection=True;MultipleActiveResultSets=True;";
using(var connection = new SqlConnection(connectionString))
{
    System.Console.WriteLine("Conectado");
    connection.Open();
    
    using (var command = new SqlCommand())
    {
        command.Connection = connection;
        command.CommandType = System.Data.CommandType.Text;
        command.CommandText = "SELECT [ID],[TITLE] FROM [CATEGORY]";
        var reader = command.ExecuteReader();
        while(reader.Read())
        {
            System.Console.WriteLine($"{reader.GetGuid(0)} -- {reader.GetString(1)}");
        }
    }
}


