using PSD_GymMe.Controller;
using PSD_GymMe.Model;
using PSD_GymMe.Modules;
using PSD_GymMe.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_GymMe.Handler
{
    public class CartHandler
    {

        public static Response<int> ValidateQty(string qty)
        {
            Response<int> isNumeric = TransactionController.IsNumeric(qty);


            int quantity = isNumeric.Payload;

            if (quantity <= 0)
            {
                return new Response<int>()
                {
                    Success = false,
                    Message = "Selected quantity must be more than 0!",
                    Payload = 0,
                };

            }

            return isNumeric;
        }

        public static List<MsCart> GetUserCart(int uID) 
        { 
            return CartRepository.GetCartByUID(uID);
        }

        public static void DeleteUserCart(int uID)
        {
            CartRepository.DeleteCart(uID);
        }

    }
}