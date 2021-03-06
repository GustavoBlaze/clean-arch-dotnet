
namespace Blog.Interfaces
{

  public abstract class Manager<T>
  {

    public abstract void insert(string title, string content);

    public abstract bool destroy(long itemId);

    public abstract T? find(long itemId);

    public abstract T update(T itemToUpdate);

    public abstract List<T> all();

    public abstract T? findPostByTitle(string title);
  }
}
