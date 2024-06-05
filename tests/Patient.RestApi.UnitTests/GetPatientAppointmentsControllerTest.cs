using Appointment.Application.DTOs;
using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Patient.Application;
using Patient.Application.DTOs;
using Patient.Application.Validators;
using Xunit;

namespace Patient.RestApi.UnitTests;

public class GetPatientAppointmentsControllerTests
{
    private readonly GetPatientAppointmentsController _subject;
    private readonly Mock<ISender> _senderMock = new();
    private readonly Mock<IValidator<PatientAppointments>> _validator = new();

    public GetPatientAppointmentsControllerTests()
    {
        _subject = new GetPatientAppointmentsController(_senderMock.Object, _validator.Object);
    }

    [Fact]
    public async Task GetAsync_WithValidPatientId_ShouldReturnOkWithPatientAppointmentsDTO()
    {
        // Arrange
        var doctor = new Doctor.Domain.Doctor()
        {
            Name = "Doctor name",
            Password = "pass",
            UserName = "doctor_name",
            CPF = "123.456.789-10"
        };
        var patient = new Domain.Patient
        {
            Name = "Test Patient",
            Password = "pass",
            UserName = "test_patient",
            CPF = "987.654.321-00"
        };

        var patientAppointments = new List<Appointment.Domain.Appointment>
        {
            new()
            {
                PatientId = patient.Id,
                MedicalSchedule = new DateTime(3000, 12, 1, 8, 0, 0, DateTimeKind.Local),
                Doctor = doctor,
                Patient = patient
            },
            new()
            {
                PatientId = patient.Id,
                MedicalSchedule = new DateTime(3000, 12, 2, 9, 0, 0, DateTimeKind.Local),
                Doctor = doctor,
                Patient = patient
            },
            new()
            {
                PatientId = patient.Id,
                MedicalSchedule = new DateTime(3000, 12, 3, 10, 0, 0, DateTimeKind.Local),
                Doctor = doctor,
                Patient = patient
            }
        };
        
        var expectedResult = new PatientAppointmentsDTO
        {
            PatientId = patient.Id,
            PatientName = "Test name",
            AppointmentDtos = patientAppointments.Select(pa =>
                new AppointmentDTO
                {
                    PatientId = pa.PatientId,
                    PatientName = pa.Patient.Name,
                    DoctorName = pa.Doctor.Name,
                    MedicalSchedule = pa.MedicalSchedule
                }).ToList()
        };
        
        _senderMock.Setup(s => s.Send(It.IsAny<GetPatientAppointments>(), default))
            .ReturnsAsync(expectedResult);
        
        _validator.Setup(v => 
                v.ValidateAsync(It.IsAny<PatientAppointments>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ValidationResult());
        
        // Act
        var result = await _subject.GetAsync(patient.Id, CancellationToken.None);

        // Assert
        result.Should().BeOfType<OkObjectResult>()
            .Which.Value.Should().BeEquivalentTo(expectedResult);
    }

    [Fact]
    public async Task GetAsync_WithInvalidPatientId_ShouldReturnNotFound()
    {
        // Arrange
        var patientId = Guid.NewGuid();
        var validationResult = new ValidationResult();
        validationResult.Errors.Add(new ValidationFailure("", "Invalid patient ID"));
        _validator.Setup(v => v.ValidateAsync(It.IsAny<PatientAppointments>(), default))
            .ReturnsAsync(validationResult);

        // Act
        var result = await _subject.GetAsync(patientId, CancellationToken.None);

        // Assert
        result.Should().BeOfType<NotFoundObjectResult>();
    }
}