using Patient_and_Pet_Management.Models;

namespace Patient_and_Pet_Management.Services;

public static class PatientService
{
    // Show in console all patients in a list
    public static void ListPatients(List<Patient> patients)
    {
        if (patients.Count == 0)
        {
            Console.WriteLine("Theres no patients on list");
            return;
        }

        foreach (var patient in patients)
        {
            Console.WriteLine($"Name: {patient.Name}, Age: {patient.Age}, Symptoms: {patient.Symptom}");
        }
    }

    // Register a patient and return a new list with the new patient
    public static List<Patient> RegisterPatient(List<Patient> patients, Patient newPatient)
    {
        patients.Add(newPatient);
        Console.WriteLine("Patient added successfully");
        return patients;
    }

    // Search a patient and return it if it is in the list
    public static void SearchPatient(List<Patient> patients, string name)
    {
        var patient = patients.Find((patient) => patient.Name.Trim().ToLower() == name.Trim().ToLower());

        if (patient is null)
        {
            Console.WriteLine("We can't find a user with that name");
            return;
        }

        Console.WriteLine($"Name: {patient.Name}, Age: {patient.Age}, Symptoms: {patient.Symptom}");
    }
}