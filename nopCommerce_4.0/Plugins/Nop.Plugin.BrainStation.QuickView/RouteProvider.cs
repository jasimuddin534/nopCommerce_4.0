
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Nop.Plugin.BrainStation.QuickView.ViewEngines;

using Nop.Web.Framework.Mvc.Routing;

namespace Nop.Plugin.BrainStation.QuickView
{
    public partial class RouteProvider : IRouteProvider
    {
        public void RegisterRoutes(IRouteBuilder routes)
        {
           // System.Web.Mvc.ViewEngines.Engines.Insert(0, new CustomViewEngine());


            routes.MapRoute("Nop.Plugin.BrainStation.QuickView.ProductDetails", "bs_product_details",
                new { controller = "BsQuickView", action = "ProductDetails"});

            routes.MapRoute("Admin.Plugin.BrainStation.QuickView.Settings", "Admin/Plugin/BrainStation/QuickView/Settings",
                   new { controller = "BsQuickViewAdmin", action = "BsQuickViewSettings" });

            routes.MapRoute("Admin.Plugin.BrainStation.QuickView.Help", "Admin/Plugin/BrainStation/QuickView/Help",
                   new { controller = "BsQuickViewAdmin", action = "BsQuickViewHelp" });

            routes.MapRoute("Admin.Plugin.BrainStation.QuickView.SaveSettings", "Admin/Plugin/QuickView/Settings/Save",
                   new { controller = "BsQuickViewAdmin", action = "BsQuickViewSettings" });

           

        }

     

        public int Priority
        {
            get { return 10; }
        }

    }
}
