using Appointment.Domain;
using Doctor.Application.DTOs;
using MediatR;
using static System.DateTime;

namespace Doctor.Application;

public class GetAppointmentTimes : IRequest<DoctorSchedule>
{
    public Guid DoctorId { get; set; }
}

public class GetAppointmentTimesHandler(IAppointmentRepository appointments)
    : IRequestHandler<GetAppointmentTimes, DoctorSchedule>
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

        var availableTimes = GetAllAppointmentTimes(appointmentsScheduled, finalAgendaDate);

        return new DoctorSchedule { DoctorId = request.DoctorId, AvailableTimes = availableTimes };
    }

    private static List<AppointmentTime> GetAllAppointmentTimes(
        IEnumerable<Appointment.Domain.Appointment> appointmentsScheduled, DateTime end)
    {
        var startWorkingHoursMorning = new TimeSpan(8, 0, 0);
        var endWorkingHoursMorning = new TimeSpan(12, 0, 0);
        var startWorkingHoursAfternoon = new TimeSpan(13, 0, 0);
        var endWorkingHoursAfternoon = new TimeSpan(17, 0, 0);

        var availableTimes = new List<AppointmentTime>();
        var appointmentsList = appointmentsScheduled.ToList();

        for (var currentDate = DateTime.Now.Date; currentDate <= end; currentDate = currentDate.AddDays(1))
        {
            var todayAppointments = appointmentsList.Where(a => a.MedicalSchedule.Date == currentDate).ToList();

            for (var time = startWorkingHoursMorning;
                 time < endWorkingHoursMorning;
                 time = time.Add(TimeSpan.FromHours(1)))
                if (currentDate.AddTicks(time.Ticks) > DateTime.Now
                    && todayAppointments.All(ta => ta.MedicalSchedule.TimeOfDay != time))
                    availableTimes.Add(new AppointmentTime { Schedule = currentDate.AddTicks(time.Ticks) });

            for (var time = startWorkingHoursAfternoon;
                 time < endWorkingHoursAfternoon;
                 time = time.Add(TimeSpan.FromHours(1)))
                if (currentDate.AddTicks(time.Ticks) > DateTime.Now
                    && todayAppointments.All(ta => ta.MedicalSchedule.TimeOfDay != time))
                    availableTimes.Add(new AppointmentTime { Schedule = currentDate.AddTicks(time.Ticks) });
        }

        return availableTimes;
    }
}