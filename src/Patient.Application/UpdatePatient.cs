using MediatR;
using Patient.Domain;

namespace Patient.Application;

public class UpdatePatient : IRequest<Guid>
{
    public Guid PatientId { get; set; }
    public string Name { get; set; }
    public string CPF { get; set; }
    public DateOnly Birth { get; set; }
}

public class UpdatePatientHandler(IPatientRepository patients) : IRequestHandler<UpdatePatient, Guid>
{
    public async Task<Guid> Handle(UpdatePatient request, CancellationToken cancellationToken)
    {
        var patient = await patients.GetAsync(request.PatientId, cancellationToken);
        patient.Name = request.Name;
        patient.CPF = request.CPF;
        patient.Birth = request.Birth;
        
        return patient.Id;
    }
}