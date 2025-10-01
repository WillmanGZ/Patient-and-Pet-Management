using Patient_and_Pet_Management.Models;
using Patient_and_Pet_Management.Services;

namespace Patient_and_Pet_Management.Utils;

public static class Menu
{
    public static void ShowMenu()
    {
        // Show welcome message
        Console.WriteLine("""

                          Welcome to the new vet system

                          Available options:
                          1. List all patients
                          2. List all pets
                          3. Register new patient
                          4. Register new pet
                          5. Search patient by name
                          6. Search pet by name
                          7. Attend pet
                          8. Delete patient
                          9. Delete pet
                          10. Exit

                          """);

// Ask for the option number
        List<int> availibleOptions = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
        int option = 0;

// Main loop
        while (option != 10)
        {
            //Ask for an option
            while (true)
            {
                try
                {
                    Console.Write("Please enter the option number (1-10): ");
                    option = int.Parse(Console.ReadLine() ?? string.Empty);

                    if (!availibleOptions.Contains(option))
                    {
                        Console.WriteLine("Invalid option");
                        continue;
                    }

                    break;
                }
                catch (Exception err)
                {
                    Console.WriteLine("Invalid option");
                    continue;
                }
            }

            // Menu options
            switch (option)
            {
                case 1: ListPatients(); break;
                case 2: ListPets(); break;
                case 3: RegisterPatient(); break;
                case 4: RegisterPet(); break;
                case 5: SearchPatientByName(); break;
                case 6: SearchPetByName(); break;
                case 7: AttendPet(); break;
                case 8: DeletePatient(); break;
                case 9: DeletePet(); break;
            }
        }

        Console.WriteLine("We hope see you soon!");
    }


    static void ListPatients()
    {
        Console.WriteLine("-- List all patients --");
        var patients = Storage.GetAllPatients();

        if (patients.Count == 0)
        {
            Console.WriteLine("No patients found.");
            return;
        }

        foreach (var patient in patients)
        {
            var pets = patient.GetPets();
            string petNames = pets.Count == 0 ? "(none)" : string.Join(", ", pets.Select(p => p.GetName()));

            Console.WriteLine($"""
                               Patient:
                               Name: {patient.GetName()}
                               Age: {patient.GetAge()}
                               Phone: {patient.GetPhone()}
                               Address: {patient.GetAddress()}
                               Pets: {petNames}
                               """);
            Console.WriteLine("---");
        }
    }

    static void ListPets()
    {
        Console.WriteLine("-- List all pets --");
        var petsList = Storage.GetAllPets();

        if (petsList.Count == 0)
        {
            Console.WriteLine("No pets found.");
            return;
        }

        foreach (var pet in petsList)
        {
            var ownerName = pet.GetOwner() != null ? pet.GetOwner()!.GetName() : "No owner";

            Console.WriteLine($"""
                               Pet:
                               Name: {pet.GetName()}
                               Age: {pet.GetAge()}
                               Species: {pet.GetSpecies()}
                               Breed: {pet.GetBreed()}
                               Owner: {ownerName}
                               """);
            Console.WriteLine("---");
        }
    }

    static void RegisterPatient()
    {
        Console.WriteLine("-- Register new patient --");

        string name;
        while (true)
        {
            Console.Write("Enter patient name: ");
            name = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(name)) break;
            Console.WriteLine("Name cannot be empty. Please try again.");
        }

        byte age;
        while (true)
        {
            Console.Write("Enter patient age: ");
            if (byte.TryParse(Console.ReadLine(), out age) && age > 0) break;
            Console.WriteLine("Invalid age. Please enter a valid number greater than 0.");
        }

