using PSD_GymMe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_GymMe.Repository
{
    public class TransactionHeaderRepository
    {
        static Database1Entities14 db= SingletonDatabase.getInstance();
        public static void AddTransactionHeader(TransactionHeader th)
        {
            db.TransactionHeaders.Add(th);
            db.SaveChanges();

            return;
        }

        public static List<TransactionHeader> GetAllTransaction()
        {
            return (from x in db.TransactionHeaders select x).ToList();
        }

        public static List<TransactionHeader> GetAllTransactionByID(int uID)
        {
            return (from x in db.TransactionHeaders where x.UserID==uID select x).ToList();
        }

        public static TransactionHeader GetTransactionByID(int tID)
        {   
            return(from x in db.TransactionHeaders where x.TransactionID==tID select x).FirstOrDefault();
        }

        public static void Handle(int tID)
        {
            TransactionHeader th = (from x in db.TransactionHeaders where x.TransactionID == tID select x).FirstOrDefault();
            th.Status = "HANDLED";
            db.SaveChanges();
        }

    }
}