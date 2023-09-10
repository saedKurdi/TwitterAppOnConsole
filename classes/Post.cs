using InstagramConsoleApp.interfaces;
using System.Text.Json;

namespace InstagramConsoleApp.classes;
internal class Post : IID , IShow
{
    public string? ID { get; set; }

    public string? Title { get; set; }
    public string ? Content { get; set; }   
    public string ? Date { get; set; }

    public int LikeCount { get; set; } = default;

    public int ViewCount { get; set; } = default;

    public List<Comment> Comments { get; set; } = new List<Comment>();

    #region Constructors

    public Post() { ID = Guid.NewGuid().ToString().Substring(0, 10); Date = DateTime.Now.ToString(); }

    public Post(string ? title ,string? content):this()
    {
        if (title == null || content == null ) throw new Exception("Content Or Title Of The Post Can Not Be NULL !");
        if (title.Length < 4) throw new Exception("Title's Length Must Be Minimum 4 !");
        if (content.Length < 10) throw new Exception("Content Must Have At Least 10 Characthers !");
        Title = title;
        Content = content;
    }

    
    public void Show()
    {
        Console.WriteLine("\t\t\t\t  **************************************");
        Console.WriteLine("\t\t\t\t  Post ID : {0}",ID);
        Console.WriteLine("\t\t\t\t  Date : {0}",Date);
        Console.WriteLine("\t\t\t\t  Title : {0}",Title);
        Console.WriteLine("\t\t\t\t  Content : {0}",Content);
        Console.WriteLine("\t\t\t\t  Views : {0}  |  Likes : {1} ",ViewCount,LikeCount);
        Console.WriteLine("\t\t\t\t  Comments : ");
        for (int i = 0; i < Comments.Count; i++)
        {
            Comments[i].Show();
        }
        Console.WriteLine();

    }

    #endregion

}
