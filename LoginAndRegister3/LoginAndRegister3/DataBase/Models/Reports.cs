using Login_and_Register.DataBase.Models;
using LoginAndRegister3.DataBase.Models.Common;
using LoginAndRegister3.DataBase.Repostery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginAndRegister3.DataBase.Models
{
    public class Reports : Entitiy<Guid>
    {
        public string TextContent;
        public User FromUser { get; set; }
        public User ToUser { get; set; }
        public DateTime DateTimeCreated { get; set; } = DateTime.Now;
        public Reports(string textContent,User fromUser,User toUser)
        {
            TextContent = textContent;
            FromUser = fromUser;
            ToUser = toUser;
            Id = Guid.NewGuid();
        }
        public string GetInfo()
        {
            return $"FromUser :{FromUser.Email}  ToUser :{ToUser.Email} Report Time : {DateTimeCreated}  Is Admin :{ToUser is Admin}";
        }
    }
}
