using Appointment.Domain;
using Doctor.Application.DTOs;
using MediatR;
using static System.DateTime;

namespace Doctor.Application;

public class GetAppointmentTimes : IRequest<DoctorSchedule>
{
    public Guid DoctorId { get; set; }
}

public class GetAppointmentTimesHandler(IAppointmentRepository appointments) : IRequestHandler<GetAppointmentTimes, DoctorSchedule>
{
    /// <summary>
    /// Assuming that the doctor works 8 hours a day from 8 am to 12 pm and from 1 pm to 5 pm and that each appointment lasts 1 hour.
    /// Also assuming that the agenda is always open up to 30 days from today.
    /// </summary>
    /// <param name="request">DoctorId info</param>
    /// <param name="cancellationToken">cancellationToken</param>
    /// <returns>A list of available times </returns>
    public async Task<DoctorSchedule> Handle(GetAppointmentTimes request, CancellationToken cancellationToken)
    {
        var appointmentsScheduled = await appointments.GetAppointmentsFromNow(request.DoctorId, cancellationToken);
        var finalAgendaDate = Now.AddDays(30);

        var availableTimes = GetAllAppointmentTimes(appointmentsScheduled, DateTime.Now, finalAgendaDate);

        return new DoctorSchedule { DoctorId = request.DoctorId, AvailableTimes = availableTimes };
    }

    private static List<AppointmentTime> GetAllAppointmentTimes(IEnumerable<Appointment.Domain.Appointment> appointmentsScheduled , DateTime start, DateTime end)
    {
        var today = DateOnly.FromDateTime(DateTime.Now);
        var startWorkingHoursMorning = new DateTime(today, new TimeOnly(8, 0), DateTimeKind.Local);
        var endWorkingHoursMorning = new DateTime(today, new TimeOnly(12, 0), DateTimeKind.Local);
        var startWorkingHoursAfternoon = new DateTime(today, new TimeOnly(13, 0), DateTimeKind.Local);
        var endWorkingHoursAfternoon = new DateTime(today, new TimeOnly(17, 0), DateTimeKind.Local);
        
        var availableTimes = new List<AppointmentTime>();
        var appointmentsList = appointmentsScheduled.ToList();

        for (var currentDate = DateTime.Now; currentDate <= end; currentDate = currentDate.AddDays(1))
        {
            var morningAppointments = appointmentsList
                .Count(a => a.MedicalSchedule.Date == currentDate 
                            && a.MedicalSchedule >= startWorkingHoursMorning 
                            && a.MedicalSchedule < endWorkingHoursMorning);

            var afternoonAppointments = appointmentsList
                .Count(a => 
                    a.MedicalSchedule.Date == currentDate 
                    && a.MedicalSchedule >= startWorkingHoursAfternoon 
                    && a.MedicalSchedule < endWorkingHoursAfternoon);

            for (var time = startWorkingHoursMorning; time < endWorkingHoursMorning; time = time.AddHours(1))
                if (morningAppointments < 4 && time >= DateTime.Now)
                    availableTimes.Add(new AppointmentTime { Schedule = time });

            for (var time = startWorkingHoursAfternoon; time < endWorkingHoursAfternoon; time = time.AddHours(1))
                if (afternoonAppointments < 4 && time >= DateTime.Now)
                    availableTimes.Add(new AppointmentTime { Schedule = time });
        }
        return availableTimes;
    }
}