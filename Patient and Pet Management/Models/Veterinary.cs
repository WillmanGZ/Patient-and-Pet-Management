namespace Patient_and_Pet_Management.Models;

public class Veterinary(string name, byte age, string phone, string address, byte yearsExperience)
    : Person(name, age, phone, address)
{
    private byte YearsExperience { get; set; } = yearsExperience;

    public override void ShowInfo()
    {
        Console.WriteLine(
            $"Id: {this.Id} | Name: {this.Name} | Age: {this.Age} | Address: {this.Address} | Phone: {this.Phone} | YearsExperience: {this.YearsExperience}");
    }
}