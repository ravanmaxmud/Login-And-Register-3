using Login_and_Register.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_and_Register.DataBase.Repostery
{

    class UserRepo
    {
        private static int _idCounter;

        public static int IdCounter
        {
            get
            {
                _idCounter++;
                return _idCounter;
            }
        }

        private static List<User> Users { get; set; } = new List<User>()
        {
           new Admin("Super","Admin","admin@code.edu.az","Admin123321"),
           new User("Revan","Mahmmod","revan.mahmood@code.edu.az","Revan123321")
        };

        public static User AddUser(string firstName, string lastName, string email, string password)
        {
            User userInfo = new User(firstName, lastName, email, password, IdCounter);
            Users.Add(userInfo);
            return userInfo;

        }

        public static User AddUser(string firstName, string lastName, string email, string password, int id)
        {
            User userInfo = new User(firstName, lastName, email, password, id);
            Users.Add(userInfo);
            return userInfo;

        }
        public static User Update(string email, User user)
        {
            User targetUser = UserRepo.GetUserByEmail(email);

            targetUser.FirstName = user.FirstName;
            targetUser.LastName = user.LastName;


            return targetUser;

        }
        public static User Update(string email, Admin admin)
        {
            User targetUser = UserRepo.GetUserByEmail(email);
            targetUser.FirstName = admin.FirstName;
            targetUser.LastName = admin.LastName;

            return targetUser;
        }
        //public static void RemoveAdmin(string email, UserInfo user)
        //{
        //    UserInfo targetUser = GetUserByEmail(email);
        //    targetUser.IsSuperAdmin = false;
        //}

        public static User Add(User user)
        {
            Users.Add(user);
            return user;
        }
        public static User Add(Admin admin)
        {
            Users.Add(admin);
            return admin;
        }

        public static void Delete(User user)
        {
            Users.Remove(user);
        }

        public static bool IsMailUnical(string mail)
        {
            for (int i = 0; i < Users.Count; i++)
            {
                if (Users[i].Email == mail)
                {
                    return false;
                }
            }
            return true;
        }
        public static User GetUserByEmailAndPassword(string email, string password)
        {
            foreach (User user in Users)
            {
                if (user.Email == email && user.Password == password)
                {
                    return user;
                }
            }
            return null;
        }
        public static bool IsUserExistByEmailAndPassword(string email, string password)
        {
            foreach (User user in Users)
            {
                if (user.Email == email && user.Password == password)
                {
                    return true;
                }
            }
            return false;
        }
        public static User GetUserByEmail(string email)
        {
            foreach (User user in Users)
            {
                if (user.Email == email)
                {
                    return user;
                }
            }
            return null;
        }
        public static List<User> GetAll()
        {
            return Users;
        }
        public static void RemoveUserForMail(string mail)
        {
            for (int i = 0; i < Users.Count; i++)
            {
                if (Users[i].Email == mail)
                {
                    Users.RemoveAt(i);
                }
            }

        }
    }
}