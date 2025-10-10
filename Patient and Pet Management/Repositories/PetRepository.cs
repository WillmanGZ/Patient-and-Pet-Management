using Patient_and_Pet_Management.Data;
using Patient_and_Pet_Management.Interfaces;
using Patient_and_Pet_Management.Models;

namespace Patient_and_Pet_Management.Repositories;

public class PetRepository : ICreate<Pet>, IGet<Pet>, IUpdate<Pet>, IRemove
{
    public void Create(Pet pet)
    {
        Database.Pets.Add(pet);
    }

    public List<Pet> Get()
    {
        return Database.Pets;
    }

    public Pet? GetById(string id)
    {
        return Database.Pets.Find((pet => pet.Id.ToString() == id));
    }

    public Pet? GetByName(string name)
    {
        return Database.Pets.Find((pet => pet.Name.Equals(name, StringComparison.OrdinalIgnoreCase)));
    }

    public void Update(string id, Pet pet)
    {
        Database.Pets =
            Database.Pets.Select((p => p.Id.ToString() == id ? pet : p)).ToList();
    }

    public void Remove(string id)
    {
        Database.Pets = Database.Pets.Where((pet => pet.Id.ToString() != id)).ToList();
    }

    public void AddOwner(Owner owner, Pet pet)
    {
        Database.Pets = Database.Pets.Select((p =>
        {
            if (pet.Id.Equals(p.Id))
            {
                pet.Owner = owner;
            }

            return pet;
        })).ToList();
    }

    public void RemoveOwner(Pet pet)
    {
        Database.Pets = Database.Pets.Select((p) =>
        {
            if (pet.Id.Equals(p.Id))
            {
                pet.Owner = null;
            }

            return pet;
        }).ToList();
    }
}