// See https://aka.ms/new-console-template for more information
using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

const string CONNECTION_STRING = "Server=(localdb)\\MSSQLLocalDB;Database=Blog;Trusted_Connection=True;MultipleActiveResultSets=True;";
using var connection = new SqlConnection(CONNECTION_STRING);
//ReadUsers(connection);
ReadRoles(connection);


   void ReadUsers(SqlConnection connection)
{
        var userRepository =  new UserRepository(connection);
        var users = userRepository.Get();

        foreach (var user in users)
        System.Console.WriteLine($"{user.Id}---{user.Name}");
}

   void ReadRoles(SqlConnection connection)
{
        var roleRepository =  new RoleRepository(connection);
        var roles = roleRepository.Get();

        foreach (var role in roles)
        System.Console.WriteLine($"{role.Id}---{role.Name}");
}

 
        /* static void ReadUser(Repository<User> repository)
        {
            var user = repository.Read(2);
            Console.WriteLine(user?.Email);
        }

         static void UpdateUser(Repository<User> repository)
        {
            var user = repository.Read(2);
            user.Email = "hello@balta.io";
            repository.Update(user);

            Console.WriteLine(user?.Email);
        }

         static void DeleteUser(Repository<User> repository)
        {
            var user = repository.Read(2);
            repository.Delete(user);
        } */