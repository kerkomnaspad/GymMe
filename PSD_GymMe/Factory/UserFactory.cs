using PSD_GymMe.Model;
using PSD_GymMe.Modules;
using PSD_GymMe.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_GymMe.Factory
{
    public class UserFactory
    {
        public static Response<MsUser> CreateUser(string username, string email, DateTime dob, string gender, string role, string password)
        {
            MsUser user = new MsUser()
            {
                UserDOB = dob,
                UserEmail = email,
                UserName = username,
                UserPassword = password,
                UserRole = role,
                UserGender = gender,
            };

            UserRepository.insertUser(user);

            return new Response<MsUser>()
            {
                Success = true,
                Message = "Register Success!",
                Payload = user
            };
        }
    }
}