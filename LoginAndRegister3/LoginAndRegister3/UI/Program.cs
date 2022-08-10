using Login_and_Register.Aplication_Locig;
using Login_and_Register.DataBase.Models;
using LoginAndRegister3.AplicationLocig.Services;
using LoginAndRegister3.DataBase.Repostery.Common;
using System;

namespace Login_and_Register
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("======================================================================");
                Console.WriteLine("Welcome to our Program");

                Console.WriteLine("======================================================================");
                Console.WriteLine("Thees are Our Command");
                Console.WriteLine("/register");
                Console.WriteLine("/login");
                Console.WriteLine("/show-blogs-with-comments");
                Console.WriteLine("/show-filtered-blogs-with-comments");
                Console.WriteLine("/find-blog-by-code");
                Console.WriteLine("/exit");

                Console.Write("Please Enter Command :");
                string command = Console.ReadLine();
                if (command == "/register")
                {
                    Authentication.Register();
                }
                else if (command == "/login")
                {
                    Authentication.Login();
                }
                else if (command== "/show-blogs-with-comments")
                {
                    BlogService.ShowBlogs();
                }
                else if (command == "/show-filtered-blogs-with-comments")
                {
                    BlogService.ShowFiltiredBlogs();
                }
                else if (command == "/find-blog-by-code")
                {
                    BlogService.FindBlogByCode();
                }
                else if (command == "/exit")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please Enter Command :");
                }
            }
        }
    }
}

