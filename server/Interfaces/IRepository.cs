namespace help_reviews.Interfaces;
// NOTE an interface is a contract that a class must follow when implementing. Any class that implements this interface must supprt these methods and define them
public interface IRepository<T> // T denotes a type that will be supplied when implementing the interface
{
  public List<T> GetAll();

  public T GetById(int id);

  public T Create(T data);

  public T Update(T data);

  public void Destroy(int id);
}