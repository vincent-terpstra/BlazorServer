using System;
using System.Collections.Generic;
using DataAccess.DbAccess;
using DataAccess.Models;
using DataAccess.Services;
using Xunit;

namespace DataAccess.Tests;

public class UserServiceTests
{
    public UserServiceTests()
    {
        //TODO replace this with a moq
        ISqlDataAccess sqlDataAccess =
            new SqlDataAccess("Host=localhost:30432;Database=minimaldb;User ID=vince;Password=pwd;");
        _service = new UserService(sqlDataAccess);
    }
    private readonly IUserService _service;
    
    [Fact]
    public void AddPersonToList()
    {

        PersonModel person = new PersonModel()
        {
            firstname = "First",
            lastname = "last"
        };

        List<PersonModel> people = new();
        people.Add(person);

        Assert.True(people.Count == 1);
        Assert.Contains<PersonModel>(person, people);
    }
    
    [Theory]
    [InlineData("Vince", "", "LastName")]
    [InlineData("", "Terpstra", "FirstName")]
    public void AddPersonToList_ShouldFail(string firstname, string lastname, string argument)
    {

        PersonModel person = new PersonModel()
        {
            firstname = firstname,
            lastname = lastname
        };

        Assert.ThrowsAsync<ArgumentException>(argument, () => _service.InsertUserAsync(person));
    }
}