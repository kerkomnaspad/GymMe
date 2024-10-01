using PSD_GymMe.Model;
using PSD_GymMe.Modules;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.Linq;

namespace PSD_GymMe.Controller
{
    public class SupplementController
    {

        public static Response<MsSupplement> SpName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return new Response<MsSupplement>()
                {
                    Success = false,
                    Message = "Supplement name must not be empty!",
                    Payload = null
                };
            }

            if (!name.Contains("Supplement"))
            {
                return new Response<MsSupplement>()
                {
                    Success = false,
                    Message = "Supplement name must contain 'Supplement' .",
                    Payload = null
                };
            }

            return new Response<MsSupplement>()
            {
                Success = true,
                Message = "Valid.",
                Payload = null
            };

        }

        public static Response<MsSupplement> SpPrice(string price)
        {



            if (string.IsNullOrEmpty(price))
            {
                return new Response<MsSupplement>()
                {
                    Success = false,
                    Message = "Price cannot be empty!",
                    Payload = null
                };
            }

            int pr;
            try
            {
                pr = Convert.ToInt32(price);
            }
            catch (FormatException)
            {
                return new Response<MsSupplement>()
                {
                    Success = false,
                    Message = "Numbers only!",
                    Payload = null
                };
            }

            if (pr<3000)
            {
                return new Response<MsSupplement>()
                {
                    Success = false,
                    Message = "Price must be at least 3000.",
                    Payload = null
                };
            }




            return new Response<MsSupplement>()
            {
                Success = true,
                Message = "Valid.",
                Payload = null
            };

        }

        public static Response<DateTime> ValidateEXP(string date)
        {
            if (date == null)
            {
                return new Response<DateTime>()
                {
                    Success = false,
                    Message = "Expiry date must not be empty!",
                    Payload = DateTime.MinValue
                };
            }
            DateTime dateTime;
            if (DateTime.TryParse(date, out dateTime))
            {
                if (dateTime < DateTime.Now)
                {
                    return new Response<DateTime>()
                    {
                        Success = false,
                        Message = "Expiry Date must be greater than today's date.",
                        Payload = DateTime.MinValue
                    };
                }


                return new Response<DateTime>()
                {
                    Success = true,
                    Message = "Valid.",
                    Payload = dateTime
                };

            }
            else
            {
                return new Response<DateTime>()
                {
                    Success = false,
                    Message = "Please fill in Expiry Date correctly",
                    Payload = DateTime.MinValue
                };
            }
            //return "OK";
        }

        public static Response<MsSupplement> SpTypID(string id)
        {

            if (string.IsNullOrEmpty(id))
            {
                return new Response<MsSupplement>()
                {
                    Success = false,
                    Message = "Type ID cannot be empty!",
                    Payload = null
                };
            }

            int typID;
            try
            {
                typID = Convert.ToInt32(id);
            }
            catch (FormatException)
            {
                return new Response<MsSupplement>()
                {
                    Success = false,
                    Message = "Numbers only!",
                    Payload = null
                };
            }


            return new Response<MsSupplement>()
            {
                Success = true,
                Message = "Valid.",
                Payload = null
            };

        }
    }
}