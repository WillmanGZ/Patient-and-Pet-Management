namespace Patient_and_Pet_Management.Models;

public class Patient
{
    private Guid _id;
    private string _name;
    private byte _age;
    private string _phone;
    private string _address;
    private readonly List<Pet> _pets;

    public Patient(string name, byte age, string phone, string address)
    {
        this._id = Guid.NewGuid();
        this._name = name;
        this._age = age;
        this._phone = phone;
        this._address = address;
        this._pets = new List<Pet>();
    }

    public Guid GetId()
    {
        return this._id;
    }

    public string GetName()
    {
        return this._name;
    }

    public void SetName(string name)
    {
        this._name = name;
    }

    public byte GetAge()
    {
        return this._age;
    }

    public void SetAge(byte age)
    {
        this._age = age;
    }

    public string GetPhone()
    {
        return this._phone;
    }

    public void SetPhone(string phone)
    {
        this._phone = phone;
    }

    public string GetAddress()
    {
        return this._address;
    }

    public void SetAddress(string address)
    {
        this._address = address;
    }
    
    public void AddPet(Pet pet)
    {
        if (pet == null) throw new ArgumentNullException(nameof(pet));
        if (!this._pets.Contains(pet))
        {
            this._pets.Add(pet);
            pet.SetOwner(this);
        }
    }

    public void RemovePet(Pet pet)
    {
        if (pet == null) throw new ArgumentNullException(nameof(pet));
        if (this._pets.Remove(pet))
        {
            pet.SetOwner(null);
        }
    }

    public IReadOnlyList<Pet> GetPets()
    {
        return this._pets.AsReadOnly();
    }

    public void ShowInfo()
    {
        Console.WriteLine(
            $"Id: {this._id} | Name: {this._name} | Age: {this._age} | Address: {this._address} | Phone: {this._phone}");
    }

    public void ShowPets()
    {
        Console.WriteLine($"Pets of {this._name}:");
        if (this._pets.Count == 0)
        {
            Console.WriteLine("  (none)");
            return;
        }

        foreach (var p in this._pets)
        {
            Console.Write("  - ");
            p.ShowInfo();
        }
    }
}