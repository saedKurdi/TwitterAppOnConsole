using InstagramConsoleApp.interfaces;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Xml.Linq;

namespace InstagramConsoleApp.classes;
internal class Admin :  IID , IInterfaceEmail, IShow
{
    public string? ID { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }

    public string ? Username { get;set; }

    public string ? CreationDate { get; set; }

    public List<Post> ? Posts { get; set; } = new List<Post> ();

    public List<Notification> ? Notifications { get; set; } = new List<Notification>();

    #region Constructors

    public Admin()
    {
        ID = Guid.NewGuid().ToString().Substring(0,8);
        CreationDate = DateTime.Now.ToString();
    }

    public Admin(string? username,string ? email,string ? password):this()
    {
       if(username == null || email == null || password == null ) throw new ArgumentNullException("Username ; E-mail ; Password Can Not Be NULL !");
        var AllTextFromJson = File.ReadAllText(@"C:\JSONfile\admins.json");
        var adminsFromJsonFile = JsonSerializer.Deserialize<List<Admin>>(AllTextFromJson);

        for (int i = 0; i < adminsFromJsonFile!.Count; i++)
        {
            if (username == adminsFromJsonFile[i].Username) throw new Exception("This Username Has Already Excist !");
            if (email == adminsFromJsonFile[i].Email) throw new Exception("This Email Already Excits !");

        }

        Username = username;
       Email = email;
       Password = password;
    }

    #endregion

    public static Admin DoesAdminExcists(string ? username , string ? password)
    {
        if (username == null || password == null) throw new ArgumentNullException("Username or Password Can Not Be NULL !");

        var AllTextFromJson = File.ReadAllText(@"C:\JSONfile\admins.json");
        var adminsFromJsonFile = JsonSerializer.Deserialize<List<Admin>>(AllTextFromJson);

        for (int i = 0; i < adminsFromJsonFile!.Count; i++)
        {
            if (username == adminsFromJsonFile[i].Username && password == adminsFromJsonFile[i].Password) return adminsFromJsonFile[i];
        }

        throw new Exception("Username or Password is not correct !");
    }


    public void Show()
    {
        Console.WriteLine("\t\t\t\t*******************************************");
        Console.WriteLine("\t\t\t\tID : {0}", ID);
        Console.WriteLine("\t\t\t\tUsername : {0}", Username);
        Console.WriteLine("\t\t\t\tPassword : {0} ", Password);
        Console.WriteLine("\t\t\t\tEmail : {0}", Email);
        Console.WriteLine("\t\t\t\tAccount Creation Date : {0} ", CreationDate);
    }
}
