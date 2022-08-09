using Login_and_Register.DataBase.Models;
using Login_and_Register.DataBase.Repostery;
using LoginAndRegister3.DataBase.Models;
using LoginAndRegister3.DataBase.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginAndRegister3.DataBase.Repostery.Common
{
    public class BlogRepository :Repository<Blog,string>
    {
        //private static List<Blog> _blogList = new List<Blog>();
        static Random random = new Random();
        private static string _idCounter;

        public static string IdCounter
        {
            get
            {
                _idCounter ="BL" + random.Next();
                return _idCounter;
            }
        }
        //static BlogRepository()
        //{
        //    DbContent.Add(new Blog("dsjn","dnjsnjda",user,BlogStatus.Sended))
        //}
        //private static List<Blog> Blogs = new List<Blog>();
        public static Blog Add(User from,string title ,string content)
        {
            Blog blog = new Blog(title, content, from,BlogStatus.Sended);
            DbContent.Add(blog);
            return blog;
        }
        public  Blog Update(string id, Blog blog)
        {
            BlogRepository blogRepository = new BlogRepository();
            Blog targetBolog = blogRepository.GetById(id);
            targetBolog.Title = blog.Title;
            targetBolog.TextContent = blog.TextContent;
            targetBolog.FromUser = blog.FromUser;
            targetBolog.BlogStatus = blog.BlogStatus;
            return targetBolog;
        }
        //public static List<Blog> GetAll()
        //{
        //    return DbContent;
        //}
    }
}
