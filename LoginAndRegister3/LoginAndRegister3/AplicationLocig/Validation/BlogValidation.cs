using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LoginAndRegister3.AplicationLocig.Validation
{
     class BlogValidation
    {
        //public static bool IsTitleCorrect(string title)
        //{
        //    if (Regex.IsMatch(title, @"^([A-Za-z]{10,35})$"))
        //    {
        //        return true;
        //    }
        //    Console.WriteLine("Your Entered Title Incorrect Please Try Again  (Check Title Lenght 10-35)");
        //    return false;
        //}
        //public static bool IsContentCorrect(string title)
        //{
        //    if (Regex.IsMatch(title, @"^([A-Za-z]{20,45})$"))
        //    {
        //        return true;
        //    }
        //    Console.WriteLine("Your Entered Content Incorrect Please Try Again  (Check Content Lenght 20-45)");
        //    return false;
        //}
        public static bool IsLenghtCorrect(string text,int start,int end)
        { 
          return text.Length >= start && text.Length <= end;
        }
    }
}