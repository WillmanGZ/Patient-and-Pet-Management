namespace Patient_and_Pet_Management.Models;

public abstract class Person(string name, byte age, string phone, string address)
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; set; } = name;
    public byte Age { get; set; } = age;
    public string Phone { get; set; } = phone;
    public string Address { get; set; } = address;

    public virtual void ShowInfo()
    {
        Console.WriteLine(
            $"Id: {this.Id} | Name: {this.Name} | Age: {this.Age} | Address: {this.Address} | Phone: {this.Phone}");
    }
}