using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.BrainStation.QuickView.Models;
using Nop.Services.Configuration;
using Nop.Web.Framework.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.BrainStation.QuickView.Components
{


    [ViewComponent(Name = "BsQuickViewPublicInfo")]
    public class BsQuickViewPublicInfoViewComponent : NopViewComponent
    {
        private readonly ISettingService _settingsService;

        public BsQuickViewPublicInfoViewComponent( ISettingService settingService)
        {
            _settingsService = settingService;
        }

        public IViewComponentResult Invoke()
        {
            var settingsModel = new BsQuickViewSettingsModel();
            var quickViewsettings = _settingsService.LoadSetting<QuickViewSettings>();
            settingsModel.ButtonContainerName = quickViewsettings.ButtonContainerName;
            settingsModel.EnableWidget = quickViewsettings.EnableWidget;
            settingsModel.ShowAlsoPurchased = quickViewsettings.ShowAlsoPurchased;
            settingsModel.ShowRelatedProducts = quickViewsettings.ShowRelatedProducts;
            settingsModel.EnableEnlargePicture = quickViewsettings.EnableEnlargePicture;


            return View("~/Plugins/BrainStation.QuickView/Views/BsQuickView/QuickViewButton.cshtml", settingsModel);
        }

    }
}
