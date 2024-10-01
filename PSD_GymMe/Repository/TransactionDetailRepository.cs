using PSD_GymMe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Util;

namespace PSD_GymMe.Repository
{
    public class TransactionDetailRepository
    {
        static Database1Entities14 db = SingletonDatabase.getInstance();
        public static void AddTransactionDetail(TransactionDetail td)
        {
            db.TransactionDetails.Add(td);
            db.SaveChanges();

            return;
        }

        public static TransactionDetail GetTransactionDetailByID(int id)
        {
            return (from x in db.TransactionDetails where x.TransactionID == id select x).FirstOrDefault();

        }

        public static List <TransactionDetail> GetAllTransactionDetailByID(int id)
        {
            return (from x in db.TransactionDetails where x.TransactionID == id select x).ToList();

        }



    }
}