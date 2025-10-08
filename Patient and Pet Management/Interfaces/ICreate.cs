namespace Patient_and_Pet_Management.Interfaces;

public interface ICreate<T>
{
    public void Create(T entity);
}