        string phone;
        while (true)
        {
            Console.Write("Enter patient phone: ");
            phone = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(phone)) break;
            Console.WriteLine("Phone cannot be empty. Please try again.");
        }

        string address;
        while (true)
        {
            Console.Write("Enter patient address: ");
            address = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(address)) break;
            Console.WriteLine("Address cannot be empty. Please try again.");
        }

        try
        {
            var newPatient = new Patient(name, age, phone, address);
            Storage.AddPatient(newPatient);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void RegisterPet()
    {
        Console.WriteLine("-- Register new pet --");

        string petName;
        while (true)
        {
            Console.Write("Enter pet name: ");
            petName = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(petName))
                break;
            Console.WriteLine("Name cannot be empty. Please try again.");
        }

        byte petAge;
        while (true)
        {
            Console.Write("Enter pet age: ");
            try
            {
                petAge = byte.Parse(Console.ReadLine() ?? string.Empty);
                if (petAge > 0)
                    break;
                Console.WriteLine("Age must be greater than 0.");
            }
            catch
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }

        string species;
        while (true)
        {
            Console.Write("Enter pet species: ");
            species = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(species))
                break;
            Console.WriteLine("Species cannot be empty. Please try again.");
        }

        string breed;
        while (true)
        {
            Console.Write("Enter pet breed: ");
            breed = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(breed))
                break;
            Console.WriteLine("Breed cannot be empty. Please try again.");
        }

        Patient? owner = null;
        Console.Write("Enter owner name (leave empty if none): ");
        string ownerInput = Console.ReadLine() ?? string.Empty;

        if (!string.IsNullOrWhiteSpace(ownerInput))
        {
            owner = Storage.FindPatientByName(ownerInput);
            if (owner == null)
            {
                Console.WriteLine($"Owner '{ownerInput}' not found. Pet will be registered without owner.");
            }
        }

        try
        {
            var newPet = new Pet(petName, petAge, species, breed, owner);
            Storage.AddPet(newPet);

            if (owner != null)
            {
                owner.AddPet(newPet);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void SearchPatientByName()
    {
        Console.WriteLine("-- Search patient by name --");

        string searchPatientName;
        while (true)
        {
            Console.Write("Enter patient name: ");
            searchPatientName = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(searchPatientName))
                break;
            Console.WriteLine("Name cannot be empty. Please try again.");
        }

        var foundPatient = Storage.FindPatientByName(searchPatientName);

        if (foundPatient == null)
        {
            Console.WriteLine($"Patient '{searchPatientName}' not found.");
            return;
        }

        var patientPets = foundPatient.GetPets();
        string patientPetNames =
            patientPets.Count == 0 ? "(none)" : string.Join(", ", patientPets.Select(p => p.GetName()));

        Console.WriteLine($"""
                           Patient:
                           Name: {foundPatient.GetName()}
                           Age: {foundPatient.GetAge()}
                           Phone: {foundPatient.GetPhone()}
                           Address: {foundPatient.GetAddress()}
                           Pets: {patientPetNames}
                           """);
    }

    static void SearchPetByName()
    {
        Console.WriteLine("-- Search pet by name --");

        string searchPetName;
        while (true)
        {
            Console.Write("Enter pet name: ");
            searchPetName = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(searchPetName))
                break;
            Console.WriteLine("Name cannot be empty. Please try again.");
        }

        var foundPet = Storage.FindPetByName(searchPetName);

        if (foundPet == null)
        {
            Console.WriteLine($"Pet '{searchPetName}' not found.");
            return;
        }

        string ownerDisplay = foundPet.GetOwner() != null ? foundPet.GetOwner()!.GetName() : "No owner";

        Console.WriteLine($"""
                           Pet:
                           Name: {foundPet.GetName()}
                           Age: {foundPet.GetAge()}
                           Species: {foundPet.GetSpecies()}
                           Breed: {foundPet.GetBreed()}
                           Owner: {ownerDisplay}
                           """);
    }

    static void AttendPet()
    {
        Console.WriteLine("-- Attend Pet --");

        Console.Write("Enter pet name: ");
        var petNameInput = Console.ReadLine();

        var petsForAttend = Storage.GetAllPets();
        var petToAttend = petsForAttend
            .FirstOrDefault(p =>
                string.Equals(p.GetName(), petNameInput, StringComparison.OrdinalIgnoreCase));

        if (petToAttend == null)
        {
            Console.WriteLine("Pet not found.");
            return;
        }

        Console.WriteLine($"""
                           Pet found:
                           Name: {petToAttend.GetName()}
                           Age: {petToAttend.GetAge()}
                           Species: {petToAttend.GetSpecies()}
                           Breed: {petToAttend.GetBreed()}
                           """);

        Console.WriteLine("Choose service:");
        Console.WriteLine("1. General Consult");
        Console.WriteLine("2. Vaccination");
        Console.Write("Option: ");
        var chosenService = Console.ReadLine();

        VetService? vetService = null;

        if (chosenService == "1")
        {
            vetService = new GeneralConsult(petToAttend);
        }
        else if (chosenService == "2")
        {
            Console.Write("Enter vaccine name: ");
            var vaccineInput = Console.ReadLine();
            vetService = new Vaccination(petToAttend, vaccineInput ?? string.Empty);
        }
        else
        {
            Console.WriteLine("Invalid option.");
            return;
        }

        vetService.Attend();
    }


    static void DeletePatient()
    {
        Console.WriteLine("-- Delete patient --");

        string patientNameToDelete;
        while (true)
        {
            Console.Write("Enter patient name to delete: ");
            patientNameToDelete = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(patientNameToDelete))
                break;
            Console.WriteLine("Name cannot be empty. Please try again.");
        }

        var patientMatch = Storage.FindPatientByName(patientNameToDelete);

        if (patientMatch == null)
        {
            Console.WriteLine($"Patient '{patientNameToDelete}' not found.");
            return;
        }

        Storage.RemovePatient(patientMatch.GetName());

        Console.WriteLine($"""
                           Patient deleted:
                           Name: {patientMatch.GetName()}
                           Age: {patientMatch.GetAge()}
                           Phone: {patientMatch.GetPhone()}
                           Address: {patientMatch.GetAddress()}
                           """);
    }

    static void DeletePet()
    {
        Console.WriteLine("-- Delete pet --");

        string petNameToDelete;
        while (true)
        {
            Console.Write("Enter pet name to delete: ");
            petNameToDelete = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(petNameToDelete))
                break;
            Console.WriteLine("Name cannot be empty. Please try again.");
        }

        var petMatch = Storage.FindPetByName(petNameToDelete);

        if (petMatch == null)
        {
            Console.WriteLine($"Pet '{petNameToDelete}' not found.");
            return;
        }

        Storage.RemovePet(petMatch.GetName());

        string petOwnerDisplay = petMatch.GetOwner() != null ? petMatch.GetOwner()!.GetName() : "No owner";

        Console.WriteLine($"""
                           Pet deleted:
                           Name: {petMatch.GetName()}
                           Age: {petMatch.GetAge()}
                           Species: {petMatch.GetSpecies()}
                           Breed: {petMatch.GetBreed()}
                           Owner: {petOwnerDisplay}
                           """);
    }
}