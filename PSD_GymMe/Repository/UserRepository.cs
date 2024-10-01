using PSD_GymMe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_GymMe.Repository
{
    public class UserRepository
    {
        static Database1Entities14 db = SingletonDatabase.getInstance();

        public static void insertUser(MsUser user)
        {
            db.MsUsers.Add(user);
            db.SaveChanges();

            return;
        }
        public static List<MsUser> getAllUsers()
        {
            return (from x in db.MsUsers select x).ToList();
        }

        public static MsUser getUser(string username, string password)
        {
            MsUser user = (from x in db.MsUsers where x.UserName == username && x.UserPassword==password select x).FirstOrDefault();
            return user;
        }

        public static MsUser getUserByID(string id)
        {
            int ids=Convert.ToInt32(id);
            MsUser user = (from x in db.MsUsers where x.UserID == ids select x).FirstOrDefault();
            return user;
        }

        public static void deleteUserByID(string id)
        {
            int ids = Convert.ToInt32(id);
            MsUser user = (from x in db.MsUsers where x.UserID == ids select x).FirstOrDefault();
            db.MsUsers.Remove(user);
            db.SaveChanges();
        }

        public static void updateUserProfile(int id,string username, string email, DateTime dob, string gender, string role)
        {
            
            MsUser user = (from x in db.MsUsers where x.UserID == id select x).FirstOrDefault();
            user.UserGender = gender;
            user.UserEmail = email;
            user.UserName=username;
            user.UserDOB = dob;
            user.UserRole = role;
            
            db.SaveChanges();

        }

        public static void updateUserPwd(int id, string password)
        {

            MsUser user = (from x in db.MsUsers where x.UserID == id select x).FirstOrDefault();
            user.UserPassword = password;

            db.SaveChanges();

        }
    }
}