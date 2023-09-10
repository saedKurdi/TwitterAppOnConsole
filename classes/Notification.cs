using InstagramConsoleApp.interfaces;

namespace InstagramConsoleApp.classes
{
    internal class Notification : IID , IShow
    {
        public string? ID { get; set; }

        public string ? Text { get; set; }

        public string ? Date { get; set; }

        public User ? FromUser { get; set; }

        #region Constructors

        public Notification(){ID = Guid.NewGuid().ToString().Substring(0,10);Date = DateTime.Now.ToString();}

        public Notification(string ? text,User ? user):this()
        {
            if(text == null) throw new ArgumentNullException("Text Can Not Be NULL !");
            if(user == null) throw new ArgumentNullException("User Can Not Be NULL !");
            Text = text;
            FromUser = user;
        }


        #endregion
        public void Show()
        {
            Console.WriteLine("\t\t\t\t******************************");
            Console.WriteLine("\t\t\t\tDate - {0}",Date);
            Console.WriteLine("\t\t\t\tID - {0}",ID);
            Console.WriteLine("\t\t\t\tText - {0}",Text);
            Console.WriteLine("\t\t\t\tFrom User - {0}",FromUser!.Username);
            Console.WriteLine();
        }

    }
}
