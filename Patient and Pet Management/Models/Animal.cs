namespace Patient_and_Pet_Management.Models;

public class Animal
{
    public Guid Id { get; private set; }
    private string _name;
    private byte _age;
    protected string _species;

    public Animal(string name, byte age, string species)
    {
        this.Id = Guid.NewGuid();
        this._name = name;
        this._age = age;
        this._species = species;
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

    public string GetSpecies()
    {
        return this._species;
    }

    public void SetSpecies(string species)
    {
        this._species = species;
    }

    public virtual void EmitSound()
    {
        Console.WriteLine($"{this._name} makes a generic sound.");
    }

    public virtual void ShowInfo()
    {
        Console.WriteLine($"Id: {this.Id} | Name: {this._name} | Age: {this._age} | Species: {this._species}");
    }
}