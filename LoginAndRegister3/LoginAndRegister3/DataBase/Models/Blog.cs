using Login_and_Register.DataBase.Models;
using Login_and_Register.DataBase.Repostery;
using LoginAndRegister3.DataBase.Models.Common;
using LoginAndRegister3.DataBase.Models.Enums;
using LoginAndRegister3.DataBase.Repostery.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginAndRegister3.DataBase.Models
{
    public class Blog : Entitiy<string>
    {
        public string Title { get; set; }
        public string TextContent;
        public User FromUser { get; set; }
        //public static List<Comment> Comments { get; set; } = new List<Comment>();
        public DateTime DateTimeCreated { get; set; } = DateTime.Now;
        public BlogStatus BlogStatus { get; set; }
        public Blog(string title,string textContent, User fromUser,BlogStatus blogStatus, string id =null)
        {
            Title = title;
            TextContent = textContent;
            FromUser = fromUser;
            if (id != null)
            {
                Id = id;
            }
            else
            {
                Id = BlogRepository.IdCounter;
            }
            BlogStatus = blogStatus;
        }
        public string GetInfo()
        {
            return $"FromUser :{FromUser.Email} {FromUser.FirstName} {FromUser.LastName} \n Blog Created Time : {DateTimeCreated}  \n Title : {Title} \n Blog : {TextContent}   \n BlogStatus {BlogStatus}   BlogId  {Id}";
        }
        public string GetShortInfo()
        {
            return $"From User : {FromUser.FirstName} {FromUser.LastName}  Title : {Title}  Blog : {TextContent}  BlogStatus {BlogStatus}";
        }
    }
}
