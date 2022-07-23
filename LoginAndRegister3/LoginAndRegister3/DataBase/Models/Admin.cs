﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_and_Register.DataBase.Models
{
    class Admin : User
    {
        public Admin(string firstName, string lastName, string email, string password)
           : base(firstName, lastName, email, password)
        {

        }
        public Admin(string firstName, string lastName, string email, string password, int id)
        : base(firstName, lastName, email, password, id)
        {

        }
        public override string GetShortInfo()
        {
            return $"Hello Dear Admin  Name :{FirstName} LastName :{LastName} Email :{Email}";
        }
    }
}