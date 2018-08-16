using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Media;
using Nop.Core.Domain.Orders;
using Nop.Core.Domain.Seo;
using Nop.Core.Domain.Vendors;
using Nop.Plugin.BrainStation.QuickView.Models;
using Nop.Services.Configuration;
using Nop.Web.Extensions;
using Nop.Plugin.BrainStation.QuickView.Infrastructure.Cache;


using Nop.Services.Catalog;

using Nop.Services.Customers;
using Nop.Services.Directory;
using Nop.Services.Helpers;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Media;
using Nop.Services.Messages;
using Nop.Services.Orders;
using Nop.Services.Security;
using Nop.Services.Seo;
using Nop.Services.Shipping;
using Nop.Services.Stores;
using Nop.Services.Tax;
using Nop.Services.Vendors;
using Nop.Web.Controllers;

using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Security.Captcha;
using Nop.Web.Models.Catalog;
using Nop.Web.Models.Media;
using Nop.Web.Areas.Admin.Controllers;
using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.BrainStation.QuickView.Controllers
{
    public class BsQuickViewAdminController : BaseAdminController
    {

        
        private readonly ISettingService _settingService;
        private readonly ILocalizationService _localizationService;


        public BsQuickViewAdminController(ISettingService settingService,ILocalizationService localizationService)
        {
            this._settingService = settingService;
            _localizationService = localizationService;
        }


        #region Configure Action

        public ActionResult Configure()
        {
            var model = new BsQuickViewSettingsModel();

            var quickViewsettings = _settingService.LoadSetting<QuickViewSettings>();

            model.ButtonContainerName = quickViewsettings.ButtonContainerName;
            model.EnableWidget = quickViewsettings.EnableWidget;
            model.ShowAlsoPurchased = quickViewsettings.ShowAlsoPurchased;
            model.ShowRelatedProducts = quickViewsettings.ShowRelatedProducts;
            model.EnableEnlargePicture = quickViewsettings.EnableEnlargePicture;

            return View("BsQuickViewAdmin/Configure", model);
        }


        [HttpPost]
        public IActionResult Configure(BsQuickViewSettingsModel model)
        {
            
            var settings = new QuickViewSettings()
            {
                EnableWidget = model.EnableWidget,
                ShowAlsoPurchased = model.ShowAlsoPurchased,

                ShowRelatedProducts = model.ShowRelatedProducts,
                ButtonContainerName = model.ButtonContainerName,
                EnableEnlargePicture = model.EnableEnlargePicture,

            };

            _settingService.SaveSetting(settings);
            SuccessNotification(_localizationService.GetResource("Admin.Plugins.Saved"));
            return Configure();
        }

        public ActionResult BsQuickViewHelp()
        {
            
            return View("BsQuickViewAdmin/BsQuickViewHelp");
        }
        #endregion

    }
}