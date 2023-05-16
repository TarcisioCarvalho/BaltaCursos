// See https://aka.ms/new-console-template for more information
using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

const string CONNECTION_STRING = "Server=(localdb)\\MSSQLLocalDB;Database=Blog;Trusted_Connection=True;MultipleActiveResultSets=True;";

 static void ReadUsers()
{
    using (var connection = new SqlConnection(CONNECTION_STRING))
    {
        var users = connection.GetAll<User>();
    }
}