using Login_and_Register.DataBase.Models;
using Login_and_Register.DataBase.Repostery;
using LoginAndRegister3.AplicationLocig.Services;
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

namespace Login_and_Register.Aplication_Locig
{
    public sealed partial class DashBoard
    {
        public static User CurrentUser { get; set; }
        public static void UserPanel(string email)
        {
            //Dictionary<BlogRepository, CommentRepository> keys = new Dictionary<BlogRepository, CommentRepository>();
            Repository<Comment, int> commentRepo = new Repository<Comment, int>();
            BlogRepository blogRepository = new BlogRepository();
            Repository<Blog, string> blogrepo = new Repository<Blog, string>();
            UserRepo userRepo = new UserRepo();
            List<Blog> blogs = blogrepo.GetAll();
            User user = userRepo.GetUserByEmail(email);
            Console.WriteLine(user.GetShortInfo());
            while (true)
            {
                Console.WriteLine("Please Enter Command  /logout or /updateInfo or /report or /addBlog or /show-blogs-with-comments or /show-your-own-blog or /updateBlog or /delete-blog or /add-comment");
                string command = Console.ReadLine();
                if (command == "/logout")
                {
                    Program.Main(new string[] { });
                    break;
                }
                else if (command == "/updateInfo")
                {
                    User targetUser = userRepo.GetUserByEmail(email);
                    if (targetUser == null)
                    {
                        Console.WriteLine("Entered email not found.Please Try Again");
                    }
                    else if (targetUser is Admin)
                    {
                        Console.WriteLine("This Not User Mail");
                    }
                    else
                    {
                        User updateUser = new User(Authentication.GetFirstName(), Authentication.GetLastName());
                        userRepo.Update(email, updateUser);
                        Console.WriteLine("User Updated Succesifully");
                    }
                }
                else if (command == "/show-blogs-with-comments")
                {
                    ////Dictionary<Blog, Comment> keys = new Dictionary<Blog, Comment>();
                    //List<Comment> comments = commentRepo.GetAll();
                    //int counter = 1;
                    ////foreach (KeyValuePair<Blog, Comment> blog in keys)
                    ////{
                    ////    Console.WriteLine($"{blog.Key.GetInfo()} {blog.Value.GetInfo()}");
                    ////}
                    //foreach (Blog blog in blogs)
                    //{
                    //    //if (blog.BlogStatus == BlogStatus.Accepted)
                    //    //{
                    //        counter++;
                    //        foreach (Comment comment in Blog.Comments)
                    //        {
                    //            if (comment.blog == blog)
                    //            {
                    //                Console.WriteLine($"{counter} {blog.GetInfo()}");
                    //                Console.WriteLine($"BlogComment :{ comment.GetInfo()}");
                    //            }
                    //        }
                    //    //}
                    //}
                    BlogService.ShowBlogs();
                }
                else if (command == "/show-your-own-blog")
                {
                    int counter = 1;
                    foreach (Blog blog in blogs)
                    {
                        if (blog.FromUser == CurrentUser)
                        {
                            Console.WriteLine($"{counter} {blog.GetInfo()}");
                            counter++;
                        }
                    }
                }
                else if (command == "/report")
                {
                    Console.WriteLine("Please Enter Who You Want To Report (Email)");
                    string mail = Console.ReadLine();
                    Console.WriteLine("Please Enter Content");
                    string content = Console.ReadLine();
                    User to = userRepo.GetUserByEmail(mail);
                    if (to == null)
                    {
                        Console.WriteLine("Please Enter User Email!!!");
                    }
                    else if (to == CurrentUser)
                    {
                        Console.WriteLine("You Dont Report Yourself!");
                    }
                    else
                    {
                        ReportRepository.Add(CurrentUser, to, content);
                    }
                }
                else if (command == "/addBlog")
                {
                    string blogTitle = BlogService.GetBlogTitle();
                    string content = BlogService.GetBlogContent();

                    BlogRepository.Add(CurrentUser, blogTitle, content);

                    Console.WriteLine("Blog Aded Sucesifully");
                }
                else if (command == "/updateBlog")
                {
                    Console.WriteLine("Please Enter Updated Blog ID");
                    string id = Console.ReadLine();
                    //Console.WriteLine("Please Enter Updated Title");
                    string changedTitle = BlogService.GetBlogTitle();
                    /*  Console.WriteLine("Enter changed content")*/
                    ;
                    string changedContent = BlogService.GetBlogContent();
                    Blog blog = blogrepo.GetById(id);
                    if (blog == null)
                    {
                        Console.WriteLine("Please Enter User Id");
                    }
                    else
                    {
                        if (blog.FromUser == CurrentUser)
                        {
                            Blog updateBlog = new Blog(changedTitle, changedContent, blog.FromUser, blog.BlogStatus);
                            blogRepository.Update(blog.Id, updateBlog);
                            Console.WriteLine("Blog Updated Succesifully");
                        }
                        else
                        {
                            Console.WriteLine("Please Enter Current Users Blog Id");
                        }
                    }
                }
                else if (command == "/delete-blog")
                {
                    Console.WriteLine("Please Enter Deleted Blog ID");
                    string id = Console.ReadLine();
                    Blog blog = blogrepo.GetById(id);
                    if (blog == null)
                    {
                        Console.WriteLine("Please Enter User Id");
                    }
                    else
                    {
                        if (blog.FromUser == CurrentUser)
                        {
                            BlogRepository.Delete(blog);
                            Console.WriteLine("Blog Removed Succesifully");
                        }
                        else
                        {
                            Console.WriteLine("Please Enter Current Users Blog Id");
                        }
                    }
                }
                else if (command == "/add-comment")
                {
                    Console.WriteLine("Please Enter Blog id");
                    string id = Console.ReadLine();
                    Blog blog = blogrepo.GetById(id);
                    Console.WriteLine("Please Enter Comment");
                    string adedComment = Console.ReadLine();
                    if (blog == null)
                    {
                        Console.WriteLine("Please Enter Correct Blog Id");
                    }
                    else
                    {
                        //Comment comment = new Comment(CurrentUser, adedComment, blog);
                        CommentRepository.AddComment(CurrentUser, adedComment, blog);
                    }
                }
                else
                {
                    Console.WriteLine("Command Not Found Please Try Again");
                }
                Console.WriteLine();
            }

        }
    }
    public sealed partial class DashBoard
    {
        public static void ModeratorPanel(string email)
        {
            UserRepo userRepo = new UserRepo();
            User user = userRepo.GetUserByEmail(email);
            Console.WriteLine(user.GetShortInfo());
            while (true)
            {
                if (user is Moderator)
                {
                    Console.WriteLine("Command : /showBlog or /logout");
                    string command = Console.ReadLine();
                    if (command == "/showBlog")
                    {
                        Repository<Blog, string> blogRepo = new Repository<Blog, string>();
                        List<Blog> blogs = blogRepo.GetAll();
                        int counter = 1;
                        foreach (Blog blog in blogs)
                        {
                            if (blog.BlogStatus == BlogStatus.Sended)
                            {
                                Console.WriteLine($"{counter} {blog.GetInfo()}");
                                counter++;
                            }
                        }
                        Console.WriteLine("Enter command for update blog status (/choose-blog-id)");
                        string secondCommand = Console.ReadLine();
                        if (secondCommand == "/choose-blog-id")
                        {
                            Console.WriteLine("Enter chosed blog id : ");
                            string id = Console.ReadLine();
                            Blog chosedblog = blogRepo.GetById(id);

                            if (chosedblog != null && chosedblog.BlogStatus == BlogStatus.Sended)
                            {
                                Console.WriteLine("Chose Accepted or Rejected");
                                string status = Console.ReadLine();

                                if (status == "Accepted")
                                {
                                    chosedblog.BlogStatus = BlogStatus.Accepted;

                                }
                                else if (status == "Rejected")
                                {
                                    chosedblog.BlogStatus = BlogStatus.Rejected;
                                }
                                else
                                {
                                    Console.WriteLine("Command not found");
                                }

                            }
                        }
                    }
                    else if (command == "/logout")
                    {
                        Console.WriteLine("logged out");
                        Program.Main(new string[] { });
                    }
                    else
                    {
                        Console.WriteLine("Command Not Found Please Try Again");
                    }
                }
            }
        }
    }
    public sealed partial class DashBoard
    {
        public static void SuperAdminPanel(string email)
        {
            UserRepo userRepo = new UserRepo();
            User user = userRepo.GetUserByEmail(email);
            //Console.WriteLine("Welcome Dear Admin", user.GetShortInfo());
            Console.WriteLine(user.GetShortInfo());

            while (true)
            {
                if (user is Admin)
                {

                    Console.WriteLine("Please Enter Command /showusers or /logout or /removeuser or /make-admin or /remove-admin or /updateuser or /add-user or /showAdmin or /addAdmin or /updateAdmin or /showReports");
                    string command = Console.ReadLine();
                    if (command == "/make-admin")
                    {

                        Console.WriteLine("Enter User Mail");
                        string mail = Console.ReadLine();

                        User targetUser = userRepo.GetUserByEmail(mail);
                        if (targetUser == null)
                        {
                            Console.WriteLine("Entered email not found.Please Try Again");
                        }
                        else
                        {
                            UserRepo.Delete(targetUser);
                            Admin admin = new Admin(targetUser.FirstName, targetUser.LastName, targetUser.Email, targetUser.Password, targetUser.Id);
                            userRepo.Add(admin);
                            Console.WriteLine("Admin Sucessifully Aded");
                        }
                    }
                    else if (command == "/showReports")
                    {
                        List<Reports> reports = ReportRepository.GetAll();
                        int counter = 1;
                        foreach (Reports report in reports)
                        {
                            Console.WriteLine($"{counter} {report.GetInfo()}");
                            counter++;
                        }
                    }
                    else if (command == "/add-user")
                    {
                        Authentication.Register();
                    }
                    else if (command == "/updateuser")
                    {
                        Console.WriteLine("Please Enter User Email Who You Want to Update");
                        string mail = Console.ReadLine();
                        User targetUser = userRepo.GetUserByEmail(mail);
                        if (targetUser == null)
                        {
                            Console.WriteLine("Entered email not found.Please Try Again");
                        }
                        else if (targetUser is Admin)
                        {
                            Console.WriteLine("This Not User Mail");
                        }
                        else
                        {
                            User updateUser = new User(Authentication.GetFirstName(), Authentication.GetLastName());
                            userRepo.Update(mail, updateUser);
                            Console.WriteLine("User Updated Succesifully");
                        }

                    }
                    else if (command == "/remove-admin")
                    {
                        Console.WriteLine("Enter User Mail");
                        string mail = Console.ReadLine();
                        User targetUser = userRepo.GetUserByEmail(mail);
                        if (targetUser == null)
                        {
                            Console.WriteLine("Entered email not found.Please Try Again");
                        }
                        else
                        {
                            if (targetUser is Admin)
                            {
                                userRepo.RemoveUserForMail(mail);
                                Console.WriteLine("Admin Succesifully Removed!!");
                            }
                            else
                            {
                                Console.WriteLine("Entered email Is Not Admin Mail.Please Try Again");
                            }
                        }
                    }
                    else if (command == "/removeuser")
                    {
                        Console.WriteLine("Enter User Mail");
                        string mail = Console.ReadLine();
                        User targetUser = userRepo.GetUserByEmail(mail);
                        if (targetUser == null)
                        {
                            Console.WriteLine("Please Enter Correct User Mail");
                        }
                        else
                        {

                            //UserRepo.RemoveUserForMail(mail);
                            UserRepo.Delete(targetUser);
                            Console.WriteLine("User Removed Succesifully");
                        }
                    }
                    else if (command == "/showusers")
                    {
                        List<User> userInfos = userRepo.GetAll();
                        foreach (User userInfo in userInfos)
                        {
                            Console.WriteLine(userInfo.GetInfo());
                        }
                    }
                    else if (command == "/showAdmin")
                    {
                        List<User> userInfos = userRepo.GetAll();
                        foreach (User userInfo in userInfos)
                        {
                            if (userInfo is Admin)
                            {
                                Console.WriteLine(userInfo.GetShortInfo());
                            }
                        }
                    }
                    else if (command == "/addAdmin")
                    {
                        Admin newAdmin = new Admin(Authentication.GetFirstName(), Authentication.GetLastName(), Authentication.GetEmail(), Authentication.GetPassword());
                        userRepo.Add(newAdmin);
                        Console.WriteLine("Admin Aded Succesifully");
                    }
                    else if (command == "/updateAdmin")
                    {
                        Console.WriteLine("Please Enter Admin Email Who You Want to Update");
                        string mail = Console.ReadLine();
                        User targetUser = userRepo.GetUserByEmail(mail);
                        if (targetUser.Email == email)
                        {
                            Console.WriteLine("Deyismek isediyiniz admin ile daxil olmusunuz");
                        }
                        else if (targetUser == null)
                        {
                            Console.WriteLine("Admin tapilmadi");
                        }
                        else
                        {
                            if (targetUser is Admin)
                            {
                                Admin uppAdmin = new Admin(Authentication.GetFirstName(), Authentication.GetLastName());
                                userRepo.Update(mail, uppAdmin);
                                Console.WriteLine("Admin update olundu");
                            }
                            else if (targetUser is User)
                            {
                                Console.WriteLine("Bu emaile mexsus istifadeci Userdir...");
                            }
                        }

                    }
                    else if (command == "/logout")
                    {
                        Console.WriteLine("logged out");
                        Program.Main(new string[] { });
                    }
                    else
                    {
                        Console.WriteLine("Common Not Found!!");
                    }
                }
                else
                {
                    Console.WriteLine("Common Not Found!!");
                }
            }
        }
    }
}
