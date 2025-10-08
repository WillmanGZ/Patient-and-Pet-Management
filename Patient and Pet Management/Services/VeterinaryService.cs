using Patient_and_Pet_Management.Models;
using Patient_and_Pet_Management.Repositories;

namespace Patient_and_Pet_Management.Services;

public class VeterinaryService
{
    private static VeterinaryRepository _veterinaryRepository = new VeterinaryRepository();

    public static void CreateVeterinary(string name, byte age, string phone, string address, byte yearsExperience)
    {
        if (string.IsNullOrEmpty(name) || age <= 0 || age > 100 || string.IsNullOrEmpty(phone) ||
            string.IsNullOrEmpty(address) || yearsExperience <= 0 || yearsExperience > 80)
        {
            Console.WriteLine("Invalid Information");
            return;
        }

        try
        {
            Veterinary newVeterinary = new Veterinary(name, age, phone, address, yearsExperience);
            _veterinaryRepository.Create(newVeterinary);
            Console.WriteLine("Veterinary created successfully");
        }
        catch (Exception err)
        {
            Console.WriteLine("Error creating veterinary", err);
        }
    }

    public static List<Veterinary> GetVeterinaries()
    {
        try
        {
            return _veterinaryRepository.Get();
        }
        catch (Exception err)
        {
            Console.WriteLine("Error getting veterinaries", err);
            return [];
        }
    }

    public static Veterinary? GetVeterinaryById(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            Console.WriteLine("Invalid Id");
            return null;
        }

        try
        {
            return _veterinaryRepository.GetById(id);
        }
        catch (Exception err)
        {
            Console.WriteLine("Error getting veterinary by id", err);
            return null;
        }
    }

    public static Veterinary? GetVeterinaryByName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Invalid name");
            return null;
        }

        try
        {
            return _veterinaryRepository.GetByName(name);
        }
        catch (Exception err)
        {
            Console.WriteLine("Error getting veterinary by name", err);
            return null;
        }
    }

    public static void UpdateVeterinary(string id, string newName, byte newAge, string newPhone, string newAddress, byte newYearsExperience)
    {
        if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(newName) || newAge <= 0 || newAge > 100 ||
            string.IsNullOrEmpty(newPhone) ||
            string.IsNullOrEmpty(newAddress) || newYearsExperience <= 0 || newYearsExperience > 80)
        {
            Console.WriteLine("Invalid Information");
            return;
        }

        try
        {
            Veterinary updatedVeterinary = new Veterinary(newName, newAge, newPhone, newAddress, newYearsExperience);
            _veterinaryRepository.Update(id, updatedVeterinary);
            Console.WriteLine("Veterinary updated successfully");
        }
        catch (Exception err)
        {
            Console.WriteLine("Error updating veterinary", err);
        }
    }

    public static void RemoveVeterinary(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            Console.WriteLine("Invalid id");
            return;
        }

        try
        {
            _veterinaryRepository.Remove(id);
            Console.WriteLine("Veterinary removed successfully");
        }
        catch (Exception err)
        {
            Console.WriteLine("Error deleting veterinary", err);
        }
    }
}