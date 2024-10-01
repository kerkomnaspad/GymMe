using PSD_GymMe.Controller;
using PSD_GymMe.Factory;
using PSD_GymMe.Model;
using PSD_GymMe.Modules;
using PSD_GymMe.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_GymMe.Handler
{
    public class UserHandler
    {

        public static MsUser userLogin(string username, string password)
        {
            MsUser user = UserRepository.getUser(username,password);

            return user;
        }
        
        public static List<MsUser> getAllUser()
        {
            return UserRepository.getAllUsers();
        }

        public static MsUser GetUserByID(string id)
        {
            return UserRepository.getUserByID(id);
        }

        public static void DeleteUserByID(string id)
        {
            UserRepository.deleteUserByID(id);
            return;
        }

        public static bool isAdmin(MsUser usr) 
        {
            if (usr.UserRole=="Admin")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Response<MsUser> ValidateLogin(string name, string pwd) 
        {
            Response<MsUser> username =UserController.ValidateUsername(name);
            Response<MsUser> password =UserController.ValidatePwd(pwd);
            
            if(username.Success==false) 
            {
                return username;
            }

            if (password.Success == false)
            {
                return password;
            }

            MsUser usr= UserRepository.getUser(name, pwd);

            if(usr==null)
            {
                return new Response<MsUser>()
                {
                    Success = false,
                    Message = "Username or password is false.",
                    Payload = null
                };
            }

            return new Response<MsUser>()
            {
                Success = true,
                Message = "Login Success",
                Payload = usr
            };

        }

        public static Response<MsUser> ValidateRegister(string name, string mail, string gdr, string pwd, string Cpwd, string date)
        {
            Response<MsUser> username = UserController.ValidateUsername(name);
            Response<MsUser> email = UserController.ValidateEmail(mail);
            Response<MsUser> gender = UserController.ValidateGender(gdr);
            Response<MsUser> password = UserController.ValidatePwd(pwd);
            Response<MsUser> Cpassword = UserController.ValidateCPwd(pwd,Cpwd);
            Response<DateTime> dateTime = UserController.ValidateDOB(date);

            if (username.Success == false)
            {
                return username;
            }

            if (email.Success == false)
            {
                return email;
            }

            if (gender.Success == false)
            {
                return gender;
            }

            if (password.Success == false)
            {
                return password;
            }

            if (Cpassword.Success == false)
            {
                return Cpassword;
            }

            if (dateTime.Success == false)
            {
                return new Response<MsUser>()
                {
                    Success = false,
                    Message= dateTime.Message,
                    Payload=null
                };
            }

            Response<MsUser> newUser= UserFactory.CreateUser(name, mail, dateTime.Payload, gdr, "Customer", pwd);

            return newUser;

            
        }

        public static Response<MsUser> ValidateUpdateProf(int id,string name, string mail, string gdr, string date, string rol)
        {
            Response<MsUser> username = UserController.ValidateUsername(name);
            Response<MsUser> email = UserController.ValidateEmail(mail);
            Response<MsUser> gender = UserController.ValidateGender(gdr);
            Response<DateTime> dateTime = UserController.ValidateDOB(date);
            Response<MsUser> role = UserController.ValidateRole(rol);

            if (username.Success == false)
            {
                return username;
            }

            if (email.Success == false)
            {
                return email;
            }

            if (gender.Success == false)
            {
                return gender;
            }

            if (dateTime.Success == false)
            {
                return new Response<MsUser>()
                {
                    Success = false,
                    Message = dateTime.Message,
                    Payload = null
                };
            }

            if (role.Success == false)
            {
                return role;
            }

            UserRepository.updateUserProfile(id,name,mail,dateTime.Payload,gdr,rol);

            return new Response<MsUser>()
            {
                Success=true,
                Message="Profile Updated!",
                Payload=null
            };


        }

        public static Response<MsUser> ValidateUpdatePwd(int id,string currPwd, string pwd, string Opwd)
        {
            
            Response<MsUser> password = UserController.ValidatePwd(pwd);
            Response<MsUser> Opassword = UserController.ValidateOldPwd(currPwd, Opwd);
            

            

            if (password.Success == false)
            {
                return password;
            }

            if (Opassword.Success == false)
            {
                return Opassword;
            }

            
            

            UserRepository.updateUserPwd(id,pwd);

            return new Response<MsUser>()
            {
                Success = true,
                Message = "Password Updated!",
                Payload = null
            };


        }

    }
}