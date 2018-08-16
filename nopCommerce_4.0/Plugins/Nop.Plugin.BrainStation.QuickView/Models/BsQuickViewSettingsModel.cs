﻿using System.Collections.Generic;
using Nop.Web.Framework;
using Nop.Web.Framework.Mvc;
using Nop.Web.Framework.Mvc.ModelBinding;
using Nop.Web.Framework.Mvc.Models;

namespace Nop.Plugin.BrainStation.QuickView.Models
{
    public class BsQuickViewSettingsModel : BaseNopEntityModel
    {
        
        [NopResourceDisplayName("Plugins.BsQuickView.Fields.ShowAlsoPurchased")]
        public bool ShowAlsoPurchased { get; set; }
        [NopResourceDisplayName("Plugins.BsQuickView.Fields.ShowRelatedProducts")]
        public bool ShowRelatedProducts { get; set; }
        [NopResourceDisplayName("Plugins.BsQuickView.Fields.EnableWidget")]
        public bool EnableWidget { get; set; }
        [NopResourceDisplayName("Plugins.BsQuickView.Fields.EnableEnlargePicture")]
        public bool EnableEnlargePicture { get; set; }
        [NopResourceDisplayName("Plugins.BsQuickView.Fields.ButtonContainerName")]
        public string ButtonContainerName { get; set; }


    }
}