using Dapper;
using Microsoft.Data.SqlClient;

// See https://aka.ms/new-console-template for more information
const string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=balta;Trusted_Connection=True;MultipleActiveResultSets=True;";
using(var connection = new SqlConnection(connectionString))
{
    System.Console.WriteLine("Conectado");
    connection.Open();
    var category = new Category();
    var insertSql = "INSERT INTO [CATEGORY] VALUES (id,title,url,summary,order,description,featured)";
    
    using (var command = new SqlCommand())
    {
		//Teste
       var categories = connection.Query<Category>("SELECT [ID],[TITLE] FROM CATEGORY");
       foreach (var item in categories)
       {
            System.Console.WriteLine($"{item.Id} --- {item.Title}");
       }
    }
}


