using Patient_and_Pet_Management.Data;
using Patient_and_Pet_Management.Interfaces;
using Patient_and_Pet_Management.Models;

namespace Patient_and_Pet_Management.Repositories;

public class AppointmentRepository : ICreate<Appointment>, IGet<Appointment>, IUpdate<Appointment>, IRemove
{
    public AppointmentRepository()
    {
    }

    public void Create(Appointment appointment)
    {
        Database.Appoitments.Add(appointment);
    }

    public List<Appointment> Get()
    {
        return Database.Appoitments;
    }

    public Appointment? GetById(string id)
    {
        return Database.Appoitments.Find((appointment => appointment.Id.ToString() == id));
    }

    public Appointment? GetByName(string subject)
    {
        return Database.Appoitments.Find((appointment => appointment.Subject == subject));
    }

    public void Update(string id, Appointment appointment)
    {
        Database.Appoitments =
            Database.Appoitments.Select((appo => appo.Id.ToString() == id ? appointment : appo)).ToList();
    }

    public void Remove(string id)
    {
        Database.Appoitments = Database.Appoitments.Where((appointment => appointment.Id.ToString() != id)).ToList();
    }
}