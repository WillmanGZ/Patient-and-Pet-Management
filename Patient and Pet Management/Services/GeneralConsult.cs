using Patient_and_Pet_Management.Models;

namespace Patient_and_Pet_Management.Services;

public class GeneralConsult : VetService
{
    private readonly Pet _pet;

    public GeneralConsult(Pet pet)
    {
        this._pet = pet ?? throw new ArgumentNullException(nameof(pet));
    }

    public override void Attend()
    {
        Console.WriteLine($"Attending general consult for {this._pet.GetName()} (Id: {this._pet.Id}).");
        this._pet.EmitSound();
    }
}