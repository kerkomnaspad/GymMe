using PSD_GymMe.Model;
using PSD_GymMe.Modules;
using PSD_GymMe.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_GymMe.Factory
{
    public class TransactionHeaderFactory
    {
        public static Response<TransactionHeader> CreateHeader(int uID)
        {
            TransactionHeader th= new TransactionHeader()
            {
                Status= "UNHANDLED",
                TransactionDate= DateTime.Now,
                UserID=Convert.ToInt32(uID),
            };

            TransactionHeaderRepository.AddTransactionHeader(th);

            return new Response<TransactionHeader>()
            {
                Success = true,
                Message = "TransactionDetail created!",
                Payload = th,

            };
        }
    }
}