using Patient_and_Pet_Management.Models;
using Patient_and_Pet_Management.Repositories;

namespace Patient_and_Pet_Management.Services;

public class AppointmentService
{
    private static AppointmentRepository _appointmentRepository = new AppointmentRepository();

    public static void CreateAppointment(string subject, string veterinaryName, string petName, string symptoms,
        string date)
    {
        if (string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(veterinaryName) || string.IsNullOrEmpty(petName) ||
            string.IsNullOrEmpty(symptoms) || string.IsNullOrEmpty(date))
        {
            Console.WriteLine("Invalid Information");
            return;
        }

        // Validate veterinary and pet
        var veterinary = VeterinaryService.GetVeterinaryByName(veterinaryName);
        var pet = PetService.GetPetByName(petName);
        if (veterinary == null)
        {
            Console.WriteLine("No Veterinary found");
            return;
        }

        if (pet == null)
        {
            Console.WriteLine("No Pet found");
            return;
        }

        if (!DateTime.TryParse(date, out var dateTime))
        {
            Console.WriteLine("Invalid Date");
            return;
        }


        try
        {
            Appointment newAppointment = new Appointment(subject, veterinary, pet, symptoms, dateTime);

            // Validate date
            var appointments = _appointmentRepository.Get();

            bool hasConflict = appointments.Any(a =>
                a.Veterinary.Id == newAppointment.Veterinary.Id &&
                (
                    (newAppointment.Date >= a.Date &&
                     newAppointment.Date < a.Date + TimeSpan.FromHours(1)) || // empieza dentro de otra cita
                    (a.Date >= newAppointment.Date &&
                     a.Date < newAppointment.Date + TimeSpan.FromHours(1)) // otra cita empieza dentro de esta
                )
            );

            if (hasConflict)
            {
                Console.WriteLine("There is already an appointment at that time for this veterinarian");
            }

            _appointmentRepository.Create(newAppointment);
            Console.WriteLine("Appointment created successfully");
        }
        catch (Exception err)
        {
            Console.WriteLine("Error creating appointment", err);
        }
    }

    public static List<Appointment> GetAppointments()
    {
        try
        {
            return _appointmentRepository.Get();
        }
        catch (Exception err)
        {
            Console.WriteLine("Error getting Appointments", err);
            return [];
        }
    }

    public static Appointment? GetAppointmentById(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            Console.WriteLine("Invalid Id");
            return null;
        }

        try
        {
            return _appointmentRepository.GetById(id);
        }
        catch (Exception err)
        {
            Console.WriteLine("Error getting appointment by id", err);
            return null;
        }
    }

    public static Appointment? GetAppointmentByName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Invalid name");
            return null;
        }

        try
        {
            return _appointmentRepository.GetByName(name);
        }
        catch (Exception err)
        {
            Console.WriteLine("Error getting appointment by name", err);
            return null;
        }
    }

    public static void UpdateAppointment(string id, string subject, string veterinaryName, string petName,
        string symptoms,
        string date)
    {
        if (string.IsNullOrEmpty(id))
        {
            Console.WriteLine("Invalid Id");
            return;
        }

        if (string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(veterinaryName) || string.IsNullOrEmpty(petName) ||
            string.IsNullOrEmpty(symptoms) || string.IsNullOrEmpty(date))
        {
            Console.WriteLine("Invalid Information");
            return;
        }

        // Validate veterinary and pet
        var veterinary = VeterinaryService.GetVeterinaryByName(veterinaryName);
        var pet = PetService.GetPetByName(petName);
        if (veterinary == null)
        {
            Console.WriteLine("No Veterinary found");
            return;
        }

        if (pet == null)
        {
            Console.WriteLine("No Pet found");
            return;
        }

        if (!DateTime.TryParse(date, out var dateTime))
        {
            Console.WriteLine("Invalid Date");
            return;
        }

        try
        {
            Appointment newAppointment = new Appointment(subject, veterinary, pet, symptoms, dateTime);

            // Validate date
            var appointments = _appointmentRepository.Get();

            bool hasConflict = appointments.Any(a =>
                a.Veterinary.Id == newAppointment.Veterinary.Id &&
                (
                    (newAppointment.Date >= a.Date &&
                     newAppointment.Date < a.Date + TimeSpan.FromHours(1)) || // empieza dentro de otra cita
                    (a.Date >= newAppointment.Date &&
                     a.Date < newAppointment.Date + TimeSpan.FromHours(1)) // otra cita empieza dentro de esta
                )
            );

            if (hasConflict)
            {
                Console.WriteLine("There is already an appointment at that time for this veterinarian");
            }

            _appointmentRepository.Update(id, newAppointment);
            Console.WriteLine("Appointment updated successfully");
        }
        catch (Exception err)
        {
            Console.WriteLine("Error updating appointment", err);
        }
    }

    public static void RemoveAppointment(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            Console.WriteLine("Invalid id");
            return;
        }

        try
        {
            _appointmentRepository.Remove(id);
            Console.WriteLine("Appointment removed successfully");
        }
        catch (Exception err)
        {
            Console.WriteLine("Error deleting appointment", err);
        }
    }
}