using InstagramConsoleApp.interfaces;
using System.Text.Json;

namespace InstagramConsoleApp.classes;
internal class User : IID, INameSurnameInterface , IInterfaceEmail ,IShow
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? ID { get; set; }
    public int Age { get; set; }
    public string? Email { get; set; }

    public string ? Username { get; set; }
    public string? Password { get; set; }

    #region Constructors

    public User(){ID = Guid.NewGuid().ToString().Substring(0,10);}

    public User(string ? name,string ? surname,int age,string ? email,string ? username, string ? password):this()
    {
        if (name == null || surname == null) throw new ArgumentNullException("Surname Or Name Can Not Be NULL !");
        if (name.Length < 3) throw new Exception("Minimum Name Length Must Be 3 !");
        if (surname.Length < 4) throw new Exception("Minimum Surname Length Must Be 4 !");
        if (age < 16) throw new Exception("Minimum User Age Must Be 16 !");
        if (email == null || password == null || username == null) throw new Exception("Email,Username or Paswword Can Not Be NULL !");
        if (username.Length < 4) throw new Exception("Minimum Username Lenght Must Be 4 !");
        if (password.Length < 6) throw new Exception("Minimum Password Length Must Be 6 !");
        if (!email.EndsWith("@gmail.com")) throw new Exception("E-mail Must End With '@gmail.com' We Only Support This !");

        var AllTextFromJson = File.ReadAllText(@"C:\JSONfile\users.json");
        var usersFromJsonFile = JsonSerializer.Deserialize<List<User>>(AllTextFromJson);

        for (int i = 0; i < usersFromJsonFile!.Count; i++)
        {
            if (username == usersFromJsonFile[i].Username) throw new Exception("This Username Has Already Excist !");
            if (email == usersFromJsonFile[i].Email) throw new Exception("This Email Already Excits !");

        }

        Name = name;
        Surname = surname;
        Age = age;
        Email = email;
        Username = username;
        Password = password;
    }
    #endregion


    public static User DoesUserExcist(string ? username,string ? password)
    {
        if(username == null || password == null) throw new ArgumentNullException("Username or Password Can Not Be NULL !");

        var AllTextFromJson = File.ReadAllText(@"C:\JSONfile\users.json");
        var usersFromJsonFile = JsonSerializer.Deserialize<List<User>>(AllTextFromJson);

        for (int i = 0; i < usersFromJsonFile!.Count; i++)
        {
            if (usersFromJsonFile[i].Username == username && usersFromJsonFile[i].Password == password) return usersFromJsonFile[i];
        }

        throw new Exception($"Username or Password is not correct !");
    }

    public static void ShowAllUsersFromJson()
    {
        var AllTextFromJson = File.ReadAllText(@"C:\JSONfile\users.json");
        var usersFromJsonFile = JsonSerializer.Deserialize<List<User>>(AllTextFromJson);
        for (int i = 0; i < usersFromJsonFile!.Count; i++)
        {
            usersFromJsonFile[i].Show();
        }
    }

    public void Show()
    {
        Console.WriteLine("\t\t\t\t***************************************");
        Console.WriteLine("\t\t\t\tID : {0}",ID);
        Console.WriteLine("\t\t\t\tName : {0}",Name);
        Console.WriteLine("\t\t\t\tSurname : {0} ",Surname);
        Console.WriteLine("\t\t\t\tUsername : {0}",Username);
        Console.WriteLine("\t\t\t\tAge : {0} ",Age);
        Console.WriteLine("\t\t\t\tMail : {0} ",Email);
    }
}
