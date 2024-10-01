using PSD_GymMe.Model;
using PSD_GymMe.Modules;
using PSD_GymMe.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;

namespace PSD_GymMe.Factory
{
    public class TransactionDetailFactory
    {
        public static Response<TransactionDetail> CreateDetail(int sID, int qty, int tID)
        {
            TransactionDetail td = new TransactionDetail()
            {
                SupplementID=sID,
                Quantity=qty,
                TransactionID=tID
            };

            TransactionDetailRepository.AddTransactionDetail(td); 

            return new Response<TransactionDetail>()
            {
                Success = true,
                Message="TransactionDetail created!",
                Payload=td,
                
            };
        }
    }
}