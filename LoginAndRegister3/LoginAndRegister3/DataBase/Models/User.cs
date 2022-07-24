using Login_and_Register.DataBase.Repostery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_and_Register.DataBase.Models
{
    class User
    {
        public int Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegisterTime { get; set; }
        //public bool IsSuperAdmin { get; set; }
        //public bool IsAdmin { get; set; }

        public User(string firstName, string lastName, string email, string password/*, bool isSuperAdmin = false,bool isAdmin = false*/, int id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Id = id;
            RegisterTime = DateTime.Now;
            //IsSuperAdmin = isSuperAdmin;
            //IsAdmin = isAdmin;
        }
        public User(string firstName, string lastName, string email, string password/*, bool isSuperAdmin = false,bool isAdmin = false*/)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Id = UserRepo.IdCounter;

        }
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
