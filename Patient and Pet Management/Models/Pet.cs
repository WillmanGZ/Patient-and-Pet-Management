namespace Patient_and_Pet_Management.Models;

public class Pet : Animal
{
    private string _breed;
    private Patient? _owner;

    public Pet(string name, byte age, string species, string breed, Patient? owner = null)
        : base(name, age, species)
    {
        this._breed = breed;
        this._owner = owner;
    }

    public string GetBreed()
    {
        return this._breed;
    }

    public void SetBreed(string breed)
    {
        this._breed = breed;
    }

    public Patient? GetOwner()
    {
        return this._owner;
    }

    public void SetOwner(Patient? owner)
    {
        this._owner = owner;
    }

    public override void EmitSound()
    {
        var low = (this._species ?? string.Empty).ToLower();
        string sound = low switch
        {
            "dog" => "Woof",
            "cat" => "Meow",
            "bird" => "Chirp",
            "rabbit" => "(silent)",
            "perro" => "Woof",
            "gato" => "Meow",
            "pajaro" => "Chirp",
            _ => "Unknown sound"
        };

        Console.WriteLine($"{this.GetName()} ({this._species}) => {sound}");
    }

    public override void ShowInfo()
    {
        var ownerName = this._owner != null ? this._owner.GetName() : "No owner";
        Console.WriteLine(
            $"Id: {this.Id} | Name: {this.GetName()} | Age: {this.GetAge()} | Species: {this._species} | Breed: {this._breed} | Owner: {ownerName}");
    }
}