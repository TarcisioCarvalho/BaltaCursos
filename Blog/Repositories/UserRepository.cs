using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

public class UserRepository
{
    private readonly SqlConnection _connection;

    public UserRepository(SqlConnection connection)
    {
        _connection = connection;
    }

    public IEnumerable<User> Get() => _connection.GetAll<User>();
    
}