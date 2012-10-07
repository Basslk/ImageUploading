using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlrawiLtd.Infrastructure
{
    public static class Helpers
    {
        public static string GenerateUniqueFileName()
        {
            return (DateTime.Now.ToLongDateString() + DateTime.Now.ToLongTimeString()).GetHashCode().ToString();
        }
    }
}