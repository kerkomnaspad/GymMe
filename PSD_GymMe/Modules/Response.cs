using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_GymMe.Modules
{
    public class Response<T>
    {
         public Boolean Success;
         public string Message;
         public T Payload;
    }
}