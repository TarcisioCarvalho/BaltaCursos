using Dapper;
using Microsoft.Data.SqlClient;

// See https://aka.ms/new-console-template for more information
    
const string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=balta;Trusted_Connection=True;MultipleActiveResultSets=True;";
using(var connection = new SqlConnection(connectionString))
{
   UpdateCategory(connection);
   ListCategories(connection);
}


static void ListCategories(SqlConnection connection)
{
   var categories = connection.Query<Category>("SELECT [ID],[TITLE] FROM CATEGORY");
       foreach (var item in categories)
       {
            System.Console.WriteLine($"{item.Id} --- {item.Title}");
       }
}

static void CreateCategory(SqlConnection connection)
{
  var category = new Category();
    
    category.Id = Guid.NewGuid();
    category.Title = "AWS";
    category.Order = 8;
    category.Url = "amazon";
    category.Description = "categoria destinada a serviço";
    category.Summary = "AWS cloud";
    category.Featured = false;

    var insertSql = @"INSERT INTO [CATEGORY]
     VALUES (
      @Id,
      @Title,
      @Url,
      @Summary,
      @Order,
      @Description,
      @Featured)";

    var rows = connection.Execute(insertSql,new {
      category.Id,
      category.Title,
      category.Url,
      category.Summary,
      category.Order,
      category.Description,
      category.Featured
    });
    System.Console.WriteLine($"Linhas inseridas {rows}");
}

static void UpdateCategory(SqlConnection connection)
{
  var updateQuery = "UPDATE [CATEGORY] SET TITLE = @Title WHERE ID = @id";
  var rows = connection.Execute(updateQuery,new {
    id = new Guid("af3407aa-11ae-4621-a2ef-2028b85507c4"),
    Title = "Frontend 2023"
  });

  System.Console.WriteLine($"Registros atualizados {rows}");
}