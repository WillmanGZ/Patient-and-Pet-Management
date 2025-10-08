using Patient_and_Pet_Management.Data;
using Patient_and_Pet_Management.Interfaces;
using Patient_and_Pet_Management.Models;

namespace Patient_and_Pet_Management.Repositories;

public class VeterinaryRepository : ICreate<Veterinary>, IGet<Veterinary>, IUpdate<Veterinary>, IRemove
{
    public void Create(Veterinary veterinary)
    {
        Database.Veterinaries.Add(veterinary);
    }

    public List<Veterinary> Get()
    {
        return Database.Veterinaries;
    }

    public Veterinary? GetById(string id)
    {
        return Database.Veterinaries.Find((veterinary => veterinary.Id.ToString() == id));
    }

    public Veterinary? GetByName(string name)
    {
        return Database.Veterinaries.Find((veterinary => veterinary.Name == name));
    }

    public void Update(string id, Veterinary veterinary)
    {
        Database.Veterinaries =
            Database.Veterinaries.Select((vet => vet.Id.ToString() == id ? veterinary : vet)).ToList();
    }

    public void Remove(string id)
    {
        Database.Veterinaries = Database.Veterinaries.Where((veterinary => veterinary.Id.ToString() != id)).ToList();
    }
}