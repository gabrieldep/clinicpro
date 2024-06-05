using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Patient.Application;
using Patient.Application.Validators;
using Xunit;

namespace Patient.RestApi.UnitTests
{
    public class DeletePatientControllerTest
    {
        private readonly DeletePatientController _subject;
        private readonly Mock<ISender> _senderMock = new();
        private readonly Mock<IValidator<DeletePatientInfo>> _validator = new();


        public DeletePatientControllerTest()
        {
            _subject = new DeletePatientController(_senderMock.Object, _validator.Object);
        }

        [Fact]
        public async Task DeleteAsync_WithValidRequest_ShouldReturnOk()
        {
            // Arrange
            var expectedPatientId = Guid.NewGuid();

            _senderMock.Setup(s => s.Send(It.IsAny<DeletePatient>(), default))
                       .ReturnsAsync(true);

            // Act
            var result = await _subject.DeleteAsync(expectedPatientId, default);

            // Assert
            result.Should().BeOfType<OkObjectResult>()
                  .Which.Value.Should().Be(expectedPatientId);
        }

        [Fact]
        public async Task DeleteAsync_WithInvalidRequest_ShouldReturnNotFound()
        {
            // Arrange
            var patientId = Guid.NewGuid();

            _validator.Setup(v => 
                    v.ValidateAsync(It.IsAny<DeletePatientInfo>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ValidationResult(new List<ValidationFailure>(){new ValidationFailure()}));

            // Act
            var result = await _subject.DeleteAsync(patientId, default);

            // Assert
            result.Should().BeOfType<NotFoundObjectResult>();
        }
    }
}
