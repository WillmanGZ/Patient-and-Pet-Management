namespace Patient_and_Pet_Management.Models;

public class Appointment(string subject, Veterinary veterinary, Pet pet, string symptoms, DateTime date)
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Subject { get; set; } = subject;
    public Veterinary Veterinary { get; set; } = veterinary;
    public Pet Pet { get; set; } = pet;
    public string Symptoms { get; set; } = symptoms;
    public DateTime Date { get; set; } = date;


    public void ShowInfo()
    {
        Console.WriteLine(
            $"Id: {Id} | Subject: {Subject} | Veterinary: {Veterinary.Name} | Pet: {Pet.Name} | Symptoms: {Symptoms} | Date: {Date.ToString()}");
    }
}