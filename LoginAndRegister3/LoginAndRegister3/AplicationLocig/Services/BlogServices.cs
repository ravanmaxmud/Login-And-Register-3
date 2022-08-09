using LoginAndRegister3.AplicationLocig.Validation;
using LoginAndRegister3.DataBase.Models;
using LoginAndRegister3.DataBase.Models.Enums;
using LoginAndRegister3.DataBase.Repostery;
using LoginAndRegister3.DataBase.Repostery.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginAndRegister3.AplicationLocig.Services
{
    class BlogService
    {
       public static Repository<Blog, string> blogRepo = new Repository<Blog, string>();
        public static Repository<Comment, int> commentRepo = new Repository<Comment, int>();
        public static string GetBlogTitle()
        {
            string title = null;
            bool isExpcetionExist;
            do
            {
                try
                {
                    Console.WriteLine("Please Enter Blog Title");
                    title = Console.ReadLine();
                    if (title == "")
                    {
                        throw new Exception();
                    }
                    isExpcetionExist = false;
                }
                catch
                {
                    isExpcetionExist = true;
                    Console.WriteLine("There are errors in the input you entered");
                }
            } while (isExpcetionExist || !BlogValidation.IsTitleCorrect(title));
            return title;
        }
        public static string GetBlogContent()
        {
            string content = null;
            bool isExpcetionExist;
            do
            {
                try
                {
                    Console.WriteLine("Please Enter Content");
                    content = Console.ReadLine();
                    if (content == "")
                    {
                        throw new Exception();
                    }
                    isExpcetionExist = false;
                }
                catch
                {
                    isExpcetionExist = true;
                    Console.WriteLine("There are errors in the input you entered");
                }
            } while (isExpcetionExist || !BlogValidation.IsContentCorrect(content));
            return content;
        }
        public static void ShowBlogs()
        {
            List<Blog> blogss = blogRepo.GetAll();
            List<Comment> comments= commentRepo.GetAll();
            foreach (Blog blog in blogss)
            {
                foreach (Comment comment in comments)
                {
                    if (comment.blog != blog)
                    {

                        Console.WriteLine(blog.GetInfo());
                    }

                }
            }
        }
        public static void ShowBlogsWithComments()
        {
            Dictionary<Blog, Comment> commentsCount = new Dictionary<Blog, Comment>()
            {

            };
            List<Blog> blogs = blogRepo.GetAll();
            List<Comment> comments = CommentRepository.GetComments();


            foreach (Blog blog in blogs)
            {
                //if (blog.BlogStatus == BlogStatus.Sended)
                //{

                    foreach (Comment comment in comments)
                    {


                        if (comment.blog == blog)
                        {

                            commentsCount.Add(blog, comment);

                        }


                    }
                //}
            }
            foreach (KeyValuePair<Blog, Comment> keyValuePair in commentsCount)
            {
                Console.WriteLine(keyValuePair.Key.GetInfo() + " " + keyValuePair.Value.GetInfo());
            }
            //foreach(KeyValuePair<Blog, Comment> blog in commentsCount)
            //{
            //    Console.WriteLine(blog.Key.GetBlogInfo() + " " + blog.Value.GetCommentInfo());
            //}
        }
        public static void FindBlogByCode()
        {
            List<Blog> blogs1 = blogRepo.GetAll();
            Console.WriteLine("Please Enter Searched Blog Code");
            string id = Console.ReadLine();
            Blog blogs= blogRepo.GetById(id);
            if (blogs == null)
            {
                Console.WriteLine("Blogs Not Found");
            }
            else
            {
                foreach (Blog blog in blogs1)
                {
                    Console.WriteLine($"{blog.GetInfo()}");
                }
            }
        }
    }
}
