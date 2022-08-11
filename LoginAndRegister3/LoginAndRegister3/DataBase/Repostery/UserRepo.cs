using Login_and_Register.DataBase.Models;
using LoginAndRegister3.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginAndRegister3.DataBase.Repostery.Common;

namespace Login_and_Register.DataBase.Repostery
{

    class UserRepo : Repository<User, int>
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
        static UserRepo()
        {
            SeedUsers();
        }
        public static void SeedUsers()
        {
            DbContent.Add(new Admin("Super", "Admin", "admin@code.edu.az", "123321"));
            DbContent.Add(new Moderator("Ceyhun", "Hacizade", "ceyhun@code.edu.az", "123321"));
            DbContent.Add(new User("Revan", "Mahmood", "revan@code.edu.az", "123321"));
        }

        public User AddUser(string firstName, string lastName, string email, string password)
        {
            User userInfo = new User(firstName, lastName, email, password);
            DbContent.Add(userInfo);
            return userInfo;

        }
        public User Update(string email, User user)
        {
            UserRepo userRepo = new UserRepo();
            User targetUser = userRepo.GetUserByEmail(email);
            targetUser.FirstName = user.FirstName;
            targetUser.LastName = user.LastName;
            return targetUser;
        }
        public User Update(string email, Admin admin)
        {
            UserRepo userRepo = new UserRepo();
            User targetUser = userRepo.GetUserByEmail(email);
            targetUser.FirstName = admin.FirstName;
            targetUser.LastName = admin.LastName;
            return targetUser;
        }
        //public static void RemoveAdmin(string email, UserInfo user)
        //{
        //    UserInfo targetUser = GetUserByEmail(email);
        //    targetUser.IsSuperAdmin = false;
        //}

        public User Add(Admin admin)
        {
            DbContent.Add(admin);
            return admin;
        }
        public bool IsMailUnical(string mail)
        {
            for (int i = 0; i < DbContent.Count; i++)
            {
                if (DbContent[i].Email == mail)
                {
                    return false;
                }
            }
            return true;
        }
        public User GetUserByEmailAndPassword(string email, string password)
        {
            foreach (User user in DbContent)
            {
                if (user.Email == email && user.Password == password)
                {
                    return user;
                }
            }
            return null;
        }
        public bool IsUserExistByEmailAndPassword(string email, string password)
        {
            foreach (User user in DbContent)
            {
                if (user.Email == email && user.Password == password)
                {
                    return true;
                }
            }
            return false;
        }
        public User GetUserByEmail(string email)
        {
            foreach (User user in DbContent)
            {
                if (user.Email == email)
                {
                    return user;
                }
            }
            return null;
        }
        public void RemoveUserForMail(string mail)
        {
            for (int i = 0; i < DbContent.Count; i++)
            {
                if (DbContent[i].Email == mail)
                {
                    DbContent.RemoveAt(i);
                }
            }
        }
        //public static void ShowAdmins()
        //{ 
        //  Repository<User,int> repository = new Repository<User,int>();
        //    List<User> users = repository.GetAll();
        //    foreach (User user in users) {
        //        if (user is Admin)
        //        {
        //            Console.WriteLine(user.GetInfo());
        //        }
        //    }
        //}
    }
}