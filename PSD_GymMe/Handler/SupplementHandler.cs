using PSD_GymMe.Controller;
using PSD_GymMe.Factory;
using PSD_GymMe.Model;
using PSD_GymMe.Modules;
using PSD_GymMe.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Query.Dynamic;
using System.Web.Services.Description;
using System.Xml.Linq;

namespace PSD_GymMe.Handler
{
    public class SupplementHandler
    {
        public static bool CheckSpTypeID(string id)
        {
            MsSupplementType supplementType = SupplementTypeRepository.getSpTypeID(id);

            if (supplementType == null) 
            {
                return false;
            }
            return true;
        }

        public static Response<MsSupplement> ValidateSupplementInsert(string name, string date,string prc, string typID)
        {
            Response<MsSupplement> SpName = SupplementController.SpName(name);
            Response<DateTime> ExpDate = SupplementController.ValidateEXP(date);
            Response<MsSupplement> price = SupplementController.SpPrice(prc);
            Response<MsSupplement> typeID = SupplementController.SpTypID(typID);
            

            if (SpName.Success == false)
            {
                return SpName;
            }

            if (ExpDate.Success == false)
            {
                return new Response<MsSupplement>()
                {
                    Success = false,
                    Message = ExpDate.Message,
                    Payload = null
                };
                    
            }

            if (price.Success == false)
            {
                return price;
            }

            if (typeID.Success == false)
            {
                return typeID;
            }

            if(CheckSpTypeID(typID)==false)
            {
                return new Response<MsSupplement>()
                {
                    Success = false,
                    Message = "Supplement Type ID does not exist!",
                    Payload = null
                };
            }

            Response<MsSupplement> newSp = SupplementFactory.CreateSupplement(name, ExpDate.Payload, prc, typID);

            return newSp;


        }

        public static Response<MsSupplement> ValidateSupplementUpdate(string id,string name, string date, string prc, string typID)
        {
            Response<MsSupplement> SpName = SupplementController.SpName(name);
            Response<DateTime> ExpDate = SupplementController.ValidateEXP(date);
            Response<MsSupplement> price = SupplementController.SpPrice(prc);
            Response<MsSupplement> typeID = SupplementController.SpTypID(typID);


            if (SpName.Success == false)
            {
                return SpName;
            }

            if (ExpDate.Success == false)
            {
                return new Response<MsSupplement>()
                {
                    Success = false,
                    Message = ExpDate.Message,
                    Payload = null
                };

            }

            if (price.Success == false)
            {
                return price;
            }

            if (typeID.Success == false)
            {
                return typeID;
            }

            if (CheckSpTypeID(typID) == false)
            {
                return new Response<MsSupplement>()
                {
                    Success = false,
                    Message = "Supplement Type ID does not exist!",
                    Payload = null
                };
            }

            SupplementRepository.updateSupplement(id,name, ExpDate.Payload, prc, typID);

            return new Response<MsSupplement>()
            {
                Success=true,
                Message="Update Success!",
                Payload=null
            };


        }

        public static List<MsSupplement> GetAllSupplements()
        {
            return SupplementRepository.getAllSupplements();
        }

        public static MsSupplement GetSpByID(string id)
        {
            return SupplementRepository.getSpByID(id);
        }

        public static MsSupplementType GetSpTyByID(string id)
        {
            return SupplementTypeRepository.getSpTypeID(id);
        }

        public static void DeleteSpByID(string id)
        {
            SupplementRepository.deleteSpByID(id);
            return;
        }

        public static Response<int> ValidateQty(string qty)
        {
            
            int yes;
            if(qty == null)
            {
                yes = 0;
            }

            bool isNumeric= int.TryParse(qty, out yes);
            if (isNumeric== false)
            {
                return new Response<int>()
                {
                    Success = false,
                    Message = "Quantity must be numeric.",
                    Payload = 0
                };
            }

            if(yes<=0) 
            {
                return new Response<int>()
                {
                    Success = false,
                    Message = "Quantity must be greater than 0.",
                    Payload = 0
                };
            }

            return new Response<int>()
            {
                Success = true,
                Message = "Valid.",
                Payload = yes
            };
        }

        public static List<dynamic> GetAllSupplement_Merged()
        {
            Database1Entities14 db = SingletonDatabase.getInstance();

            var query= (from x in db.MsSupplements
                    join g in db.MsSupplementTypes on x.SupplementTypeID equals g.SupplementTypeID
                    select new
                    {
                        x.SupplementID,
                        g.SupplementTypeName,
                        x.SupplementName,
                        x.SupplementExpiryDate,
                        x.SupplementPrice,
                    }
                    ).ToList();
            return query.Cast<dynamic>().ToList();
        }
    }
}