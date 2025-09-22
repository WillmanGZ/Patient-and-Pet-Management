namespace Patient_and_Pet_Management.Models;

public class Patient(string name, int age, string symptom)
{
    public Guid Id = Guid.NewGuid();
    public string Name = name;
    public int Age = age;
    public string Symptom = symptom;
}