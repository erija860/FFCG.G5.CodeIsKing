﻿using System.Web;
using System.Web.Mvc;

namespace FFCG.G5.GameOfLife.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
