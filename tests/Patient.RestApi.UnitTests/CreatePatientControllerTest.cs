using Core.RestApi.Filters;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Patient.Application;
using Person.Domain;
using Xunit;

namespace Patient.RestApi.UnitTests
{
    public class CreatePatientControllerTests
    {
        private readonly CreatePatientController _subject;
        private readonly Mock<ISender> _senderMock = new();

        public CreatePatientControllerTests()
        {
            _subject = new CreatePatientController(_senderMock.Object);
        }

        [Fact]
        public async Task PostAsync_WithValidRequest_ShouldReturnOkWithPatientId()
        {
            // Arrange
            var expectedPatientId = Guid.NewGuid();
            var request = new CreatePatientInfoRequest
            {
                User = "test_user",
                Password = "test_password",
                Name = "Test Patient",
                CPF = "12345678901",
                Birth = new BirthDate { Year = 1990, Month = 5, Day = 15 }
            };
            _senderMock.Setup(s => s.Send(It.IsAny<CreatePatient>(), default))
                       .ReturnsAsync(expectedPatientId);

            // Act
            var result = await _subject.PostAsync(request, default);

            // Assert
            result.Should().BeOfType<OkObjectResult>()
                  .Which.Value.Should().Be(expectedPatientId);
        }

        [Fact]
        public async Task PostAsync_WithInvalidRequest_ShouldReturnBadRequest()
        {
            // Arrange
            var request = new CreatePatientInfoRequest
            {
                User = "test_user",
                Password = "test_password"
            };

            // Act
            var result = await _subject.PostAsync(request, default);

            // Assert
            result.Should().BeOfType<BadRequestObjectResult>();
        }
    }
}
