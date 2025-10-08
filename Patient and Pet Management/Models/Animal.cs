namespace Patient_and_Pet_Management.Models;

public abstract class Animal(string name, byte age, string species)
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; set; } = name;
    public byte Age { get; set; } = age;
    public string Species { get; set; } = species;

    public virtual void ShowInfo()
    {
        Console.WriteLine($"Id: {this.Id} | Name: {this.Name} | Age: {this.Age} | Species: {this.Species}");
    }
}