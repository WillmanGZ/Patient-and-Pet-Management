namespace Patient_and_Pet_Management.Models;

public class Owner(string name, byte age, string phone, string address)
    : Person(name, age, phone, address)
{
    public List<Pet> Pets { get; set; } = [];

    public override void ShowInfo()
    {
        Console.WriteLine(
            $"Id: {this.Id} | Name: {this.Name} | Age: {this.Age} | Address: {this.Address} | Phone: {this.Phone} | Pets {string.Join('-', Pets.Select((pet => pet.Name)))}");
    }

    public void ShowPets()
    {
        Console.WriteLine($"Pets of {this.Name}:");
        if (this.Pets.Count == 0)
        {
            Console.WriteLine("The owner doesn't have any pet ");
            return;
        }

        foreach (var pet in this.Pets)
        {
            Console.Write(" - ");
            pet.ShowInfo();
        }
    }

    public void AddPet(Pet pet)
    {
        this.Pets.Add(pet);
    }

    public void DeletePet(string id)
    {
        this.Pets = this.Pets.Where((pet) => !pet.Id.ToString().Equals(id)).ToList();
    }
}