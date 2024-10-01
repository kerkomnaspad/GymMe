using PSD_GymMe.Model;
using PSD_GymMe.Modules;
using PSD_GymMe.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_GymMe.Factory
{
    public class CartFactory
    {
        
            //string name, int price, DateTime exp, int typeID
            public static Response<MsCart> CreateCart(string sID, int qty, int uID)
            {
                int supID = Convert.ToInt32(sID);
                ;
                MsCart mc = new MsCart()
                {
                    UserID = uID,
                    Quantity = qty,
                    SuplementID = supID,
                };

                CartRepository.InsertCart(mc);

                return new Response<MsCart>()
                {
                    Success = true,
                    Message = "Cart inserted!",
                    Payload = mc
                };
            }

            

        
    }
}