using Login_and_Register.DataBase.Models;
using Login_and_Register.DataBase.Repostery;
using LoginAndRegister3.DataBase.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginAndRegister3.DataBase.Models
{
    class Inbox : Entitiy<int>
    {
        public string Natification { get; set; }
        public User UseR { get; set; }
        public Inbox(string natification, User user,int? id = null)
        {
            Natification = natification;
            UseR = user;
            if (id != null)
            {
                Id = id.Value;
            }
            else
            {
                Id = UserRepo.IdCounter;
            }
        }
    }
}
