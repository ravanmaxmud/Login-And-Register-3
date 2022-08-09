using Login_and_Register.DataBase.Repostery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Login_and_Register.Aplication_Locig
{
    class UserValidation
    {
        UserRepo userRepo = new UserRepo();
        public static bool IsNameCorrect(string firstName)
        {
            if (Regex.IsMatch(firstName, @"^(?=[A-Z]{1})([A-Za-z]{3,30})$"))
            {
                return true;
            }
            Console.WriteLine("Daxil etdiyiniz ad yanlışdır, adın yalnız hərflərdən ibarət olduğuna, ilk hərfin böyük olduğuna və uzunluğunun 3 dən böyük, 30 - dan kiçik olduğuna əmin olun.");
            return false;
        }
        public static bool IsLastNNameCorrect(string lastName)
        {
            if (Regex.IsMatch(lastName, @"^(?=[A-Z]{1})([A-Za-z]{3,30})$"))
            {
                return true;
            }
            Console.WriteLine("Daxil etdiyiniz soyad yanlışdır, soyadın yalnız hərflərdən ibarət olduğuna, ilk hərfin böyük olduğuna və uzunluğunun 3 dən böyük, 30 - dan kiçik olduğuna əmin olun.");
            return false;
        }
        public static bool IsMailCorrect(string mail)
        {
            UserRepo userRepo = new UserRepo();
            if (Regex.IsMatch(mail, @"^[a-zA-Z0-9_?.?]{10,30}@code\.edu\.az") && userRepo.IsMailUnical(mail))
            {
                return true;
            }
            Console.WriteLine("Daxil etdiyiniz mail yanlisdir Xais Olunur Yeniden Chet Edin " +
                "BuMail Evvelceden Movcuddur");
            return false;
        }
        public static bool IsPasswordCorrect(string password)
        {
            if (Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$"))
            {
                return true;
            }
            Console.WriteLine("Daxil Etdiyiniz Sifre Ynalisdir Xais Olunur Yeniden Ceht Edin");
            return false;
        }
        public static bool IsValidPassword(string password, string confirmPassword)
        {
            if (password == confirmPassword)
            {
                return true;
            }
            Console.WriteLine("Daxil Etdiyiniz Sifre Uyqunlasmadi Xais Olunur Yeniden Ceht Edin");
            return false;

        }
        public static bool IsLoginCorrect(string email, string password)
        {
            UserRepo userRepo = new UserRepo();
            if (userRepo.IsUserExistByEmailAndPassword(email, password))
            {
                return true;
            }
            Console.WriteLine("Xais Olunur Yeniden Ceht Edin");
            return false;
        }

    }
}
