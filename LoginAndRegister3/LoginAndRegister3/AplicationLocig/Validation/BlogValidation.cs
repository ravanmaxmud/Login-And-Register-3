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
        public static bool IsLenghtCorrect(string text,int start,int end)
        { 
          return text.Length >= start && text.Length <= end;
        }
    }
}