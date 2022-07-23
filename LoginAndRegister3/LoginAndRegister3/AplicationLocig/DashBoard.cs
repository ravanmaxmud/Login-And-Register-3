using Login_and_Register.DataBase.Models;
using Login_and_Register.DataBase.Repostery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_and_Register.Aplication_Locig
{
    public sealed partial class DashBoard
    {
        public static void UserPanel(string email)
        {
            User user = UserRepo.GetUserByEmail(email);
            Console.WriteLine("Welcome your account", user.GetShortInfo());
            while (true)
            {
                Console.WriteLine("Please Enter Command  /logout or /updateInfo");
                string command = Console.ReadLine();
                if (command == "/logout")
                {
                    Program.Main(new string[] { });
                    break;
                }
                else if (command == "/updateInfo")
                {
                    User targetUser = UserRepo.GetUserByEmail(email);
                    if (targetUser == null)
                    {
                        Console.WriteLine("Entered email not found.Please Try Again");
                    }
                    else if (targetUser is Admin)
                    {
                        Console.WriteLine("This Not User Mail");
                    }
                    else
                    {
                        User updateUser = new User(Authentication.GetFirstName(), Authentication.GetLastName());
                        UserRepo.Update(email, updateUser);
                        Console.WriteLine("User Updated Succesifully");
                    }
                }
                else
                {
                    Console.WriteLine("Common Not Found!!");
                }
                Console.WriteLine();
            }

        }
    }
    public sealed partial class DashBoard
    {
        public static void SuperAdminPanel(string email)
        {
            User user = UserRepo.GetUserByEmail(email);
            Console.WriteLine("Welcome Dear Admin", user.GetShortInfo());

            while (true)
            {
                if (user is Admin)
                {

                    Console.WriteLine("Please Enter Command /showusers or /logout or /removeuser or /make-admin or /remove-admin or /updateuser or /add-user or /showAdmin or /addAdmin or /updateAdmin");
                    string command = Console.ReadLine();
                    if (command == "/make-admin")
                    {

                        Console.WriteLine("Enter User Mail");
                        string mail = Console.ReadLine();

                        User targetUser = UserRepo.GetUserByEmail(mail);
                        if (targetUser == null)
                        {
                            Console.WriteLine("Entered email not found.Please Try Again");
                        }
                        else
                        {
                            UserRepo.Delete(targetUser);
                            Admin admin = new Admin(targetUser.FirstName, targetUser.LastName, targetUser.Email, targetUser.Password, targetUser.Id);
                            UserRepo.Add(admin);
                            Console.WriteLine("Admin Sucessifully Aded");
                        }
                    }
                    else if (command == "/add-user")
                    {
                        Authentication.Register();
                    }
                    else if (command == "/updateuser")
                    {
                        Console.WriteLine("Please Enter User Email Who You Want to Update");
                        string mail = Console.ReadLine();
                        User targetUser = UserRepo.GetUserByEmail(mail);
                        if (targetUser == null)
                        {
                            Console.WriteLine("Entered email not found.Please Try Again");
                        }
                        else if (targetUser is Admin)
                        {
                            Console.WriteLine("This Not User Mail");
                        }
                        else
                        {
                            User updateUser = new User(Authentication.GetFirstName(), Authentication.GetLastName());
                            UserRepo.Update(mail, updateUser);
                            Console.WriteLine("User Updated Succesifully");
                        }

                    }
                    else if (command == "/remove-admin")
                    {
                        Console.WriteLine("Enter User Mail");
                        string mail = Console.ReadLine();
                        User targetUser = UserRepo.GetUserByEmail(mail);
                        if (targetUser == null)
                        {
                            Console.WriteLine("Entered email not found.Please Try Again");
                        }
                        else
                        {
                            if (targetUser is Admin)
                            {
                                UserRepo.RemoveUserForMail(mail);
                                Console.WriteLine("Admin Succesifully Removed!!");
                            }
                            else
                            {
                                Console.WriteLine("Entered email Is Not Admin Mail.Please Try Again");
                            }
                        }
                    }
                    else if (command == "/removeuser")
                    {
                        Console.WriteLine("Enter User Mail");
                        string mail = Console.ReadLine();
                        if (mail == null)
                        {
                            Console.WriteLine("Please Enter Correct User Mail");
                        }
                        else
                        {

                            UserRepo.RemoveUserForMail(mail);
                            Console.WriteLine("User Removed Succesifully");
                        }
                    }
                    else if (command == "/showusers")
                    {
                        List<User> userInfos = UserRepo.GetAll();
                        foreach (User userInfo in userInfos)
                        {
                            Console.WriteLine(userInfo.GetInfo());
                        }
                    }
                    else if (command == "/showAdmin")
                    {
                        List<User> userInfos = UserRepo.GetAll();
                        foreach (User userInfo in userInfos)
                        {
                            if (userInfo is Admin)
                            {
                                Console.WriteLine(userInfo.GetInfo());
                            }
                        }
                    }
                    else if (command == "/addAdmin")
                    {
                        Admin newAdmin = new Admin(Authentication.GetFirstName(), Authentication.GetLastName(), Authentication.GetEmail(), Authentication.GetPassword());
                        UserRepo.Add(newAdmin);
                        Console.WriteLine("Admin Aded Succesifully");
                    }
                    else if (command == "/updateAdmin")
                    {
                        Console.WriteLine("Please Enter Admin Email Who You Want to Update");
                        string mail = Console.ReadLine();
                        User targetUser = UserRepo.GetUserByEmail(mail);
                        if (targetUser == null)
                        {
                            Console.WriteLine("Entered email not found.Please Try Again");
                        }
                        else if (!(targetUser is Admin))
                        {
                            Console.WriteLine("This Not Admin Mail");
                        }
                        else
                        {
                            User updateUser = new User(Authentication.GetFirstName(), Authentication.GetLastName());
                            UserRepo.Update(mail, updateUser);
                            Console.WriteLine("Admin Has Been Updated");
                        }

                    }
                    else if (command == "/logout")
                    {
                        Console.WriteLine("logged out");
                        Program.Main(new string[] { });
                    }
                    else
                    {
                        Console.WriteLine("Common Not Found!!");
                    }


                }
                else
                {
                    Console.WriteLine("Common Not Found!!");
                }
            }
        }
    }
}
