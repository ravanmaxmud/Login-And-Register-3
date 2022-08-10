using Login_and_Register.DataBase.Models;
using Login_and_Register.DataBase.Repostery;
using LoginAndRegister3.DataBase.Models.Common;
using LoginAndRegister3.DataBase.Repostery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginAndRegister3.DataBase.Models
{
    public class Comment : Entitiy<int>
    {
        public Blog blog { get; set; }
        public User FromUser { get; set; }
        public string CommentContent { get; set; }
        public DateTime DateTimeCreated { get; set; } = DateTime.Now;
        public Comment(User fromUser,string commentContent,Blog bLog,int? id =null)
        {
            FromUser = fromUser;
            CommentContent = commentContent;
            blog = bLog;
            if (id != null)
            {
                Id = id.Value;
            }
            else
            {
                Id = CommentRepository.IdCounter;
            }
        }
        public  string GetInfo()
        {
            return $"[{DateTimeCreated.ToString("dd.MM.yyyy")}] [{FromUser.FirstName} {FromUser.LastName}]  ===== {CommentContent}";
        }

    }
}
