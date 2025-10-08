namespace Patient_and_Pet_Management.Interfaces;

public interface IGet<T>
{
    public List<T> Get();
    public T? GetById(string id);
    public T? GetByName(string name);
}