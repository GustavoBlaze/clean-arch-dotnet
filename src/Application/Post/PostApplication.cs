using Blog.Interfaces;
using Blog.Domain;

namespace Blog.Application
{
  public class PostApplication
  {
    private Manager<Post> postManager;

    public PostApplication(Manager<Post> postManager)
    {
      this.postManager = postManager;
    }

    public void AddPost(string title, string content)
    {
      long newPostId = DateTime.Now.Ticks;

      Post newPost = new Post(newPostId, title, content);
      postManager.insert(newPost);
    }

    public void DeletePost(long postId)
    {
      postManager.destroy(postId);
    }

    public Post? FindPost(long postId)
    {
      return postManager.find(postId);
    }

    public Post? FindPostByTitle(string title)
    {
      return postManager.findPostByTitle(title);
    }


    public Post UpdatePost(long postId, string title, string content)
    {
      Post postToUpdate = new Post(postId, title, content);
      return postManager.update(postToUpdate);
    }

    public List<Post> AllPosts()
    {
      return postManager.all();
    }
  }
}
