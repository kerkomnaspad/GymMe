using PSD_GymMe.Model;
using PSD_GymMe.Modules;
using PSD_GymMe.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_GymMe.Factory
{
    public class SupplementFactory
    {
        //string name, int price, DateTime exp, int typeID
        public static Response<MsSupplement> CreateSupplement(string name, DateTime exp, string price, string typID)
        {
            int prc= Convert.ToInt32(price);
            int tyID= Convert.ToInt32(typID);
            MsSupplement sp = new MsSupplement()
            {
                SupplementName = name,
                SupplementPrice = prc,
                SupplementExpiryDate = exp,
                SupplementTypeID = tyID,
            };

            SupplementRepository.insertSupplement(sp);
            
            return new Response<MsSupplement>()
            {
                Success=true,
                Message="Supplement inserted!",
                Payload=sp
            };
        }
        
    }
}