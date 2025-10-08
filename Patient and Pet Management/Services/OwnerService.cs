using Patient_and_Pet_Management.Repositories;
using Patient_and_Pet_Management.Models;

namespace Patient_and_Pet_Management.Services;

public static class OwnerService
{
    private static OwnerRepository _ownerRepository = new OwnerRepository();

    static void CreateOwner(string name, byte age, string phone, string address)
    {
        if (string.IsNullOrEmpty(name) || age <= 0 || age > 100 || string.IsNullOrEmpty(phone) ||
            string.IsNullOrEmpty(address))
        {
            Console.WriteLine("Invalid Information");
            return;
        }

        try
        {
            Owner newOwner = new Owner(name, age, phone, address);
            _ownerRepository.Create(newOwner);
            Console.WriteLine("User created successfully");
        }
        catch (Exception err)
        {
            Console.WriteLine("Error creating owner", err);
        }
    }

    static List<Owner> GetOwners()
    {
        try
        {
            return _ownerRepository.Get();
        }
        catch (Exception err)
        {
            Console.WriteLine("Error getting owners", err);
            return [];
        }
    }

    static Owner? GetOwnerById(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            Console.WriteLine("Invalid Id");
            return null;
        }

        try
        {
            return _ownerRepository.GetById(id);
        }
        catch (Exception err)
        {
            Console.WriteLine("Error getting owner by id", err);
            return null;
        }
    }

    static Owner? GetOwnerByName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Invalid name");
            return null;
        }

        try
        {
            return _ownerRepository.GetByName(name);
        }
        catch (Exception err)
        {
            Console.WriteLine("Error getting owner by name", err);
            return null;
        }
    }

    static void UpdateOwner(string id, string newName, byte newAge, string newPhone, string newAddress)
    {
        if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(newName) || newAge <= 0 || newAge > 100 ||
            string.IsNullOrEmpty(newPhone) ||
            string.IsNullOrEmpty(newAddress))
        {
            Console.WriteLine("Invalid Information");
            return;
        }

        try
        {
            Owner updatedOwner = new Owner(newName, newAge, newPhone, newAddress);
            _ownerRepository.Update(id, updatedOwner);
            Console.WriteLine("User updated successfully");
        }
        catch (Exception err)
        {
            Console.WriteLine("Error updating owner", err);
        }
    }

    static void RemoveOwner(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            Console.WriteLine("Invalid id");
            return;
        }

        try
        {
            _ownerRepository.Remove(id);
            Console.WriteLine("");
        }
        catch (Exception err)
        {
            Console.WriteLine("Error deleting owner", err);
        }
    }
}