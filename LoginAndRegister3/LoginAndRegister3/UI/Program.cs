using Login_and_Register.Aplication_Locig;
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

