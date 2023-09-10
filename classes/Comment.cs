using InstagramConsoleApp.interfaces;

namespace InstagramConsoleApp.classes
{
    internal class Comment :IShow
    {

        public User ? FromUser { get; set; }
        public string ? Commentt { get; set; }

        public string ? Date { get; set; }

        public void Show()
        {
            Console.WriteLine($"\t\t\t\t  pp @{FromUser!.Username}");
            Console.WriteLine("\t\t\t\t  {0} - {1}",Commentt,Date);
            Console.WriteLine();
        }

        public Comment()
        {
            Date = DateTime.Now.ToString();
        }

        public Comment(User? fromUser, string? commentt):this()
        {
            if(fromUser == null ||  commentt == null) throw new ArgumentNullException("User or Comment Can Not Be Empty - NULL !");
            FromUser = fromUser;
            Commentt = commentt;
        }
    }

}
