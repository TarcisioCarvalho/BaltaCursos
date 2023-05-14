using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

// See https://aka.ms/new-console-template for more information
    
const string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=balta;Trusted_Connection=True;MultipleActiveResultSets=True;";
using(var connection = new SqlConnection(connectionString))
{
   //UpdateCategory(connection);
  // DeleteCategory(connection);
  // CreateManyCategory(connection);
   //ListCategories(connection);

   //ExecuteProcedure(connection);
  // ExecuteReadProcedure(connection);
  //CreateCategoryScalar(connection);
   // OneToOne(connection);
     OneToMany(connection);
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


static void DeleteCategory(SqlConnection connection)
        {
            var deleteQuery = "DELETE [Category] WHERE [Id]=@id";
            var rows = connection.Execute(deleteQuery, new
            {
                id = new Guid("0a84a194-89be-453e-aa06-59582a3018e4"),
            });

            Console.WriteLine($"{rows} registros excluídos");
        }


 static void CreateManyCategory(SqlConnection connection)        {

            var category = new Category();
            category.Id = Guid.NewGuid();
            category.Title = "Amazon AWS";
            category.Url = "amazon";
            category.Description = "Categoria destinada a serviços do AWS";
            category.Order = 8;
            category.Summary = "AWS Cloud";
            category.Featured = false;

            var category2 = new Category();
            category2.Id = Guid.NewGuid();
            category2.Title = "Categoria Nova";
            category2.Url = "categoria-nova";
            category2.Description = "Categoria nova";
            category2.Order = 9;
            category2.Summary = "Categoria";
            category2.Featured = true;

            var insertSql = @"INSERT INTO 
                    [Category] 
                VALUES(
                    @Id, 
                    @Title, 
                    @Url, 
                    @Summary, 
                    @Order, 
                    @Description, 
                    @Featured)";

            var rows = connection.Execute(insertSql, new[]{
                new
                {
                    category.Id,
                    category.Title,
                    category.Url,
                    category.Summary,
                    category.Order,
                    category.Description,
                    category.Featured
                },
                new
                {
                    category2.Id,
                    category2.Title,
                    category2.Url,
                    category2.Summary,
                    category2.Order,
                    category2.Description,
                    category2.Featured
                }
            });
            Console.WriteLine($"{rows} linhas inseridas");
        }

static void ExecuteProcedure(SqlConnection connection)
{
  var sql = "[spDeleteStudent]";
  var pars = new { StudentId = "c55390d4-71dd-4f3c-b978-d1582f51a327" };
  var affectedRows = connection.Execute(sql,pars,commandType:CommandType.StoredProcedure);

  System.Console.WriteLine($"Linhas afetadas {affectedRows}");
}

static void ExecuteReadProcedure(SqlConnection connection)
{
  var sql = "[spGetCoursesByCategory]";
  var pars = new { CategoryId = "09ce0b7b-cfca-497b-92c0-3290ad9d5142" };
  var courses = connection.Query(sql,pars,commandType:CommandType.StoredProcedure);

  

  foreach (var course in courses)
  {
    System.Console.WriteLine($"{course.Id}");
  }
}

static void CreateCategoryScalar(SqlConnection connection)
{
  var category = new Category();
    
    category.Title = "AWS";
    category.Order = 8;
    category.Url = "amazon";
    category.Description = "categoria destinada a serviço";
    category.Summary = "AWS cloud";
    category.Featured = false;

    var insertSql = @"INSERT INTO [CATEGORY]
    OUTPUT inserted.[Id]
     VALUES (
      NEWID(),
      @Title,
      @Url,
      @Summary,
      @Order,
      @Description,
      @Featured)";

    var id = connection.ExecuteScalar<Guid>(insertSql,new {
      category.Title,
      category.Url,
      category.Summary,
      category.Order,
      category.Description,
      category.Featured
    });
    System.Console.WriteLine($"A categoria Inserida foi {id}");
}

static void OneToOne(SqlConnection connection)
{
  var sql = @"
  SELECT 
  *
  FROM 
    [CAREERITEM]
  INNER JOIN [COURSE] ON [CAREERITEM].[COURSEID] = [COURSE].[ID]
  ";
  var itens = connection.Query<CarrerItem,Course,CarrerItem>(
    sql,
    (carrerItem,course) => 
    {
      carrerItem.Course = course;
      return carrerItem;
    },splitOn:"Id");

    foreach (var item in itens)
    {
      System.Console.WriteLine($"{item.Course.Title}");
    }
}

static void OneToMany(SqlConnection connection)
{
  var sql = @"
  SELECT 
      [Career].[Id],
      [Career].[Title],
      [CareerItem].[CareerId],
      [CareerItem].[Title]
  FROM 
      [Career] 
  INNER JOIN 
      [CareerItem] ON [CareerItem].[CareerId] = [Career].[Id]
  ORDER BY
      [Career].[Title]
  ";
  var careers = connection.Query<Career,CarrerItem,Career>(
    sql,
    (career,item) => 
    {
      return career;
    },splitOn:"CareerId");

    foreach (var career in careers)
    {
      System.Console.WriteLine($"{career.Title}");
      foreach (var item in career.Itens)
      {
        System.Console.WriteLine($"{item.Title}");
      }
    }
}
//spGetCoursesByCategory