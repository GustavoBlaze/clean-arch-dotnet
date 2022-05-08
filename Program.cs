using Blog.Infra;

namespace Blog.Program
{

  public class Program
  {
    public static void Main(string[] args)
    {
      CLI cli = new CLI();

      cli.run();
    }
  }
}
