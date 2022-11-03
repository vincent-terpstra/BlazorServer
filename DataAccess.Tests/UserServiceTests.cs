using DataAccess.DbAccess;
using DataAccess.Services;
using Xunit;

namespace DataAccess.Tests;

public class UserServiceTests
{
    public UserServiceTests()
    {
        ISqlDataAccess sqlDataAccess =
            new SqlDataAccess("Host=localhost:30432;Database=minimaldb;User ID=vince;Password=pwd;");
        _service = new UserService(sqlDataAccess);
    }
    private IUserService _service;
    
    [Fact]
    public void AddPersonToList()
    {
        
    }
}