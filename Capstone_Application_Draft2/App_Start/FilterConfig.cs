﻿using System.Web;
using System.Web.Mvc;

namespace Capstone_Application_Draft2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
