using Patient_and_Pet_Management.Data;
using Patient_and_Pet_Management.Interfaces;
using Patient_and_Pet_Management.Models;

namespace Patient_and_Pet_Management.Repositories;

public class OwnerRepository: ICreate<Owner>, IGet<Owner>, IUpdate<Owner>, IRemove
{
    public OwnerRepository(){}
    public void Create(Owner owner)
    {
        Database.Owners.Add(owner);
    }

    public List<Owner> Get()
    {
        return Database.Owners;
    }

    public Owner? GetById(string id)
    {
        return Database.Owners.Find((owner => owner.Id.ToString() == id));
    }

    public Owner? GetByName(string name)
    {
        return Database.Owners.Find((owner => owner.Name == name));
    }

    public void Update(string id, Owner owner)
    {
        Database.Owners =
            Database.Owners.Select((own => own.Id.ToString() == id ? owner : own)).ToList();
    }

    public void Remove(string id)
    {
        Database.Owners = Database.Owners.Where((owner => owner.Id.ToString() != id)).ToList();
    }
}