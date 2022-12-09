using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.DbAccess;
using DataAccess.Services;
using Domain.Models;
using Moq;
using Xunit;

namespace DataAccess.Tests;

public class UserServiceTests
{
    //HACK - because I am using stored procedures with dynamic parameters 
    //IsAny matches any type
    public It.IsAnyType IsAny => It.IsAny<It.IsAnyType>();
    
    public UserServiceTests()
    {
        _mock = new Mock<ISqlDataAccess>();
        _userservice = new UserServiceDapper(_mock.Object);
    }
    private readonly IUserService _userservice;
    private Mock<ISqlDataAccess> _mock;

    [Fact]
    public async Task GetUsersAsync_ShouldReturnUsers()
    {
        //Arrange
        IEnumerable<PersonModel> models = new[]
        {
            new PersonModel()
            {
                Firstname = "first person",
                Lastname = "last"
            },
            new PersonModel()
            {
                Firstname = "second person",
                Lastname = "last"
            }
        };
        var setup = _mock.Setup(
            x =>  x.LoadDataAsync<PersonModel, dynamic>("user_getall", IsAny))
                .Returns(Task.FromResult(models));
        
        //Act
        IEnumerable<PersonModel> actual = await _userservice.GetUsersAsync();
        
        //Assert
        Assert.True(actual != null);
        Assert.Equal(models, actual);
        
        _mock.Verify(x=> x.LoadDataAsync<PersonModel,dynamic>("user_getall", IsAny), Times.Once);
    }

    [Fact]
    public async Task AddPerson_Success()
    {
        //Arrange
        PersonModel person = new PersonModel()
        {
            Firstname = "First",
            Lastname = "last"
        };
        _mock.Setup(x => x.SaveDataAsync("user_create", IsAny));
        
        //Act
        await _userservice.InsertUserAsync(person);
        
        //Assert
        _mock.Verify(x => x.SaveDataAsync("user_create", IsAny), Times.Once);
    }
    
    [Theory]
    [InlineData("Vince", "", "LastName")]
    [InlineData("", "Terpstra", "FirstName")]
    public void AddPersonToList_ShouldFail(string firstname, string lastname, string argument)
    {
        //Arrange
        PersonModel person = new PersonModel()
        {
            Firstname = firstname,
            Lastname = lastname
        };
        _mock.Setup(x => x.SaveDataAsync("user_create", IsAny));
        //Act
        
        //Assert
        Assert.ThrowsAsync<ArgumentException>(argument, () => _userservice.InsertUserAsync(person));
        _mock.Verify(x => x.SaveDataAsync("user_create", IsAny), Times.Never);
    }
}