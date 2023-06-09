using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

public class RoleRepository
{
    private readonly SqlConnection _connection;

    public RoleRepository(SqlConnection connection)
    {
        _connection = connection;
    }

    public IEnumerable<Role> Get() => _connection.GetAll<Role>();
    public Role Get(int id) => _connection.Get<Role>(id);
    public void Create(Role role) => _connection.Insert<Role>(role);
    
    public void Update(Role role) => _connection.Update<Role>(role);
    public void Delete(Role role) => _connection.Delete<Role>(role);
}