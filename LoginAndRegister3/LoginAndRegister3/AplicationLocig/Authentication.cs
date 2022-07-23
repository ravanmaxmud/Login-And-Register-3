using Login_and_Register.DataBase.Models;
using Login_and_Register.DataBase.Repostery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_and_Register.Aplication_Locig
{
    class Authentication
    {

        public static void Register()
        {
            Console.WriteLine();
            string firstName = GetFirstName();
            string lastName = GetLastName();
            string email = GetEmail();
            string password = GetPassword();
            Console.Write("Conifirim Your Password : ");
            string confirimPassword = Console.ReadLine();
            while (!UserValidation.IsValidPassword(password, confirimPassword))
            {
                Console.Write("Please enter correct user's Password : ");
                confirimPassword = Console.ReadLine();
            }
            if (confirimPassword == password)
            {
                User user = UserRepo.AddUser(firstName, lastName, email, password);
                Console.WriteLine("User aded the system" + user.GetShortInfo());
                Console.WriteLine("You successfully registered, now you can login with your new account!");
            }
            Console.WriteLine();
        }

        public static string GetFirstName()
        {
            string firstName = null;
            bool isExpcetionExist;
            do
            {
                try
                {
                    Console.Write("Please enter user's name : ");
                    firstName = Console.ReadLine();
                    if (firstName == "")
                    {
                        throw new Exception();
                    }
                    isExpcetionExist = false;
                }
                catch
                {
                    isExpcetionExist = true;
                    Console.WriteLine("Daxil Etdiyiniz Inputda Yanlisliqlar Var");
                }
            } while (isExpcetionExist || !UserValidation.IsNameCorrect(firstName));
            return firstName;
        }
        public static string GetLastName()
        {
            Console.Write("Please Enter User's surname : ");
            string lastName = Console.ReadLine();
            while (!UserValidation.IsLastNNameCorrect(lastName))
            {
                Console.Write("Please enter correct user's surname : ");
                lastName = Console.ReadLine();
            }
            return lastName;

        }
        public static string GetEmail()
        {
            Console.Write("Please Enter User's Email : ");
            string email = Console.ReadLine();
            while (!UserValidation.IsMailCorrect(email))
            {
                Console.Write("Please enter correct user's Email : ");
                email = Console.ReadLine();
            }
            return email;

        }
        public static string GetPassword()
        {
            Console.Write("Please Enter User's Password : ");
            string password = Console.ReadLine();
            while (!UserValidation.IsPasswordCorrect(password))
            {
                Console.Write("Please enter correct user's Password : ");
                password = Console.ReadLine();
            }
            return password;

        }
        public static void Login()
        {
            Console.WriteLine();
            Console.Write("Please Enter User Email : ");
            string email = Console.ReadLine();

            Console.Write("Please Enter User Password : ");
            string password = Console.ReadLine();
            Console.WriteLine();
            if (UserRepo.IsUserExistByEmailAndPassword(email, password))
            {
                User user = UserRepo.GetUserByEmail(email);
                if (user is Admin)
                {
                    DashBoard.SuperAdminPanel(email);
                }
                else if (user is User)
                {
                    DashBoard.UserPanel(email);
                }
                else
                {
                    Console.WriteLine($"User Succesifully Login : {user.GetShortInfo()}");

                }
            }
        }
    }
}

