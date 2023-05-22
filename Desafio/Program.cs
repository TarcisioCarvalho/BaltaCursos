// See https://aka.ms/new-console-template for more information

using Blog.Screens.TagScreens;
using Microsoft.Data.SqlClient;

const string CONNECTION_STRING = "Server=(localdb)\\MSSQLLocalDB;Database=Blog;Trusted_Connection=True;MultipleActiveResultSets=True;";
Database.Connection = new SqlConnection(CONNECTION_STRING);

Database.Connection.Open();

Load();

Console.ReadKey();
Database.Connection.Close();

static void Load()
        {
            Console.Clear();
            Console.WriteLine("Meu Blog");
            Console.WriteLine("-----------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Gestão de usuário");
            Console.WriteLine("2 - Gestão de perfil");
            Console.WriteLine("3 - Gestão de categoria");
            Console.WriteLine("4 - Gestão de tag");
            Console.WriteLine("5 - Vincular perfil/usuário");
            Console.WriteLine("6 - Vincular post/tag");
            Console.WriteLine("7 - Relatórios");
            Console.WriteLine();
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 4:
                    MenuTagScreen.Load();
                    break;
                default: Load(); break;
            }
        }
