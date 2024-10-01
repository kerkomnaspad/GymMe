using PSD_GymMe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_GymMe.Repository
{
    public class SupplementTypeRepository
    {
        static Database1Entities14 db = SingletonDatabase.getInstance();

        public static void insertSupplementType(MsSupplementType st)
        {
            db.MsSupplementTypes.Add(st);
            db.SaveChanges();
            
        }

        public static List<MsSupplementType> GetAllSpType()
        {
            return (from x in db.MsSupplementTypes select x).ToList();
        }

        public static MsSupplementType getSpTypeID(string id)
        {
            int ids = Convert.ToInt32(id);
            return (from x in db.MsSupplementTypes where x.SupplementTypeID == ids select x).FirstOrDefault();
        }
    }
}