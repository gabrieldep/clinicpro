using MediatR;
using Patient.Domain;

namespace Patient.Application;

public class DeletePatient : IRequest<bool>
{
    public Guid PatientId { get; set; }
}

public class DeletePatientHandler(IPatientRepository patients) : IRequestHandler<DeletePatient, bool>
{
    public async Task<bool> Handle(DeletePatient request, CancellationToken cancellationToken)
    {
        return await patients.DeleteAsync(request.PatientId, cancellationToken);
    }
}