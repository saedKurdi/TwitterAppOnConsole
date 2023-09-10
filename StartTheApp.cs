using System.Net.Mail;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Security.Cryptography;
using InstagramConsoleApp.classes;
using System.IO;
using System.Collections.Generic;
using System.Security.AccessControl;

namespace InstagramConsoleApp
{
    internal static class StartTheApp
    {
        public static void Start()
        {
            List<Admin> admins = new List<Admin>();
            List<User> users = new List<User>();
            if (!File.Exists(@"C:\JSONfile")) Directory.CreateDirectory(@"C:\JSONfile");

            if (!File.Exists(@"C:\JSONfile\admins.json"))
            {
                File.WriteAllText(@"C:\JSONfile\admins.json", JsonSerializer.Serialize(admins));
                Admin admin = new Admin("Seid", "seid13463@gmail.com", "mamedov2005");
                Post post = new Post("#Azerbaijan# Armenia #War","In 2020 - September Was a War Between Azerbaijan and Armenia");
                Post post2 = new Post("#America #Global #News !", "USA Will Take Part In The Tournment !");
                Post post3 = new Post("#About #StepAcademy","Step Academy is The one of The Best IT Academies in the World !");
                Post post4 = new Post("#Elon #Musk #'Updated' #Twitter","Elon Musk changed 'Twitter' Bird To Black 'X' !"); 
                Post post5 = new Post("#Azerbaijan #Turkey", "Azerbaijan and Turkey played a football match !");
                admins.Add(admin);
                admins[0].Posts!.Add(post); admins[0].Posts!.Add(post2); admins[0].Posts!.Add(post3); admins[0].Posts!.Add(post4); admins[0].Posts!.Add(post5);
                string jsonStringAdmins = JsonSerializer.Serialize(admins);
                File.WriteAllText(@"C:\JSONfile\admins.json", jsonStringAdmins);
            }

            if (File.Exists(@"C:\JSONfile\admins.json"))
            {
                string JsonString = File.ReadAllText(@"C:\JSONfile\admins.json");
                admins = JsonSerializer.Deserialize<List<Admin>>(JsonString)!;
            }

            if (!File.Exists(@"C:\JSONfile\users.json"))
            {
                File.WriteAllText(@"C:\JSONfile\users.json", JsonSerializer.Serialize(users));
            }

            if (File.Exists(@"C:\JSONfile\users.json"))
            {
                string JsonString = File.ReadAllText(@"C:\JSONfile\users.json");
                users = JsonSerializer.Deserialize<List<User>>(JsonString)!;
            }

          

            Console.Title = "Instagram App By Saed";

            int c = 0;
            while (true)
            {
                if (c == 1) break;

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\n\n\n\n\n\n\n");
                Console.WriteLine("\t\t\t\t***************************************************");
                Console.WriteLine("\t\t\t\t*                                             \t  *");
                Console.WriteLine("\t\t\t\t*      \t\t  W E L C O M E       \t\t  *");
                Console.WriteLine("\t\t\t\t*                                             \t  *");
                Console.WriteLine("\t\t\t\t***************************************************");
                Thread.Sleep(800);
                Console.ResetColor();

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\n\n\n\n\n\n\n");
                Console.WriteLine("\t\t\t\t***************************************************");
                Console.WriteLine("\t\t\t\t*                                             \t  *");
                Console.WriteLine("\t\t\t\t*      \t\t       T O       \t\t  *");
                Console.WriteLine("\t\t\t\t*                                             \t  *");
                Console.WriteLine("\t\t\t\t***************************************************");
                Thread.Sleep(700);
                Console.ResetColor();

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n\n\n\n\n\n\n\n");
                Console.WriteLine("\t\t\t\t***************************************************");
                Console.WriteLine("\t\t\t\t*                                             \t  *");
                Console.WriteLine("\t\t\t\t*      \t\t  M Y   A P P !       \t\t  *");
                Console.WriteLine("\t\t\t\t*                                             \t  *");
                Console.WriteLine("\t\t\t\t***************************************************");
                Thread.Sleep(800);
                Console.ResetColor();
                for (int i = 0; i < 2; i++)
                {
                    Thread.Sleep(450);
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write("\t\t\t\t\t   S T A R T I N G ");
                    Console.ResetColor();
                    for (int k = 0; k < 3; k++)
                    {
                        Thread.Sleep(350);
                        Console.Write(". ");
                        Thread.Sleep(350);
                    }
                }

                int c2 = 0;
                int c3 = 0;
                int c4 = 0;
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Title = "Instagram App By Saed";
                    if (c2 == 1) { c += 1;  break;}
                    Console.ResetColor();
                    Console.Clear();
                    int result_of_main_menu = Menu.Menu_(Menu.MainMenuElements);

                    if (result_of_main_menu == 0)// user 
                    {
                        while (true)
                        {
                            Console.Clear();
                            int result_of_user_menu = Menu.Menu_(Menu.UserMainElements);
                            if(result_of_user_menu == 0) // log in
                            {
                                try
                                {
                                    Console.Clear();
                                    Console.Write("\t\t\t\tEnter User's  username : ");
                                    string? username = Console.ReadLine();
                                    Console.Write("\t\t\t\tEnter User's password : ");
                                    string? password = Console.ReadLine();

                                    User u = User.DoesUserExcist(username, password);
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine($"\t\t\t\tWELCOME !{u.Name ! }");
                                    Console.ResetColor();
                                    Thread.Sleep(450);
                                    Console.Clear();

                                    while (true)
                                    {
                                        string AllTextFromJson = File.ReadAllText(@"C:\JSONfile\admins.json");
                                        List<Admin> adminsFromJsonFile = JsonSerializer.Deserialize<List<Admin>>(AllTextFromJson)!;
                                        if (admins[0].Posts!.Count == 0)
                                        {
                                            Console.Clear();
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("\t\t\tThere Is No Posts To Show Admin Has Not Posted Post Yet !");
                                            Console.ResetColor();
                                            Console.ReadKey();
                                            break;
                                        }
                                        string[] PostTitleAndID = { };
                                        Array.Resize(ref PostTitleAndID, adminsFromJsonFile[0].Posts!.Count + 1);
                                        for (int i = 0; i < adminsFromJsonFile[0].Posts!.Count; i++)
                                        {
                                            PostTitleAndID[i] ="  " + "Title : " + adminsFromJsonFile[0].Posts![i].Title + "   |   " + " ID : " + adminsFromJsonFile[0].Posts![i].ID;
                                        }
                                        PostTitleAndID[adminsFromJsonFile[0].Posts!.Count] = "\t\t\tBack";

                                        int result = Menu.Menu_(PostTitleAndID);
                                        if(result == PostTitleAndID.Length - 1)
                                        {
                                            break;
                                        }
                                        Console.Clear();
                                        admins[0].Posts![result].Show();
                                        admins[0].Posts![result].ViewCount += 1;
                                        Notification notification = new Notification($"Your Post By Title {adminsFromJsonFile[0].Posts![result].Title} was viewed.",u);
                                        admins[0].Notifications!.Add(notification);

                                        File.WriteAllText(@"C:\JSONfile\admins.json", JsonSerializer.Serialize(admins));

                                        int limit_of_like_count = 0;
                                        while (true)
                                        {
                                            Console.Clear();
                                            int answer_of_user_for_post = Menu.OtherMenu(Menu.PostSettingsForUser);
                                            if(answer_of_user_for_post == 0)
                                            {
                                                if(limit_of_like_count == 1)
                                                {
                                                    // get your like back 
                                                    admins[0].Posts![result].LikeCount -= 1;
                                                    limit_of_like_count--;
                                                    Notification notification2 = new Notification($"Your Post By Title - {admins[0].Posts![result].Title} was unliked !", u);
                                                    admins[0].Notifications!.Add(notification2);
                                                    string jsonFormat = JsonSerializer.Serialize(admins);
                                                    File.WriteAllText(@"C:\JSONfile\admins.json", jsonFormat);
                                                    Console.ReadKey();


                                                    Thread.Sleep(550);
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("\t\t\tUnliked !");
                                                    Console.ResetColor();
                                                    Thread.Sleep(550);
                                                    Console.WriteLine();
                                                    Console.WriteLine();
                                                    Console.Clear();
                                                    admins[0].Posts![result].Show();
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                    continue;
                                                }
                                                else
                                                {
                                                    // like
                                                    admins[0].Posts![result].LikeCount += 1;
                                                    limit_of_like_count += 1;
                                                    Notification notification2 = new Notification($"Your Post By Title - {admins[0].Posts![result].Title} was liked !", u);
                                                    admins[0].Notifications!.Add(notification2);
                                                    string jsonFormat = JsonSerializer.Serialize(admins);
                                                    File.WriteAllText(@"C:\JSONfile\admins.json", jsonFormat);
                                                    Console.ReadKey();


                                                    Thread.Sleep(550);
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.WriteLine("\t\t\tLiked !");
                                                    Console.ResetColor();
                                                    Thread.Sleep(550);
                                                    Console.WriteLine();
                                                    Console.WriteLine();
                                                    Console.Clear();
                                                    admins[0].Posts![result].Show();
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                    continue;
                                                }
                                            }

                                            else if(answer_of_user_for_post == 1)
                                            {
                                                // comment
                                                Console.WriteLine("\n\nType Your Comment Here :");
                                                string ? commentOfUser = Console.ReadLine();
                                                Comment comment = new Comment(u,commentOfUser);
                                                admins[0].Posts![result].Comments.Add(comment);
                                                Notification notification2 = new Notification($"Commented '{commentOfUser}' on post by Title ! - {admins[0].Posts![result].Title} ", u);
                                                admins[0].Notifications!.Add(notification2);
                                                string jsonFormat = JsonSerializer.Serialize(admins);
                                                File.WriteAllText(@"C:\JSONfile\admins.json", jsonFormat);
                                                Console.ReadKey();


                                                Thread.Sleep(550);
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.WriteLine("\t\t\t\t\tCommented !");
                                                Console.ResetColor();
                                                Thread.Sleep(550);
                                                Console.WriteLine();
                                                Console.WriteLine();
                                                Console.Clear();
                                                admins[0].Posts![result].Show();
                                                Console.ReadKey();
                                                Console.Clear();
                                                continue;
                                            }

                                            else if(answer_of_user_for_post == 2)
                                            {
                                                // back
                                                break;
                                            }
                                            continue;
                                        }
                                    }

                                }
                                catch (Exception ex )
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"Message : {ex.Message}\nInfo : {ex.StackTrace}");
                                    Console.ResetColor();
                                    Console.ReadKey();
                                }
                            }

                            else if(result_of_user_menu == 1)// register 
                            {
                                while (true)
                                {
                                    if (c4 == 1)
                                    {
                                        c4 = 0;
                                        break;
                                    }
                                    try
                                    {
                                        Console.Clear();
                                        Console.Write("\t\t\t\tEnter Your Name : ");
                                        string? name = Console.ReadLine();
                                        Console.WriteLine();
                                        Console.Write("\t\t\t\tEnter Your Surname : ");
                                        string ? surname = Console.ReadLine();
                                        Console.WriteLine();
                                        Console.Write("\t\t\t\tEnter Your Age : ");
                                        int age = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine();
                                        Thread.Sleep(550);
                                        Console.Clear();
                                        Console.Write("\t\t\t\tCreate Username : ");
                                        string? username = Console.ReadLine();
                                        Console.WriteLine();
                                        Console.Write("\t\t\t\tCreate Password : ");
                                        string? password = Console.ReadLine();
                                        Console.WriteLine();
                                        Console.Write("\t\t\t\tFor Finishing Enter Your Current E-mail Address : ");
                                        string ? mail = Console.ReadLine();
                                        User newuser = new User(name,surname,age,mail,username,password);

                                        while (true)
                                        {
                                            if (c4 == 1) break;
                                            // using SMTP -->
                                            string random_vertification_code = Random.Shared.Next(100000, 1000000).ToString();
                                            var smtpClient = new SmtpClient("smtp.gmail.com")
                                            {
                                                Port = 587,
                                                Credentials = new NetworkCredential("seid13463@gmail.com", "swktloogmsahqlwr"),
                                                EnableSsl = true,
                                            };

                                            var mailMessage = new MailMessage
                                            {
                                                From = new MailAddress("seid13463@gmail.com"),
                                                Subject = "| From Saed's Instagram App :) |",
                                                Body = $@"<!DOCTYPE html>
<html lang=""en"" xmlns=""http://www.w3.org/1999/xhtml"" xmlns:o=""urn:schemas-microsoft-com:office:office"">
<head>
  <meta charset=""UTF-8"">
  <meta name=""viewport"" content=""width=device-width,initial-scale=1"">
  <meta name=""x-apple-disable-message-reformatting"">
  <title></title>
  <!--[if mso]>
  <noscript>
    <xml>
      <o:OfficeDocumentSettings>
        <o:PixelsPerInch>96</o:PixelsPerInch>
      </o:OfficeDocumentSettings>
    </xml>
  </noscript>
  <![endif]-->
  <style>
    table, td, div, h1, p {{font-family: Arial, sans-serif;}}
  </style>
</head>
<body style=""margin:0;padding:0;"">
  <table role=""presentation"" style=""width:100%;border-collapse:collapse;border:0;border-spacing:0;background:#ffffff;"">
    <tr>
      <td align=""center"" style=""padding:0;"">
        <table role=""presentation"" style=""width:602px;border-collapse:collapse;border:1px solid #cccccc;border-spacing:0;text-align:left;"">
          <tr>
            <td align=""center"" style=""padding:40px 0 30px 0;background:#70bbd9;"">
              <img src=""https://assets.codepen.io/210284/h1.png"" alt="""" width=""300"" style=""height:auto;display:block;"" />
            </td>
          </tr>
          <tr>
            <td style=""padding:36px 30px 42px 30px;"">
              <table role=""presentation"" style=""width:100%;border-collapse:collapse;border:0;border-spacing:0;"">
                <tr>
                  <td style=""padding:0 0 36px 0;color:#153643;"">
                    <h1 style=""font-size:24px;margin:0 0 20px 0;font-family:Arial,sans-serif;"">Vertification Code : {random_vertification_code} </h1>
                    <p style=""margin:0 0 12px 0;font-size:16px;line-height:24px;font-family:Arial,sans-serif;"">Proyektden istifade etdiyiniz ucun tesekkur edirem !</p>
                    <p style=""margin:0;font-size:16px;line-height:24px;font-family:Arial,sans-serif;""><a href=""https://github.com/"" style=""color:#ee4c50;text-decoration:underline;"">Git-Hub hesabima daxil olub meni izleye bilersiniz</a></p>
                  </td>
                </tr>
                <tr>
                  <td style=""padding:0;"">
                    <table role=""presentation"" style=""width:100%;border-collapse:collapse;border:0;border-spacing:0;"">
                      <tr>
                        <td style=""width:260px;padding:0;vertical-align:top;color:#153643;"">
                          <p style=""margin:0 0 25px 0;font-size:16px;line-height:24px;font-family:Arial,sans-serif;""><img src=""https://cloud-epoint.fra1.digitaloceanspaces.com/images/users/middle/6308cca82ac8b.png"" alt="""" width=""260"" style=""height:auto;display:block;"" /></p>
                          <p style=""margin:0 0 12px 0;font-size:16px;line-height:24px;font-family:Arial,sans-serif;""></p>
                          <p style=""margin:0;font-size:16px;line-height:24px;font-family:Arial,sans-serif;""><a href=""https://itstep.az/ru?gclid=Cj0KCQjw0vWnBhC6ARIsAJpJM6cEyBCH8AKvqigL7-QlHeHj3nr8s3H4tRUDuQH42SqpiamQfryvxEAaAhMFEALw_wcB"" style=""color:#ee4c50;text-decoration:underline;"">Step IT Site ni da izleye bilersiniz</a></p>
                        </td>
                        <td style=""width:20px;padding:0;font-size:0;line-height:0;"">&nbsp;</td>
                        <td style=""width:260px;padding:0;vertical-align:top;color:#153643;"">
                          <p style=""margin:0 0 25px 0;font-size:16px;line-height:24px;font-family:Arial,sans-serif;""><img src=""https://content.linkedin.com/content/dam/brand/site/img/logo/logo-hero.png"" alt="""" width=""260"" style=""height:auto;display:block;"" /></p>
                          <p style=""margin:0 0 12px 0;font-size:16px;line-height:24px;font-family:Arial,sans-serif;"">Sehifelere bas cekdiyiniz ucun tesekkurler !</p>
                          <p style=""margin:0;font-size:16px;line-height:24px;font-family:Arial,sans-serif;""><a href=""http://linkedin.com/in/cavid-atamoglanov-4901a4137"" style=""color:#ee4c50;text-decoration:underline;"">Cavid Muellimi de izleye bilersiniz !</a></p>
                        </td>
                      </tr>
                    </table>
                  </td>
                </tr>
              </table>
            </td>
          </tr>
          <tr>
            <td style=""padding:30px;background:#ee4c50;"">
              <table role=""presentation"" style=""width:100%;border-collapse:collapse;border:0;border-spacing:0;font-size:9px;font-family:Arial,sans-serif;"">
                <tr>
                  <td style=""padding:0;width:50%;"" align=""left"">
                    <p style=""margin:0;font-size:14px;line-height:16px;font-family:Arial,sans-serif;color:#ffffff;"">
                      &reg; Someone, Somewhere 2021<br/><a href=""http://www.example.com"" style=""color:#ffffff;text-decoration:underline;"">Unsubscribe</a>
                    </p>
                  </td>
                  <td style=""padding:0;width:50%;"" align=""right"">
                    <table role=""presentation"" style=""border-collapse:collapse;border:0;border-spacing:0;"">
                      <tr>
                        <td style=""padding:0 0 0 10px;width:38px;"">
                          <a href=""http://www.twitter.com/"" style=""color:#ffffff;""><img src=""https://assets.codepen.io/210284/tw_1.png"" alt=""Twitter"" width=""38"" style=""height:auto;display:block;border:0;"" /></a>
                        </td>
                        <td style=""padding:0 0 0 10px;width:38px;"">
                          <a href=""http://www.facebook.com/"" style=""color:#ffffff;""><img src=""https://assets.codepen.io/210284/fb_1.png"" alt=""Facebook"" width=""38"" style=""height:auto;display:block;border:0;"" /></a>
                        </td>
                      </tr>
                    </table>
                  </td>
                </tr>
              </table>
            </td>
          </tr>
        </table>
      </td>
    </tr>
  </table>
</body>
</html>",
                                                IsBodyHtml = true,
                                            };
                                            mailMessage.To.Add(mail!);
                                            smtpClient.Send(mailMessage);

                                            Console.ForegroundColor= ConsoleColor.Green;
                                            Console.WriteLine("\t\t\t\tVertification Code Was Sent To Your Mail ");
                                            Console.ResetColor();
                                            Thread.Sleep(750);

                                            while (true)
                                            {
                                                Console.Clear();
                                                Console.Write("\t\t\tEnter Vertification Code : ");
                                                string? answerFromUser = Console.ReadLine();
                                                if(answerFromUser == null)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("\t\t\t\tMail Can Not Be NULL !");
                                                    Console.ReadKey();
                                                    continue;
                                                }
                                                else if(answerFromUser != random_vertification_code)
                                                {
                                                    Console.Clear();
                                                    string[] elementsForReg = { "\t\tSend Again", "\t\tExit ( Note :All Progress Will Be Deleted )" };
                                                    int answer = Menu.Menu_(elementsForReg);
                                                    if(answer == 0)
                                                    {
                                                        break;
                                                    }

                                                    else if(answer == 1)
                                                    {
                                                        c4 += 1;
                                                        break;
                                                    }
                                                }
                                                else if(answerFromUser == random_vertification_code)
                                                {
                                                    Console.Clear();
                                                    users.Add(newuser);
                                                    admins[0].Notifications!.Add(new Notification($"User {newuser.Username} Was Succesfully Registered", newuser));
                                                    File.WriteAllText(@"C:\JSONfile\users.json", JsonSerializer.Serialize(users));
                                                    File.WriteAllText(@"C:\JSONfile\admins.json", JsonSerializer.Serialize(admins));

                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.WriteLine("\t\t\tUser Succesfully Registered !");
                                                    Console.ResetColor();
                                                    Console.ReadKey();
                                                    c4 += 1;
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine($"\t\t\t\t{ex.Message}");
                                        Console.ResetColor();
                                        Console.ReadKey();
                                        break;
                                    }

                                }

                            }

                            else if(result_of_user_menu == 2) // back
                            {
                                break;
                            }

                        }
                    }

                    else if (result_of_main_menu == 1)// admin
                    {
                        while (true)
                        {
                            if (c3 == 1)
                            {
                                c3 = 0;
                                break;
                            }
                            try
                            {
                                Console.Clear();
                                Console.Write("\t\t\t\t\tEnter Admin Username : ");
                                string ? username = Console.ReadLine();
                                Console.Write("\t\t\t\t\tEnter Password : ");
                                string ? password = Console.ReadLine();
                                Admin.DoesAdminExcists(username, password);
                                Console.Clear();
                                Console.WriteLine("\t\t\t\t\tWelcome ! {0} ", admins[0].Username);
                                Console.ReadKey();
                                Console.Clear();


                                while (true)
                                {
                                    int result_of_admin = Menu.Menu_(Menu.AdminMainElements);
                                    try
                                    {
                                        if (result_of_admin == 0)// add new post 
                                        {
                                            Console.Clear();
                                            Console.Write("\t\t\t\tEnter Post Title : ");
                                            string? title = Console.ReadLine();
                                            Console.Write("\t\t\t\tEnter Content : ");
                                            string? content = Console.ReadLine();
                                            Post newPost = new Post(title, content);
                                            admins[0].Posts!.Add(newPost);

                                            string jsonFormat = JsonSerializer.Serialize(admins);
                                            File.WriteAllText(@"C:\JSONfile\admins.json", jsonFormat);

                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine();
                                            Console.WriteLine("\t\t\t\tAll Changes Saved ! ");
                                            Console.ResetColor();
                                            Console.ReadKey();
                                            continue;
                                        }

                                        else if (result_of_admin == 1)// remove post 
                                        {
                                            while (true)
                                            {
                                                string AllTextFromJson = File.ReadAllText(@"C:\JSONfile\admins.json");
                                                List<Admin> adminsFromJsonFile = JsonSerializer.Deserialize<List<Admin>>(AllTextFromJson)!;
                                                string[] PostTitleAndID = { };
                                                Array.Resize(ref PostTitleAndID, adminsFromJsonFile[0].Posts!.Count + 1);
                                                for (int i = 0; i < adminsFromJsonFile[0].Posts!.Count; i++)
                                                {
                                                    PostTitleAndID[i] = "  " + "Title : " + adminsFromJsonFile[0].Posts![i].Title + "   |   " + " ID : " + adminsFromJsonFile[0].Posts![i].ID;
                                                }
                                                PostTitleAndID[adminsFromJsonFile[0].Posts!.Count] = "\t\t\tBack";

                                                int result = Menu.Menu_(PostTitleAndID);
                                                if (result == PostTitleAndID.Length - 1)
                                                {
                                                    break;
                                                }

                                                admins[0].Posts!.Remove(admins[0].Posts![result]);
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                File.WriteAllText(@"C:\JSONfile\admins.json",JsonSerializer.Serialize(admins));
                                                Console.WriteLine("\t\t\t\tRemoved Succesfully !");
                                                Console.ResetColor();
                                                Console.ReadKey();
                                                continue;
                                            }
                                        }

                                        else if (result_of_admin == 2)// show notifications
                                        {
                                            if (admins[0].Notifications!.Count == 0)
                                            {
                                                Console.Clear();
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.Write("\t\t\t\tN O T I F I C A T I O N   L I S T   I S   A L R E A D Y   E M P T Y !");
                                                Console.ResetColor();
                                                Console.ReadKey();
                                                continue;
                                            }
                                            Console.Clear();
                                            for (int i = 0; i < admins[0].Notifications!.Count; i++)
                                            {
                                                admins[0].Notifications![i].Show();
                                            }
                                            Console.ReadKey();
                                            continue;
                                        }

                                        else if (result_of_admin == 3)// info about admin
                                        {
                                            Console.Clear();
                                            admins[0].Show();
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.ReadKey();
                                            continue;
                                        }
                                        else if (result_of_admin == 4)// back
                                        {
                                            c3+=1;
                                            break;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine($"\t\t\t{ex.Message}");
                                        Console.ResetColor();
                                        Console.ReadKey();
                                    }
                                }
                            }
                            catch (Exception ex )
                            {
                                Console.ForegroundColor= ConsoleColor.Red;
                                Console.WriteLine($"\t\t\t\t{ex.Message}");
                                Console.ReadKey();
                                Console.ResetColor();
                                break;
                            }

                        }
                    }

                    else if(result_of_main_menu == 2) // clear all notifications 
                    {
                        if (admins[0].Notifications!.Count == 0)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\t\t\t\tN O T I F I C A T I O N   L I S T   I S   A L R E A D Y   E M P T Y !");
                            Console.ResetColor();
                            Console.ReadKey();
                            continue;
                        }
                        admins[0].Notifications!.Clear();
                        File.WriteAllText(@"C:\JSONfile\admins.json", JsonSerializer.Serialize(admins));
                        Console.Clear();
                        for (int i = 0; i < 2; i++)
                        {
                            Thread.Sleep(450);
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.Write("\t\t\t\t\t   D E L E T I N G   N O T I F I C A T I O N S");
                            Console.ResetColor();
                            for (int k = 0; k < 3; k++)
                            {
                                Thread.Sleep(350);
                                Console.Write(". ");
                                Thread.Sleep(350);
                            }
                        }
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("\t\t\t\t\t   D E L E T E D .");
                        Console.ResetColor();
                        Console.ReadKey();
                        continue;
                    }



                    else if (result_of_main_menu == 3)// about app --> text
                    {
                        Console.Clear();
                        Console.Title = "ABOUT";
                        string? aboutApp = @"Instagram, LLC is a photo and video sharing social networking service owned by American company Meta Platforms. The app allows users to upload media that can be edited with filters, be organized by hashtags, and be associated with a location — via geographical tagging. Wikipedia
Available in: 32 languages
Developer(s): Meta Platforms
Initial release: October 6, 2010; 12 years ago
Original author(s): Kevin Systrom; Mike Krieger
Size: 231.3 MB (iOS); 50.22 MB (Android); 50.3 MB";
                        Other.TypeLine(aboutApp);
                        Console.WriteLine("\n\n\n\n\n\n\n\n");
                        Console.ReadKey();
                        Thread.Sleep(350);
                        continue;
                    }



                    //finished 
                    else if (result_of_main_menu == 4) // exiting - finished 
                    {
                        Console.Clear();
                        Console.WriteLine("\t\t\t\t\tRate Our App With Stars !");
                        string stars = "";
                        while (true)
                        {
                            ConsoleKeyInfo info = Console.ReadKey();
                            if (info.Key == ConsoleKey.Escape)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("\t\t\t\t\t_Write Description For The App !\n\n");
                                string? descpriptionForApp = Console.ReadLine();
                                Thread.Sleep(450);
                                Console.Clear();
                                Console.WriteLine("\t\t\t\t\tThanks ! For Using Our App !\n\n\n\n\n\n\n\n\n\n\n\n");
                                c2++;
                                Console.ReadKey();
                                Console.ResetColor();
                                break;
                            }

                            else if (info.Key == ConsoleKey.UpArrow || info.Key == ConsoleKey.RightArrow)
                            {
                                Console.Clear();
                                int starCount = 0;
                                for (int i = 0; i < stars.Length; i++)
                                {
                                    if (stars[i] == '*')
                                    {
                                        starCount++;
                                    }
                                }
                                Console.ForegroundColor = ConsoleColor.Green;
                                if (starCount == 5) { Console.Write("\n\n\n\n\n\t\t\t\t\t\t* * * * * ");Console.ResetColor(); continue; }
                                stars += " *";
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"\t\t\t\t\t\t{stars}");
                                Console.ResetColor();
                                Thread.Sleep(300);
                            }

                            else if(info.Key == ConsoleKey.DownArrow || info.Key == ConsoleKey.LeftArrow)
                            {
                                Console.Clear();
                                int starCount = 0;
                                for (int i = 0; i < stars.Length; i++)
                                {
                                    if (stars[i] == '*')
                                    {
                                        starCount++;
                                    }
                                }
                                Console.ForegroundColor = ConsoleColor.Green;
                                if (starCount == 1) { Console.Write("\n\n\n\n\n\t\t\t\t\t\t* "); Console.ResetColor(); continue; ; }
                                stars = stars.Substring(0, stars.Length - 2);
                                Console.ForegroundColor = ConsoleColor.Green;Console.WriteLine($"\t\t\t\t\t\t{stars}");
                                
                                Console.ResetColor();
                                Thread.Sleep(300);

                            }

                            else if (info.Key == ConsoleKey.Enter)
                            {
                                int starCount = 0;
                                for (int i = 0; i < stars.Length; i++)
                                {
                                    if (stars[i] == '*')
                                    {
                                        starCount++;
                                    }
                                }
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("\t\t\t\t\tThanks For Putting {0} Stars For Us  :)", starCount);
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine("\t\t\t\t\t  Write Description For The App ! \n\n");
                                string? descpriptionForApp = Console.ReadLine();
                                Thread.Sleep(450);
                                Console.Clear();
                                Console.WriteLine("\t\t\t\t\tThanks ! For Using Our App !\n\n\n\n\n\n\n\n\n\n\n\n");
                                c2++;
                                Console.ReadKey();
                                Console.ResetColor();
                                break;
                            }

                            else continue;
                        }
                    }
                }
            }
        }
    }
}
