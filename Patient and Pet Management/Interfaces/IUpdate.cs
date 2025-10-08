namespace Patient_and_Pet_Management.Interfaces;

public interface IUpdate<T>
{
    void Update(string id, T entity);
}