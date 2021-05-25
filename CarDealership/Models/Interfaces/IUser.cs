using CarDealership.Domain.Enum;
using CarDealership.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Domain.Interfaces
{
    public  interface IUser
    {
       string FirstName { get; set; }

       string LastName { get; set; }

        int Age { get; set; }

        UserType Type { get; set; }

        string Username { get; set; }

        string Email { get; set; }

        bool CheckPassword(string password);

        User LogIn(string username, string password);
    }
}
