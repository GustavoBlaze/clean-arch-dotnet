using Blog.Application;
using Blog.Interfaces;
using Blog.Domain;

namespace Blog.Infra
{

  public class CLI
  {
    private PostApplication postApplication;

    public CLI()
    {
      postApplication = new PostApplication(new ArrayPostManager());
    }

    private void showMenuOptions()
    {
      Console.WriteLine("Type 'list' to list all posts.");
      Console.WriteLine("Type 'add' to add a new post.");
      Console.WriteLine("Type 'delete' to delete a post.");
      Console.WriteLine("Type 'find' to find a post by tile.");
      Console.WriteLine("Type 'update' to update a post.");
      Console.WriteLine("Type 'exit' to exit the application.");
    }

    private void listPosts()
    {
      List<Post> posts = postApplication.AllPosts();

      foreach (Post post in posts)
      {
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("Id: {0}", post.id);
        Console.WriteLine("Title: {0}", post.title);
        Console.WriteLine("Content: {0}", post.content);
        Console.WriteLine("-----------------------------------------------------");

        Console.WriteLine("");
      }
    }

    private string askFor(string question)
    {
      string? answer = null;

      do
      {
        Console.Write(question);
        answer = Console.ReadLine();
      } while (answer == null || answer.Trim().Length == 0);

      return answer;
    }

    private void addPost()
    {
      Console.WriteLine("Adding a new post:");
      string title = askFor("Title: ");
      string content = askFor("Content: ");

      postApplication.AddPost(title, content);
    }

    private void deletePost()
    {
      Console.WriteLine("Deleting a post:");

      string postIdAsString = askFor("Post id: ");
      long postIdAsLong = long.Parse(postIdAsString);

      postApplication.DeletePost(postIdAsLong);
    }

    private void findPost()
    {
      Console.WriteLine("Find a post by title: ");

      string title = askFor("Title: ");

      Post? post = postApplication.FindPostByTitle(title);

      if (post is null)
      {
        Console.WriteLine("Post doesn`t exists");
        return;
      }

      Console.WriteLine("-----------------------------------------------------");
      Console.WriteLine("Id: {0}", post.id);
      Console.WriteLine("Title: {0}", post.title);
      Console.WriteLine("Content: {0}", post.content);
      Console.WriteLine("-----------------------------------------------------");
    }

    public void run()
    {
      string command;

      showMenuOptions();

      do
      {
        Console.Write("Command: ");
        command = Console.ReadLine() ?? "";

        switch (command)
        {
          case "list":
            listPosts();
            break;
          case "add":
            addPost();
            break;
          case "delete":
            deletePost();
            break;
          case "find":
            findPost();
            break;
          // case "update":
          //   updatePost();
          //   break;
          default:
            break;
        }

      } while (command != "exit");
    }
  }
}
