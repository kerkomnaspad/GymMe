using PSD_GymMe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_GymMe.Repository
{
    public class CartRepository
    {
        static Database1Entities14 db= SingletonDatabase.getInstance();
        public static void InsertCart(MsCart mc)
        {
            db.MsCarts.Add(mc);
            db.SaveChanges();
        }

        public static List<MsCart> GetCartByUID(int uID) 
        { 
            return(from x in db.MsCarts where x.UserID == uID select x).ToList();
        }

        public static void DeleteCart(int uID)
        {
            List<MsCart> cart= (from x in db.MsCarts where x.UserID==uID select x).ToList();

            foreach (MsCart mc in cart) 
            {
                db.MsCarts.Remove(mc);
            }
            
            db.SaveChanges();
        }
    }
}