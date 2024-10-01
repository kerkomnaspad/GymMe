using PSD_GymMe.Controller;
using PSD_GymMe.Factory;
using PSD_GymMe.Model;
using PSD_GymMe.Modules;
using PSD_GymMe.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace PSD_GymMe.Handler
{
    public class TransactionHandler
    {

        public static Response<string> CreateTransaction(int uID, List<MsCart> cart)
        {
            Response<TransactionHeader> th = TransactionHeaderFactory.CreateHeader(uID);
            foreach (MsCart cartItem in cart)
            {
                //Response<TransactionHeader> th = TransactionHeaderFactory.CreateHeader(uID);
                TransactionDetailFactory.CreateDetail(cartItem.SuplementID, cartItem.Quantity, th.Payload.TransactionID);
            }

            return new Response<string>
            {
                Success = true,
                Message = "Ordered successfully!",
                Payload = null,
            };
        }

        public static void Handle(string tID)
        {
            TransactionHeaderRepository.Handle(Convert.ToInt16(tID));
        }

        public static List<TransactionHeader> GetAllTransactions()
        {
            return TransactionHeaderRepository.GetAllTransaction();
        }

        public static List<TransactionHeader> GetTransactionsByID(int uID)
        {
            return TransactionHeaderRepository.GetAllTransactionByID(uID);
        }

        public static TransactionHeader GetHeader(string tID)
        {
            return TransactionHeaderRepository.GetTransactionByID(Convert.ToInt16(tID));
        }

        public static Response<TransactionDetail> GetTransactionDetailByID(string tID)
        {
            TransactionDetail td = TransactionDetailRepository.GetTransactionDetailByID(Convert.ToInt16(tID));
            return new Response<TransactionDetail>()
            {
                Success = true,
                Message = "Valid.",
                Payload = td,
            };

        }

        public static Response<List<TransactionDetail>> GetAllTransactionDetailByID(string tID)
        {
            List<TransactionDetail> td = TransactionDetailRepository.GetAllTransactionDetailByID(Convert.ToInt16(tID));
            return new Response<List<TransactionDetail>>()
            {
                Success = true,
                Message = "Valid.",
                Payload = td,
            };

        }

        public static List<dynamic> GetAllInfo(string ttID)
        {
            Database1Entities14 db = SingletonDatabase.getInstance();

            int tID = Convert.ToInt32(ttID);
            var query = (from x in db.MsSupplements
                         join g in db.MsSupplementTypes on x.SupplementTypeID equals g.SupplementTypeID
                         join t in db.TransactionDetails on x.SupplementID equals t.SupplementID where t.TransactionID == tID
                         select new
                         {
                             x.SupplementID,
                             g.SupplementTypeName,
                             x.SupplementName,
                             x.SupplementExpiryDate,
                             x.SupplementPrice,
                             g.SupplementTypeID,
                             t.Quantity,
                         }
                    ).ToList();
            return query.Cast<dynamic>().ToList();
        }
    }
}