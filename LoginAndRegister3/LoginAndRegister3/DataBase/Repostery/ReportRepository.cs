using Login_and_Register.DataBase.Models;
using LoginAndRegister3.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginAndRegister3.DataBase.Repostery
{
    public class ReportRepository
    {

        //private static int _idCounter;

        //public static int IdCounter
        //{
        //    get
        //    {
        //        _idCounter++;
        //        return _idCounter;
        //    }
        //}
        private static List<Reports> Reports = new List<Reports>();

        public static Reports Add(User from,User to,string content)
        {
            Reports reports = new Reports(content, from, to);
            Reports.Add(reports);
            return reports;
              
        }
        public static List<Reports> GetAll()
        {
            return Reports;
        }
    }
}
