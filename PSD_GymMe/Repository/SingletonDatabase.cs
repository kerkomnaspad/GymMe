using PSD_GymMe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_GymMe.Repository
{
    
    public class SingletonDatabase
    {
        private static Database1Entities14 instance;

        public static Database1Entities14 getInstance() 
        { 
            if(instance == null)
            {
                instance = new Database1Entities14();
            }
            return instance;
        }
    }
}