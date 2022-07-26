﻿using Login_and_Register.DataBase.Models;
using Login_and_Register.DataBase.Repostery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginAndRegister3.DataBase.Repostery.Common;
using LoginAndRegister3.DataBase.Models;

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
                UserRepo userRepo = new UserRepo();
                User user = userRepo.AddUser(firstName, lastName, email, password);
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
                    Console.WriteLine("There are errors in the input you entered");
                }
            } while (isExpcetionExist || !UserValidation.IsNameCorrect(firstName));
            return firstName;
        }
        public static string GetLastName()
        {
            string lastName = null;
            bool isExpcetionExist;
            do
            {
                try
                {
                    Console.Write("Please enter user's LaastName : ");
                    lastName = Console.ReadLine();
                    if (lastName == "")
                    {
                        throw new Exception();
                    }
                    isExpcetionExist = false;
                }
                catch
                {
                    isExpcetionExist = true;
                    Console.WriteLine("There are errors in the input you entered");
                }
            } while (isExpcetionExist || !UserValidation.IsLastNNameCorrect(lastName));
            return lastName;

        }
        public static string GetEmail()
        {
            string email = null;
            bool isExpcetionExist;
            do
            {
                try
                {
                    Console.Write("Please enter user's Email : ");
                    email = Console.ReadLine();
                    if (email == "")
                    {
                        throw new Exception();
                    }
                    isExpcetionExist = false;
                }
                catch
                {
                    isExpcetionExist = true;
                    Console.WriteLine("There are errors in the input you entered");
                }
            } while (isExpcetionExist || !UserValidation.IsMailCorrect(email));
            return email;

        }
        public static string GetPassword()
        {
            string password = null;
            bool isExpcetionExist;
            do
            {
                try
                {
                    Console.Write("Please enter user's Password : ");
                    password = Console.ReadLine();
                    if (password == "")
                    {
                        throw new Exception();
                    }
                    isExpcetionExist = false;
                }
                catch
                {
                    isExpcetionExist = true;
                    Console.WriteLine("There are errors in the input you entered");
                }
            } while (isExpcetionExist || !UserValidation.IsPasswordCorrect(password));
            return password;

        }
        public static void Login()
        {
            UserRepo userRepo = new UserRepo();
            Console.WriteLine();
            Console.Write("Please Enter User Email : ");
            string email = Console.ReadLine();

            Console.Write("Please Enter User Password : ");
            string password = Console.ReadLine();
            Console.WriteLine();
            User user = userRepo.GetUserByEmailAndPassword(email, password);
            if (user != null)
            {
                DashBoard.CurrentUser = user;
                if (user is Admin)
                {
                    DashBoard.SuperAdminPanel(email);
                }
                else if(user is Moderator)
                {
                    DashBoard.ModeratorPanel(email);
                }
                else if (user is User)
                {
                    DashBoard.UserPanel(email);
                }
                else
                {
                    Console.WriteLine("Please Enter Correctly");
                }
            }
            else
            {
                Console.WriteLine("Please Enter Correctly");
            }
        }
    }
}

