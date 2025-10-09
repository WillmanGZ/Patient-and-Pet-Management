using Patient_and_Pet_Management.Models;
using Patient_and_Pet_Management.Repositories;

namespace Patient_and_Pet_Management.Services;

public static class PetService
{
    private static PetRepository _petRepository = new PetRepository();


    public static void CreatePet(string name, byte age, string species, Owner owner)
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

            if (owner != null)
            {
                OwnerService.AddPet(newPet);
            }
            else
            {
                Console.WriteLine("Pet registered without owner");
            }

            Console.WriteLine("Pet created successfully");
        }
        catch (Exception err)
        {
            Console.WriteLine("Error creating pet", err);
        }
    }

    public static List<Pet> GetPets()
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

    public static Pet? GetPetById(string id)
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

    public static Pet? GetPetByName(string name)
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

    public static void UpdatePet(string id, string newName, byte newAge, string newSpecies, Owner owner)
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

    public static void RemovePet(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            Console.WriteLine("Invalid id");
            return;
        }

        try
        {
            var pet = _petRepository.GetById(id);
            _petRepository.Remove(id);

            if (pet.Owner != null)
            {
                OwnerService.DeletePet(pet);
            }

            Console.WriteLine("Pet removed successfully");
        }
        catch (Exception err)
        {
            Console.WriteLine("Error deleting pet", err);
        }
    }
    
    public static void AddOwner(Owner owner)
    {
        try
        {
            _petRepository.AddOwner(owner);
            Console.WriteLine("Pet was added to his owner successfully");
        }
        catch (Exception err)
        {
            Console.WriteLine("Error adding pet to owner", err);
        }
    }

    public static void DeleteOwner(Pet pet)
    {
        try
        {
            _petRepository.RemoveOwner(pet);
        }
        catch (Exception err)
        {
            Console.WriteLine("Error deleting owner to pet", err);
        }
    }
}