using Dapper;
using Microsoft.Data.SqlClient;

// See https://aka.ms/new-console-template for more information
const string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=balta;Trusted_Connection=True;MultipleActiveResultSets=True;";
using(var connection = new SqlConnection(connectionString))
{
    System.Console.WriteLine("Conectado");
    connection.Open();
    
    using (var command = new SqlCommand())
    {
		//Teste
       var categories = connection.Query<Category>("SELECT [ID],[TITLE] FROM CATEGORY");
       foreach (var category in categories)
       {
            System.Console.WriteLine($"{category.Id} --- {category.Title}");
       }
    }
}


