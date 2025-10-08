using Patient_and_Pet_Management.Models;
using Patient_and_Pet_Management.Repositories;

namespace Patient_and_Pet_Management.Services;

public static class PetService
{
    private static PetRepository _petRepository = new PetRepository();

    static void CreatePet(string name, byte age, string species, Owner owner)
    {
        if (string.IsNullOrEmpty(name) || age <= 0 || age > 100 || string.IsNullOrEmpty(species))
        {
            Console.WriteLine("Invalid Information");
            return;
        }

        try
        {
            Pet newPet = new Pet(name, age, species, owner);
            _petRepository.Create(newPet);
            Console.WriteLine("User created successfully");
        }
        catch (Exception err)
        {
            Console.WriteLine("Error creating pet", err);
        }
    }

    static List<Pet> GetPets()
    {
        try
        {
            return _petRepository.Get();
        }
        catch (Exception err)
        {
            Console.WriteLine("Error getting pets", err);
            return [];
        }
    }

    static Pet? GetPetById(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            Console.WriteLine("Invalid Id");
            return null;
        }

        try
        {
            return _petRepository.GetById(id);
        }
        catch (Exception err)
        {
            Console.WriteLine("Error getting pet by id", err);
            return null;
        }
    }

    static Pet? GetPetByName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Invalid name");
            return null;
        }

        try
        {
            return _petRepository.GetByName(name);
        }
        catch (Exception err)
        {
            Console.WriteLine("Error getting pet by name", err);
            return null;
        }
    }

    static void UpdatePet(string id, string newName, byte newAge, string newSpecies, Owner owner)
    {
        if (string.IsNullOrEmpty(newName) || newAge <= 0 || newAge > 100 || string.IsNullOrEmpty(newSpecies))
        {
            Console.WriteLine("Invalid Information");
            return;
        }

        try
        {
            Pet updatedPet = new Pet(newName, newAge, newSpecies, owner);
            _petRepository.Update(id, updatedPet);
            Console.WriteLine("Pet updated successfully");
        }
        catch (Exception err)
        {
            Console.WriteLine("Error updating pet", err);
        }
    }

    static void RemovePet(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            Console.WriteLine("Invalid id");
            return;
        }

        try
        {
            _petRepository.Remove(id);
        }
        catch (Exception err)
        {
            Console.WriteLine("Error deleting pet", err);
        }
    }
}