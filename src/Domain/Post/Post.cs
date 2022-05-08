namespace Blog.Domain
{

  public class Post
  {
    public long id { get; }
    public string title { get; }

    public string content { get; }

    public Post(long id, string title, string content)
    {
      this.id = id;
      this.title = title;
      this.content = content;
    }
  }
}
