using PSD_GymMe.Model;
using PSD_GymMe.Modules;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace PSD_GymMe.Controller
{
    public class TransactionController
    {
        public static Response<int> IsNumeric(string qty)
        {
            

            int pr;
            try
            {
                pr = Convert.ToInt32(qty);
            }
            catch (FormatException)
            {
                return new Response<int>()
                {
                    Success = false,
                    Message = "Numbers only!",
                    Payload = 0
                };
            }


            return new Response<int>()
            {
                Success = true,
                Message = "Valid.",
                Payload = pr,
            };

        }
    }
}