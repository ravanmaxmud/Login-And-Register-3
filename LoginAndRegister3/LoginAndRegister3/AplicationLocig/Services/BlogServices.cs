﻿using Login_and_Register.Aplication_Locig;
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
            } while (isExpcetionExist || !BlogValidation.IsLenghtCorrect(title, 10, 35));
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
            } while (isExpcetionExist || !BlogValidation.IsLenghtCorrect(content, 20, 45));
            return content;
        }
        public static void ShowBlogs()
        {
            List<Blog> blogss = blogRepo.GetAll();
            int counter = 1;
            foreach (Blog blog in blogss)
            {
                Console.WriteLine(blog.GetInfo());
                foreach (Comment comment in commentRepo.GetAll(c => c.blog == blog))
                {
                    Console.WriteLine($"{counter} {comment.GetInfo()}");
                    counter++;
                }
            }
        }
        public static void ShowFiltiredBlogs()
        {
            List<Blog> blogss = blogRepo.GetAll();
            Console.WriteLine("Please Enter Title");
            string filtredTitle = Console.ReadLine();
            foreach (Blog blog in blogss)
            {
                if (blog.Title.Contains(filtredTitle))
                {
                    if (blog.BlogStatus == BlogStatus.Accepted)
                    {
                        Console.WriteLine(blog.GetInfo());
                        foreach (Comment comment in commentRepo.GetAll(c => c.blog == blog))
                        {
                            Console.WriteLine(comment.GetInfo());
                        }
                    }
                }
                else if (blog.FromUser.FirstName.Contains(filtredTitle))
                {
                    if (blog.BlogStatus == BlogStatus.Accepted)
                    {
                        Console.WriteLine(blog.GetInfo());
                        foreach (Comment comment in commentRepo.GetAll(c => c.blog == blog))
                        {
                            Console.WriteLine(comment.GetInfo());
                        }
                    }
                }
            }
        }
        public static void FindBlogByCode()
        {
            Console.WriteLine("Please Enter Searched Blog Code");
            string id = Console.ReadLine();
            List<Blog> blogs1 = blogRepo.GetAll();
            Blog blogs = blogRepo.GetById(id);
            if (blogs == null)
            {
                Console.WriteLine("Blogs Not Found");
            }
            else
            {
                foreach (Blog blog in blogs1)
                {
                    if (id == blog.Id)
                    {
                        Console.WriteLine($"{blog.GetInfo()}");
                    }
                }
            }
        }
    }
}
