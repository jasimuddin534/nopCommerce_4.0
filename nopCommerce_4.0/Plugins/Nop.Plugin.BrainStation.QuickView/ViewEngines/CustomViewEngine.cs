
using Microsoft.AspNetCore.Mvc.Razor;
using Nop.Web.Framework.Themes;
using System.Collections.Generic;
using System.Linq;

namespace Nop.Plugin.BrainStation.QuickView.ViewEngines
{
   public class CustomViewEngine : IViewLocationExpander
    {

        public void PopulateValues(ViewLocationExpanderContext context)
        {
        }

        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            //if (context.AreaName == null && context.ControllerName == "Checkout" && context.ViewName == "OpcShippingMethods")
            
                viewLocations = new string[] { $"/Plugins/BrainStation.QuickView/Views/{{0}}.cshtml" }.Concat(viewLocations);
           

            return viewLocations;

        }
       
    }
}
