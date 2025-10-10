using Patient_and_Pet_Management.Models;
using Patient_and_Pet_Management.Services;

namespace Patient_and_Pet_Management.Utils;

public static class Menu
{
    public static void ShowMenu()
    {
// Ask for the option number
        List<int> availibleOptions = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13];
        int option = 0;

// Main loop
        while (option != 13)
        {
            Console.WriteLine("""

                              Choose an option

                              Available options:
                              1. List all owners
                              2. List all pets
                              3. List all veterinaries
                              4. List all appointments
                              5. Register new owner
                              6. Register new pet
                              7. Register new veterinary
                              8. Register new appointment
                              9. Delete owner
                              10. Delete pet
                              11. Delete veterinary
                              12. Delete appointment
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

            Console.WriteLine("");
            // Menu options
            switch (option)
            {
                case 1: ListOwners(); break;
                case 2: ListPets(); break;
                case 3: ListVeterinaries(); break;
                case 4: ListAppointments(); break;
                case 5: RegisterOwner(); break;
                case 6: RegisterPet(); break;
                case 7: RegisterVeterinary(); break;
                case 8: RegisterAppointment(); break;
                case 9: DeleteOwner(); break;
                case 10: DeletePet(); break;
                case 11: DeleteVeterinary(); break;
                case 12: break;
            }

            Console.WriteLine("");
            Console.Write("Press any key to continue...");
            var key = Console.ReadLine();
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

    static void ListAppointments()
    {
        Console.WriteLine("-- List all appointments --");
        var appointmentList = AppointmentService.GetAppointments();

        if (appointmentList.Count == 0)
        {
            Console.WriteLine("No appointments found.");
            return;
        }

        foreach (var appointment in appointmentList)
        {
            appointment.ShowInfo();
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

    static void RegisterAppointment()
    {
        Console.WriteLine("-- Register new appointment --");

        string subject;
        while (true)
        {
            Console.Write("Enter appointment subject: ");
            subject = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(subject)) break;
            Console.WriteLine("Subject cannot be empty. Please try again.");
        }

        string veterinaryName;
        while (true)
        {
            Console.Write("Enter veterinary name: ");
            veterinaryName = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(veterinaryName)) break;
            Console.WriteLine("Veterinary name cannot be empty. Please try again.");
        }

        string petName;
        while (true)
        {
            Console.Write("Enter pet name: ");
            petName = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(petName)) break;
            Console.WriteLine("Pet name cannot be empty. Please try again.");
        }

        string symptoms;
        while (true)
        {
            Console.Write("Enter symptoms: ");
            symptoms = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(symptoms)) break;
            Console.WriteLine("Symptoms cannot be empty. Please try again.");
        }

        string date;
        while (true)
        {
            Console.Write("Enter appointment date with format yyyy-MM-dd HH:mm (2025-10-10 14:00): ");
            date = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(date)) break;
            Console.WriteLine("Date cannot be empty. Please try again.");
        }

        try
        {
            AppointmentService.CreateAppointment(subject, veterinaryName, petName, symptoms, date);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void DeleteOwner()
    {
        Console.WriteLine("-- Delete owner --");

        string ownerNameToDelete;
        while (true)
        {
            Console.Write("Enter owner name to delete: ");
            ownerNameToDelete = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(ownerNameToDelete))
                break;
            Console.WriteLine("Name cannot be empty. Please try again.");
        }

        var ownerMatch = OwnerService.GetOwnerByName(ownerNameToDelete);

        if (ownerMatch == null)
        {
            Console.WriteLine($"Owner '{ownerNameToDelete}' not found.");
            return;
        }

        OwnerService.RemoveOwner(ownerMatch.Id.ToString());
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

        var petMatch = PetService.GetPetByName(petNameToDelete);

        if (petMatch == null)
        {
            Console.WriteLine($"Pet '{petNameToDelete}' not found.");
            return;
        }

        PetService.RemovePet(petMatch.Id.ToString());
    }

    static void DeleteVeterinary()
    {
        Console.WriteLine("-- Delete veterinary --");

        string veterinaryNameToDelete;
        while (true)
        {
            Console.Write("Enter veterinary name to delete: ");
            veterinaryNameToDelete = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(veterinaryNameToDelete))
                break;
            Console.WriteLine("Name cannot be empty. Please try again.");
        }

        var veterinaryMatch = VeterinaryService.GetVeterinaryByName(veterinaryNameToDelete);

        if (veterinaryMatch == null)
        {
            Console.WriteLine($"Veterinary '{veterinaryNameToDelete}' not found.");
            return;
        }

        VeterinaryService.RemoveVeterinary(veterinaryMatch.Id.ToString());
    }

    static void DeleteAppointment()
    {
        Console.WriteLine("-- Delete Appointment --");

        string appointmentSubjectToDelete;
        while (true)
        {
            Console.Write("Enter the appointment subject to delete: ");
            appointmentSubjectToDelete = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(appointmentSubjectToDelete))
                break;
            Console.WriteLine("Appointment Subject cannot be empty. Please try again.");
        }

        var appointmentMatch = AppointmentService.GetAppointmentByName(appointmentSubjectToDelete);

        if (appointmentMatch == null)
        {
            Console.WriteLine($"Appointment not found.");
            return;
        }

        AppointmentService.RemoveAppointment(appointmentMatch.Id.ToString());
    }
}