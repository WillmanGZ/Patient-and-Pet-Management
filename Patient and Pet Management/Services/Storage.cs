using Patient_and_Pet_Management.Models;

namespace Patient_and_Pet_Management.Services;

public static class Storage
{
    private static readonly List<Patient> Patients = new();
    private static readonly List<Pet> Pets = new();

    public static List<Patient> GetAllPatients()
    {
        return Patients;
    }

    public static List<Pet> GetAllPets()
    {
        return Pets;
    }

    public static void AddPatient(Patient patient)
    {
        if (patient == null)
            throw new ArgumentNullException(nameof(patient));

        if (Patients.Any(p => p.GetName().Equals(patient.GetName(), StringComparison.OrdinalIgnoreCase)))
            throw new InvalidOperationException($"Patient with Name '{patient.GetName()}' already exists.");

        Patients.Add(patient);
        Console.WriteLine($"Patient '{patient.GetName()}' added successfully.");
    }

    public static void AddPet(Pet pet)
    {
        if (pet == null)
            throw new ArgumentNullException(nameof(pet));
        if (Pets.Any(p => p.GetName().Equals(pet.GetName(), StringComparison.OrdinalIgnoreCase)))
            throw new InvalidOperationException($"Pet with Name '{pet.GetName()}' already exists.");
        Pets.Add(pet);
        Console.WriteLine($"Pet '{pet.GetName()}' added successfully.");
    }

    public static Patient? FindPatientByName(string name)
    {
        return Patients.FirstOrDefault(p => p.GetName().Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    public static Pet? FindPetByName(string name)
    {
        return Pets.FirstOrDefault(p => p.GetName().Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    public static void RemovePatient(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException(nameof(name));

        var patientToRemove = Patients
            .FirstOrDefault(p => p.GetName().Equals(name, StringComparison.OrdinalIgnoreCase));

        if (patientToRemove == null)
            throw new InvalidOperationException($"Patient with Name '{name}' not found.");

        Patients.Remove(patientToRemove);

        foreach (var pet in Pets.Where(p =>
                         p.GetOwner().GetName().Equals(patientToRemove.GetName(), StringComparison.OrdinalIgnoreCase))
                     .ToList())
        {
            pet.SetOwner(null);
        }

        Console.WriteLine($"Patient '{name}' and their associated pets have been removed.");
    }

    public static void RemovePet(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException(nameof(name));
        var petToRemove = Pets
            .FirstOrDefault(p => p.GetName().Equals(name, StringComparison.OrdinalIgnoreCase));
        if (petToRemove == null)
            throw new InvalidOperationException($"Pet with Name '{name}' not found.");
        Pets.Remove(petToRemove);


        Console.WriteLine($"Pet '{name}' has been removed.");
    }
}