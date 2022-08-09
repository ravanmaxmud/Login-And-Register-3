using Login_and_Register.DataBase.Repostery;
using LoginAndRegister3.DataBase.Models;
using LoginAndRegister3.DataBase.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_and_Register.DataBase.Models
{
    public class User : Entitiy<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegisterTime { get; set; } =DateTime.Now;
        public List<Reports> Reports { get; set; }

        public User(string firstName, string lastName, string email, string password, int? id=null)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            if (id != null)
            {
                Id = id.Value;
            }
            else
            {
                Id = UserRepo.IdCounter;
            }
        }
        //public User(string firstName, string lastName, string email, string password)
        //{
        //    FirstName = firstName;
        //    LastName = lastName;
        //    Email = email;
        //    Password = password;
        //    Id = UserRepo.IdCounter;

        //}
        public User(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string GetInfo()
        {
            return $"Name :{FirstName} LastName :{LastName} Email :{Email} Register Time :{RegisterTime}";
        }
        public virtual string GetShortInfo()
        {
            return $"Hello Dear User Id :{Id}  Name :{FirstName} LastName :{LastName} Email :{Email}";
        }
    }
}
