using Patient_and_Pet_Management.Models;

namespace Patient_and_Pet_Management.Services;

public static class PatientService
{
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

    public static List<Patient> RegisterPatient(List<Patient> patients, Patient newPatient)
    {
        patients.Add(newPatient);
        return patients;
    }

    public static Patient? SearchPatient(List<Patient> patients, string name)
    {
        return patients.Find((patient) => patient.Name == name);
    }
}