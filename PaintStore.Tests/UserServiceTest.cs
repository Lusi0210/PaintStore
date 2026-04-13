using System;
using PaintStore.Repositories.Users;
using PaintStore.Services;
using Xunit;
using Moq;
using PaintStore.Models.Interfaces.Repositories;
using PaintStore.Models;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;



namespace PaintStore.Tests;

public class UserServiceTest
{
    private Mock<IUserRepository> _userRepositoryMock;
    public UserServiceTest()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
    }
    //Naming pattern for test method
    // what when should
    [Fact]
    public async Task CreateUserAsync_WhenUserRepositorySucceeds_ReturnNewUser()
    {
        //Arrange
        //prepare a new user mock data
        var user = new Models.User()
        {
            Id = 1,
            Name = "Lusi",
            Email = "111@gmail.com"
        };
        
        var userService = new UserService(_userRepositoryMock.Object);
        
        _userRepositoryMock.Setup(repo => repo.AddUserToDbAsync(It.IsAny<User>())).ReturnsAsync(user);
        //Act

        var result = await userService.CreateUserAsync(user);
        
        //Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(1);
        result.Email.Should().Be("111@gmail.com");
    }

    [Fact]
    public async Task CreateUserAsync_WhenUserRepoFailedToSave_ThrowException()
    {
        //Arrange
        var user = new Models.User()
        {
            Id = 1,
            Name = "Lusi",
            Email = "111@gmail.com"
        };

        var userService = new UserService(_userRepositoryMock.Object);
        _userRepositoryMock.Setup(repo => repo.AddUserToDbAsync(user)).ThrowsAsync(new DbUpdateException("Failed to save user to database"));

        //Act
        await Assert.ThrowsAsync<DbUpdateException>(() => userService.CreateUserAsync(user));
    }
}
