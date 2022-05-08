
using Blog.Domain;

namespace Blog.Interfaces
{

  public class ArrayPostManager : Manager<Post>
  {
    private List<Post> posts;

    public ArrayPostManager()
    {
      posts = new List<Post>();
    }

    public override void insert(Post post)
    {
      this.posts.Add(post);
    }

    public override bool destroy(long postId)
    {
      int postIndex = posts.FindIndex(post => post.id == postId);

      if (postIndex == -1)
      {
        return false;
      }

      posts.RemoveAt(postIndex);

      return true;
    }

    public override Post? find(long postId)
    {
      return posts.Find(post => post.id == postId);
    }
    public override Post update(Post post)
    {
      int postIndex = posts.FindIndex(item => item.id == post.id);

      if (postIndex == -1)
      {
        throw new Exception("Post not found, cannot update.");
      }

      posts[postIndex] = post;

      return post;
    }

    public override List<Post> all()
    {
      return posts;
    }

    public override Post? findPostByTitle(string title)
    {
      return posts.Find(post => post.title == title);
    }
  }
}
