using PSD_GymMe.Factory;
using PSD_GymMe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace PSD_GymMe.Repository
{
    public class SupplementRepository
    {
        static Database1Entities14 db= SingletonDatabase.getInstance();

        public static List<MsSupplement> getAllSupplements()
        {
            return (from x in db.MsSupplements select x).ToList();
        }

        public static MsSupplement getSpByID(string id)
        {
            int ids= Convert.ToInt32(id);
            return (from x in db.MsSupplements where x.SupplementID==ids select x).FirstOrDefault();
        }

        public static void insertSupplement(MsSupplement supplement)
        {
            db.MsSupplements.Add(supplement);
            db.SaveChanges();
        }

        public static void deleteSpByID(string id)
        {
            MsSupplement sp = getSpByID(id);
            db.MsSupplements.Remove(sp);
            db.SaveChanges();

        }

        public static void updateSupplement(string id, string name, DateTime exp, string price, string typID)
        {
            int prc = Convert.ToInt32(price);
            int tyID = Convert.ToInt32(typID);

            MsSupplement sp = getSpByID(id);

            sp.SupplementPrice = prc;
            sp.SupplementExpiryDate = exp;
            sp.SupplementName = name;
            sp.SupplementTypeID = tyID;

            db.SaveChanges();
        }

    }
}