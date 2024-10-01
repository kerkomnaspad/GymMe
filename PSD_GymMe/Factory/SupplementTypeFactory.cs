using PSD_GymMe.Model;
using PSD_GymMe.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_GymMe.Factory
{
    public class SupplementTypeFactory
    {
        public static void createSupplementType()
        {
            MsSupplementType st = new MsSupplementType()
            {
                SupplementTypeName="Suple"
            };

            SupplementTypeRepository.insertSupplementType(st);
            return;
        }
    }
}