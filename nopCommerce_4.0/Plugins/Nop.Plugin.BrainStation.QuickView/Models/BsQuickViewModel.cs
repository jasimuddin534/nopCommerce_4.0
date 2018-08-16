using System.Collections.Generic;
using Nop.Web.Framework;
using Nop.Web.Framework.Mvc;
using Nop.Web.Models.Catalog;
using Nop.Web;
using Nop.Web.Framework.Mvc.Models;

namespace Nop.Plugin.BrainStation.QuickView.Models
{
    public class BsQuickViewModel : BaseNopEntityModel
    {
        public BsQuickViewModel()
        {
            ProductDetailsModel = new ProductDetailsModel();
            BsQuickViewSettingsModel = new BsQuickViewSettingsModel();
        }

        public ProductDetailsModel ProductDetailsModel { get; set; }
        public BsQuickViewSettingsModel BsQuickViewSettingsModel { get; set; }


        

    }
}