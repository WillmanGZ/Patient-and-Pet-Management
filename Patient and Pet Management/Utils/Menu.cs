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
                          1. List all owners
                          2. List all pets
                          3. List all veterinaries
                          4. Register new owner
                          5. Register new pet
                          6. Register new veterinary
                          7. Search owner by name
                          8. Search pet by name
                          9. Search veterinary by name
                          10. Delete owner
                          11. Delete pet
                          12. Delete veterinary
                          13. Exit
                          """);

// Ask for the option number
        List<int> availibleOptions = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13];
        int option = 0;

// Main loop
        while (option != 10)
        {
            Console.WriteLine("""

                              Choose again the option

                              Available options:
                              1. List all owners
                              2. List all pets
                              3. List all veterinaries
                              4. Register new owner
                              5. Register new pet
                              6. Register new veterinary
                              7. Search owner by name
                              8. Search pet by name
                              9. Search veterinary by name
                              10. Delete owner
                              11. Delete pet
                              12. Delete veterinary
                              13. Exit
                              """);

            //Ask for an option
            while (true)
            {
                try
                {
                    Console.Write("Please enter the option number (1-13): ");
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
                case 1: ListOwners(); break;
                case 2: ListPets(); break;
                case 3: ListVeterinaries(); break;
                case 4: RegisterOwner(); break;
                case 5: RegisterPet(); break;
                case 6: RegisterVeterinary(); break;
                // case 7: AttendPet(); break;
                // case 8: DeletePatient(); break;
                // case 9: DeletePet(); break;
            }
        }

        Console.WriteLine("We hope see you soon!");
    }


    static void ListOwners()
    {
        Console.WriteLine("-- List all owners --");
        var owners = OwnerService.GetOwners();

        if (owners.Count == 0)
        {
            Console.WriteLine("No owner found.");
            return;
        }

        foreach (var owner in owners)
        {
            owner.ShowInfo();
        }
    }

    static void ListPets()
    {
        Console.WriteLine("-- List all pets --");
        var petsList = PetService.GetPets();

        if (petsList.Count == 0)
        {
            Console.WriteLine("No pets found.");
            return;
        }

        foreach (var pet in petsList)
        {
            pet.ShowInfo();
        }
    }

    static void ListVeterinaries()
    {
        Console.WriteLine("-- List all veterinaries --");
        var veterinariesList = VeterinaryService.GetVeterinaries();

        if (veterinariesList.Count == 0)
        {
            Console.WriteLine("No veterinaries found.");
            return;
        }

        foreach (var veterinary in veterinariesList)
        {
            veterinary.ShowInfo();
        }
    }

    static void RegisterOwner()
    {
        Console.WriteLine("-- Register new owner --");

        string name;
        while (true)
        {
            Console.Write("Enter owner name: ");
            name = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(name)) break;
            Console.WriteLine("Name cannot be empty. Please try again.");
        }

        byte age;
        while (true)
        {
            Console.Write("Enter owner age: ");
            if (byte.TryParse(Console.ReadLine(), out age) && age > 0) break;
            Console.WriteLine("Invalid age. Please enter a valid number greater than 0.");
        }

        string phone;
        while (true)
        {
            Console.Write("Enter owner phone: ");
            phone = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(phone)) break;
            Console.WriteLine("Phone cannot be empty. Please try again.");
        }

        string address;
        while (true)
        {
            Console.Write("Enter owner address: ");
            address = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(address)) break;
            Console.WriteLine("Address cannot be empty. Please try again.");
        }

        try
        {
            OwnerService.CreateOwner(name, age, phone, address);
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

        Owner? owner = null;
        Console.Write("Enter owner name (leave empty if none): ");
        string ownerInput = Console.ReadLine() ?? string.Empty;

        if (!string.IsNullOrWhiteSpace(ownerInput))
        {
            owner = OwnerService.GetOwnerByName(ownerInput);
            if (owner == null)
            {
                Console.WriteLine($"Owner '{ownerInput}' not found. Pet will be registered without owner.");
            }
        }

        try
        {
            PetService.CreatePet(petName, petAge, species, owner);
            var newPet = new Pet(petName, petAge, species, owner);

            if (owner != null)
            {
                OwnerService.AddPet(newPet);
                Console.WriteLine("Pet associate to: " + owner.Name);
            }
            else
            {
                Console.WriteLine("Pet registered without owner");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void RegisterVeterinary()
    {
        Console.WriteLine("-- Register new veterinary --");

        string name;
        while (true)
        {
            Console.Write("Enter veterinary name: ");
            name = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(name)) break;
            Console.WriteLine("Name cannot be empty. Please try again.");
        }

        byte age;
        while (true)
        {
            Console.Write("Enter veterinary age: ");
            if (byte.TryParse(Console.ReadLine(), out age) && age > 0) break;
            Console.WriteLine("Invalid age. Please enter a valid number greater than 0.");
        }

        string phone;
        while (true)
        {
            Console.Write("Enter veterinary phone: ");
            phone = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(phone)) break;
            Console.WriteLine("Phone cannot be empty. Please try again.");
        }

        string address;
        while (true)
        {
            Console.Write("Enter veterinary address: ");
            address = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(address)) break;
            Console.WriteLine("Address cannot be empty. Please try again.");
        }

        byte yearsExperience;
        while (true)
        {
            Console.Write("Enter veterinary years experience: ");
            if (byte.TryParse(Console.ReadLine(), out yearsExperience) && yearsExperience > 0) break;
            Console.WriteLine("Invalid years experience. Please enter a valid number greater than 0.");
        }

        try
        {
            VeterinaryService.CreateVeterinary(name, age, phone, address, yearsExperience);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

//     static void SearchPatientByName()
//     {
//         Console.WriteLine("-- Search patient by name --");
//
//         string searchPatientName;
//         while (true)
//         {
//             Console.Write("Enter patient name: ");
//             searchPatientName = Console.ReadLine() ?? string.Empty;
//             if (!string.IsNullOrWhiteSpace(searchPatientName))
//                 break;
//             Console.WriteLine("Name cannot be empty. Please try again.");
//         }
//
//         var foundPatient = Storage.FindPatientByName(searchPatientName);
//
//         if (foundPatient == null)
//         {
//             Console.WriteLine($"Patient '{searchPatientName}' not found.");
//             return;
//         }
//
//         var patientPets = foundPatient.GetPets();
//         string patientPetNames =
//             patientPets.Count == 0 ? "(none)" : string.Join(", ", patientPets.Select(p => p.GetName()));
//
//         Console.WriteLine($"""
//                            Patient:
//                            Name: {foundPatient.GetName()}
//                            Age: {foundPatient.GetAge()}
//                            Phone: {foundPatient.GetPhone()}
//                            Address: {foundPatient.GetAddress()}
//                            Pets: {patientPetNames}
//                            """);
//     }
//
//     static void SearchPetByName()
//     {
//         Console.WriteLine("-- Search pet by name --");
//
//         string searchPetName;
//         while (true)
//         {
//             Console.Write("Enter pet name: ");
//             searchPetName = Console.ReadLine() ?? string.Empty;
//             if (!string.IsNullOrWhiteSpace(searchPetName))
//                 break;
//             Console.WriteLine("Name cannot be empty. Please try again.");
//         }
//
//         var foundPet = Storage.FindPetByName(searchPetName);
//
//         if (foundPet == null)
//         {
//             Console.WriteLine($"Pet '{searchPetName}' not found.");
//             return;
//         }
//
//         string ownerDisplay = foundPet.GetOwner() != null ? foundPet.GetOwner()!.GetName() : "No owner";
//
//         Console.WriteLine($"""
//                            Pet:
//                            Name: {foundPet.GetName()}
//                            Age: {foundPet.GetAge()}
//                            Species: {foundPet.GetSpecies()}
//                            Breed: {foundPet.GetBreed()}
//                            Owner: {ownerDisplay}
//                            """);
//     }
//
//     static void AttendPet()
//     {
//         Console.WriteLine("-- Attend Pet --");
//
//         Console.Write("Enter pet name: ");
//         var petNameInput = Console.ReadLine();
//
//         var petsForAttend = Storage.GetAllPets();
//         var petToAttend = petsForAttend
//             .FirstOrDefault(p =>
//                 string.Equals(p.GetName(), petNameInput, StringComparison.OrdinalIgnoreCase));
//
//         if (petToAttend == null)
//         {
//             Console.WriteLine("Pet not found.");
//             return;
//         }
//
//         Console.WriteLine($"""
//                            Pet found:
//                            Name: {petToAttend.GetName()}
//                            Age: {petToAttend.GetAge()}
//                            Species: {petToAttend.GetSpecies()}
//                            Breed: {petToAttend.GetBreed()}
//                            """);
//
//         Console.WriteLine("Choose service:");
//         Console.WriteLine("1. General Consult");
//         Console.WriteLine("2. Vaccination");
//         Console.Write("Option: ");
//         var chosenService = Console.ReadLine();
//
//         VetService? vetService = null;
//
//         if (chosenService == "1")
//         {
//             vetService = new GeneralConsult(petToAttend);
//         }
//         else if (chosenService == "2")
//         {
//             Console.Write("Enter vaccine name: ");
//             var vaccineInput = Console.ReadLine();
//             vetService = new Vaccination(petToAttend, vaccineInput ?? string.Empty);
//         }
//         else
//         {
//             Console.WriteLine("Invalid option.");
//             return;
//         }
//
//         vetService.Attend();
//     }
//
//
//     static void DeletePatient()
//     {
//         Console.WriteLine("-- Delete patient --");
//
//         string patientNameToDelete;
//         while (true)
//         {
//             Console.Write("Enter patient name to delete: ");
//             patientNameToDelete = Console.ReadLine() ?? string.Empty;
//             if (!string.IsNullOrWhiteSpace(patientNameToDelete))
//                 break;
//             Console.WriteLine("Name cannot be empty. Please try again.");
//         }
//
//         var patientMatch = Storage.FindPatientByName(patientNameToDelete);
//
//         if (patientMatch == null)
//         {
//             Console.WriteLine($"Patient '{patientNameToDelete}' not found.");
//             return;
//         }
//
//         Storage.RemovePatient(patientMatch.GetName());
//
//         Console.WriteLine($"""
//                            Patient deleted:
//                            Name: {patientMatch.GetName()}
//                            Age: {patientMatch.GetAge()}
//                            Phone: {patientMatch.GetPhone()}
//                            Address: {patientMatch.GetAddress()}
//                            """);
//     }
//
//     static void DeletePet()
//     {
//         Console.WriteLine("-- Delete pet --");
//
//         string petNameToDelete;
//         while (true)
//         {
//             Console.Write("Enter pet name to delete: ");
//             petNameToDelete = Console.ReadLine() ?? string.Empty;
//             if (!string.IsNullOrWhiteSpace(petNameToDelete))
//                 break;
//             Console.WriteLine("Name cannot be empty. Please try again.");
//         }
//
//         var petMatch = Storage.FindPetByName(petNameToDelete);
//
//         if (petMatch == null)
//         {
//             Console.WriteLine($"Pet '{petNameToDelete}' not found.");
//             return;
//         }
//
//         Storage.RemovePet(petMatch.GetName());
//
//         string petOwnerDisplay = petMatch.GetOwner() != null ? petMatch.GetOwner()!.GetName() : "No owner";
//
//         Console.WriteLine($"""
//                            Pet deleted:
//                            Name: {petMatch.GetName()}
//                            Age: {petMatch.GetAge()}
//                            Species: {petMatch.GetSpecies()}
//                            Breed: {petMatch.GetBreed()}
//                            Owner: {petOwnerDisplay}
//                            """);
//     }
}