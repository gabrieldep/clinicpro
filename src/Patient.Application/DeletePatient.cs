using Appointment.Domain;
using MediatR;
using Patient.Domain;

namespace Patient.Application;

public class DeletePatient : IRequest<bool>
{
    public Guid PatientId { get; set; }
}

public class DeletePatientHandler(IPatientRepository patients, IAppointmentRepository appointments) : IRequestHandler<DeletePatient, bool>
{
    public async Task<bool> Handle(DeletePatient request, CancellationToken cancellationToken)
    {
        var patientAppointmentsId = (await appointments
            .GetPatientAppointments(request.PatientId, cancellationToken))
            .Select(pa => pa.PatientId);

        await appointments.DeleteAsync(patientAppointmentsId, cancellationToken);
        
        return await patients.DeleteAsync(request.PatientId, cancellationToken);
    }
}