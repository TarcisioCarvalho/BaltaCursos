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
    public User Get(int id) => _connection.Get<User>(id);
    public void Create(User user) => _connection.Insert<User>(user);
    public void Update(User user) => _connection.Update<User>(user);
    public void Delete(User user) => _connection.Delete<User>(user);
    
}