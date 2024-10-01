using PSD_GymMe.Model;
using PSD_GymMe.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace PSD_GymMe.Controller
{
    public class UserController
    {
        public static Response<MsUser> ValidateUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return new Response<MsUser>()
                {
                    Success = false,
                    Message = "Username must not be empty!",
                    Payload = null
                };


            }

            if (username.Length < 5 || username.Length > 15)
            {
                return new Response<MsUser>()
                {
                    Success = false,
                    Message = "Username length must be between 5 and 15 characters.",
                    Payload = null
                };

                
            }
        

            Regex regex = new Regex(@"^[a-zA-Z ]+$");

            if (!regex.IsMatch(username))
            {
                return new Response<MsUser>()
                {
                    Success = false,
                    Message = "Username must be alphabet with space only.",
                    Payload = null
                };
            }

            return new Response<MsUser>()
            {
                Success = true,
                Message = "Valid.",
                Payload = null
            };

        }

        public static Response<MsUser> ValidateEmail(string email)
        { 
            if (string.IsNullOrEmpty(email))
            {
                return new Response<MsUser>()
                {
                    Success = false,
                    Message = "Email must not be empty!",
                    Payload = null
                };
            }
            if (!email.EndsWith(".com"))
            {
                
                return new Response<MsUser>()
                {
                    Success = false,
                    Message = "Email must end with &quot;.com&quot; ",
                    Payload = null
                };
            }

            
            return new Response<MsUser>()
            {
                Success = true,
                Message = "Valid.",
                Payload = null
            };
        }

        public static Response<MsUser> ValidateGender(string gender)
        {
            if (string.IsNullOrEmpty(gender))
            {
                return new Response<MsUser>()
                {
                    Success = false,
                    Message = "Gender must not be empty!",
                    Payload = null
                };
            }

            return new Response<MsUser>()
            {
                Success = true,
                Message = "Valid.",
                Payload = null
            };
        }

        public static Response<MsUser> ValidatePwd(string pwd)
        {
            if (string.IsNullOrEmpty(pwd))
            {
                return new Response<MsUser>()
                {
                    Success = false,
                    Message = "Password must not be empty!",
                    Payload = null
                };
            }
            Regex regex = new Regex(@"^[a-zA-Z0-9]+$");
            if (!regex.IsMatch(pwd))
            {
                return new Response<MsUser>()
                {
                    Success = false,
                    Message = "Password must be alphanumeric.",
                    Payload = null
                };
            }

            return new Response<MsUser>()
            {
                Success = true,
                Message = "Valid.",
                Payload = null
            };
        }

        public static Response<MsUser> ValidateOldPwd(string pwd, string prevpwd)
        {
            if (string.IsNullOrEmpty(pwd))
            {
                return new Response<MsUser>()
                {
                    Success = false,
                    Message = "Password must not be empty!",
                    Payload = null
                };
            }
            
            if (pwd!=prevpwd)
            {
                
                return new Response<MsUser>()
                {
                    Success = false,
                    Message = "Password must be the same as old password.",
                    Payload = null
                };
            }

            return new Response<MsUser>()
            {
                Success = true,
                Message = "Valid.",
                Payload = null
            };
        }

        public static Response<MsUser> ValidateCPwd(string pwd, string cpwd)
        {
            
            if (pwd != cpwd)
            {
                return new Response<MsUser>()
                {
                    Success = false,
                    Message = "Confirm password must be the same with password.",
                    Payload = null
                };
            }
            
            return new Response<MsUser>()
            {
                Success = true,
                Message = "Valid.",
                Payload = null
            };
        }

        public static Response<DateTime> ValidateDOB(string date)
        {
            if (string.IsNullOrEmpty(date))
            {
                return new Response<DateTime>()
                {
                    Success = false,
                    Message = "Date of birth must not be empty!",
                    Payload = DateTime.MinValue
                };

            }
            DateTime dateTime;
            if (DateTime.TryParse(date, out dateTime))
            {
                return new Response<DateTime>()
                {
                    Success = true,
                    Message = "Valid.",
                    Payload = dateTime
                };
            }
            else
            {
                return new Response<DateTime>()
                {
                    Success = false,
                    Message = "Please fill in Date of Birth correctly",
                    Payload = DateTime.MinValue
                };
            }
            
        }

        public static Response<MsUser> ValidateRole(string role)
        {
            if (role == null)
            {
               
                return new Response<MsUser>()
                {
                    Success = false,
                    Message = "Role cannot be empty!",
                    Payload = null
                };
            }
            if(role!="Admin" && role!="Customer")
            {
                
                return new Response<MsUser>()
                {
                    Success = false,
                    Message = "Role is Admin or Customer only (Case sensitive!)",
                    Payload = null
                };
            }

            
            return new Response<MsUser>()
            {
                Success = true,
                Message = "Valid.",
                Payload = null
            };
        }
    }
}