using Patient_and_Pet_Management.Models;

namespace Patient_and_Pet_Management.Services;

public class Vaccination : VetService
{
    private readonly Pet _pet;
    private readonly string _vaccineName;

    public Vaccination(Pet pet, string vaccineName)
    {
        this._pet = pet ?? throw new ArgumentNullException(nameof(pet));
        this._vaccineName = vaccineName ?? string.Empty;
    }

    public override void Attend()
    {
        Console.WriteLine($"Applying vaccine '{this._vaccineName}' to {this._pet.GetName()} (Id: {this._pet.Id}).");
    }
}