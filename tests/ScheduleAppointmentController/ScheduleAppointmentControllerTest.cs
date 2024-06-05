using Appointment.Application;
using Appointment.RestApi;
using Core.RestApi.Filters;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Person.Domain;
using Xunit;

namespace Patient.RestApi.UnitTests;

public class ScheduleAppointmentControllerTests
{
    private readonly ScheduleAppointmentController _subject;
    private readonly Mock<ISender> _senderMock = new();

    public ScheduleAppointmentControllerTests()
    {
        _subject = new ScheduleAppointmentController(_senderMock.Object);
    }

    [Fact]
    public async Task PostAsync_WithValidRequest_ShouldReturnOkWithAppointmentId()
    {
        // Arrange
        var patientId = Guid.NewGuid();
        var doctorId = Guid.NewGuid();
        var medicalSchedule = DateTime.Now.AddHours(1); // Example: 1 hour from now
        var request = new AppointmentRequest
        {
            PatientId = patientId,
            DoctorId = doctorId,
            MedicalSchedule = medicalSchedule
        };
        var expectedAppointmentId = Guid.NewGuid();
        _senderMock.Setup(s => s.Send(It.IsAny<CreateAppointment>(), default))
            .ReturnsAsync(expectedAppointmentId);

        // Act
        var result = await _subject.PostAsync(request, default);

        // Assert
        result.Should().BeOfType<OkObjectResult>()
            .Which.Value.Should().Be(expectedAppointmentId);
    }
}