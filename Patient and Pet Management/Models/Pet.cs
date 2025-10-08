namespace Patient_and_Pet_Management.Models;

public class Pet(string name, byte age, string species, Owner owner) : Animal(name, age, species)
{
    public Owner Owner { get; set; } = owner;


    public override void ShowInfo()
    {
        Console.WriteLine(
            $"Id: {this.Id} | Name: {this.Name} | Age: {this.Age} | Species: {this.Species} | Owner: {this.Owner.Name}");
    }
}