using Login_and_Register.DataBase.Models;
using Login_and_Register.DataBase.Repostery;
using LoginAndRegister3.DataBase.Models;
using LoginAndRegister3.DataBase.Repostery.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginAndRegister3.DataBase.Repostery
{
    public class CommentRepository : Repository<Comment,int>
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
        //public CommentRepository()
        //{
        //    DbContent.Add(new Comment(UserRepo.Get(10),"sdjks" ,BlogRepository.Get(10))
        //}
        public static Comment AddComment(User from, string content, Blog blog)
        {
            Comment comment = new Comment(from, content, blog);
            DbContent.Add(comment);
            return comment;
        }
        public static List<Comment> GetComments()
        { 
          return DbContent;
        }
    }
}
