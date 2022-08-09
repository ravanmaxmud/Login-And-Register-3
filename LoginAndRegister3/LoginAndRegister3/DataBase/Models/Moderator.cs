using Login_and_Register.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginAndRegister3.DataBase.Models
{
    public class Moderator : User
    {
        public Moderator(string firstName, string lastName, string email, string password)
         : base(firstName, lastName, email, password)
        {

        }
        public Moderator(string firstName, string lastName, string email, string password, int id)
        : base(firstName, lastName, email, password)
        {

        }
        public Moderator(string firstName, string lastName) : base(firstName, lastName)
        {

        }
        public override string GetShortInfo()
        {
            return $"Hello Dear Moderator Id :{Id}  Name :{FirstName} LastName :{LastName} Email :{Email}";
        }
    }
}
