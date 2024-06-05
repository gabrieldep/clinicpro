using System.ComponentModel.DataAnnotations;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Person.Domain;
using Xunit;

namespace Person.RestApi.UnitTests;

public class LoginControllerTest
{
    private readonly LoginController _subject;
    private readonly Mock<ISender> _sender = new();
    private readonly Mock<IPersonRepository> _personRepository = new();

    public LoginControllerTest()
    {
        
        _subject = new LoginController(_sender.Object);
    }
    
    [Fact]
    public async Task PostAsync_ShouldReturnLoginSuccessfully()
    {
        // arrange
        _personRepository.Setup(s =>
            s.UserExists(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(true);
        
        // act
        var result = await _subject
            .PostAsync(new PersonInfoRequest()
            {
                User = "any",
                Password = "any" 
            }, CancellationToken.None);

        // assert
        result.Should().BeOfType<OkObjectResult>();
    }
    
    [Fact]
    public async Task PostAsync_ShouldReturnLoginWasNotSuccessfully()
    {
        // arrange
        _personRepository.Setup(s =>
            s.UserExists(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(false);
        
        // act
        var result = await _subject
            .PostAsync(new PersonInfoRequest()
            {
                User = "any",
                Password = "any" 
            }, CancellationToken.None);

        // assert
        result.Should().BeOfType<NotFoundObjectResult>();
    }
}