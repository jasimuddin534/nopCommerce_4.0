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
using Nop.Core.Infrastructure;
using Nop.Plugin.BrainStation.QuickView.Models;
using Nop.Services.Configuration;
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
using Nop.Services.Shipping.Date;
using Nop.Services.Stores;
using Nop.Services.Tax;
using Nop.Services.Vendors;
using Nop.Web.Controllers;
using Nop.Web.Extensions;
using Nop.Web.Factories;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc;
using Nop.Web.Framework.Security;
using Nop.Web.Models.Catalog;
using Nop.Web.Models.Checkout;
using Nop.Web.Models.Media;
using Nop.Web.Framework.Security.Captcha;
using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.BrainStation.QuickView.Controllers
{
    public class BsQuickViewController :  BasePluginController
    {
        
        
        


        private readonly ICategoryService _categoryService;
        private readonly IManufacturerService _manufacturerService;
        private readonly IProductService _productService;
        private readonly IVendorService _vendorService;
        private readonly IProductTemplateService _productTemplateService;
        private readonly IProductAttributeService _productAttributeService;
        private readonly IWorkContext _workContext;
        private readonly IStoreContext _storeContext;
        private readonly ITaxService _taxService;
        private readonly ICurrencyService _currencyService;
        private readonly IPictureService _pictureService;
        private readonly ILocalizationService _localizationService;
        //change-3.7
        private readonly IMeasureService _measureService;
        private readonly IPriceCalculationService _priceCalculationService;
        private readonly IPriceFormatter _priceFormatter;
        private readonly IWebHelper _webHelper;
        private readonly ISpecificationAttributeService _specificationAttributeService;
        private readonly IDateTimeHelper _dateTimeHelper;
        private readonly IRecentlyViewedProductsService _recentlyViewedProductsService;
        private readonly ICompareProductsService _compareProductsService;
        private readonly IWorkflowMessageService _workflowMessageService;
        private readonly IProductTagService _productTagService;
        private readonly IOrderReportService _orderReportService;
        private readonly IBackInStockSubscriptionService _backInStockSubscriptionService;
        private readonly IAclService _aclService;
        private readonly IStoreMappingService _storeMappingService;
        private readonly IPermissionService _permissionService;
        private readonly ICustomerActivityService _customerActivityService;
        private readonly IProductAttributeParser _productAttributeParser;
        private readonly IShippingService _shippingService;
        private readonly MediaSettings _mediaSettings;
        private readonly CatalogSettings _catalogSettings;
        private readonly VendorSettings _vendorSettings;
        private readonly ShoppingCartSettings _shoppingCartSettings;
        private readonly LocalizationSettings _localizationSettings;
        private readonly CustomerSettings _customerSettings;
        private readonly CaptchaSettings _captchaSettings;
        private readonly SeoSettings _seoSettings;
        private readonly ICacheManager _cacheManager;
        private readonly ISettingService _settingService;
        private readonly IDownloadService _downloadService;
        private readonly IProductModelFactory _productModelFactory;
        private readonly IDateRangeService _dateRangeService;


        public BsQuickViewController(
            ICategoryService categoryService,
            IManufacturerService manufacturerService,
            IProductService productService,
            IVendorService vendorService,
            IProductTemplateService productTemplateService,
            IProductAttributeService productAttributeService,
            IWorkContext workContext,
            IStoreContext storeContext,
            ITaxService taxService,
            ICurrencyService currencyService,
            IPictureService pictureService,
            ILocalizationService localizationService,
            //change-3.7
            IMeasureService measureService,
            IPriceCalculationService priceCalculationService,
            IPriceFormatter priceFormatter,
            IWebHelper webHelper,
            ISpecificationAttributeService specificationAttributeService,
            IDateTimeHelper dateTimeHelper,
            IRecentlyViewedProductsService recentlyViewedProductsService,
            ICompareProductsService compareProductsService,
            IWorkflowMessageService workflowMessageService,
            IProductTagService productTagService,
            IOrderReportService orderReportService,
            IBackInStockSubscriptionService backInStockSubscriptionService,
            IAclService aclService,
            IStoreMappingService storeMappingService,
            IPermissionService permissionService,
            ICustomerActivityService customerActivityService,
            IProductAttributeParser productAttributeParser,
            IShippingService shippingService,
            MediaSettings mediaSettings,
            CatalogSettings catalogSettings,
            VendorSettings vendorSettings,
            ShoppingCartSettings shoppingCartSettings,
            LocalizationSettings localizationSettings,
            CustomerSettings customerSettings,
            CaptchaSettings captchaSettings,
            SeoSettings seoSettings,
            ICacheManager cacheManager,
            ISettingService settingService,
            IDownloadService downloadService, IProductModelFactory productModelFactory, IDateRangeService dateRangeService)
        {
            
            this._categoryService = categoryService;
            this._manufacturerService = manufacturerService;
            this._productService = productService;
            this._vendorService = vendorService;
            this._productTemplateService = productTemplateService;
            this._productAttributeService = productAttributeService;
            this._workContext = workContext;
            this._storeContext = storeContext;
            this._taxService = taxService;
            this._currencyService = currencyService;
            this._pictureService = pictureService;
            this._localizationService = localizationService;
            //change-3.7
            this._measureService = measureService;
            this._priceCalculationService = priceCalculationService;
            this._priceFormatter = priceFormatter;
            this._webHelper = webHelper;
            this._specificationAttributeService = specificationAttributeService;
            this._dateTimeHelper = dateTimeHelper;
            this._recentlyViewedProductsService = recentlyViewedProductsService;
            this._compareProductsService = compareProductsService;
            this._workflowMessageService = workflowMessageService;
            this._productTagService = productTagService;
            this._orderReportService = orderReportService;
            this._backInStockSubscriptionService = backInStockSubscriptionService;
            this._aclService = aclService;
            this._storeMappingService = storeMappingService;
            this._permissionService = permissionService;
            this._customerActivityService = customerActivityService;
            this._productAttributeParser = productAttributeParser;
            this._shippingService = shippingService;
            this._mediaSettings = mediaSettings;
            this._catalogSettings = catalogSettings;
            this._vendorSettings = vendorSettings;
            this._shoppingCartSettings = shoppingCartSettings;
            this._localizationSettings = localizationSettings;
            this._customerSettings = customerSettings;
            this._captchaSettings = captchaSettings;
            this._seoSettings = seoSettings;
            this._cacheManager = cacheManager;
            this._settingService = settingService;
            this._downloadService = downloadService;
            _productModelFactory = productModelFactory;
            _dateRangeService = dateRangeService;
        }



        #region common

    
        #endregion

        #region Non-Action
      

     
        #endregion

        #region Client Side Methods

        #region Add Button
        [HttpsRequirement(SslRequirement.No)]
        public ActionResult AddButton()
        {

            var settingsModel = new BsQuickViewSettingsModel();
            var quickViewsettings = _settingService.LoadSetting<QuickViewSettings>();
            settingsModel.ButtonContainerName = quickViewsettings.ButtonContainerName;
            settingsModel.EnableWidget = quickViewsettings.EnableWidget;
            settingsModel.ShowAlsoPurchased = quickViewsettings.ShowAlsoPurchased;
            settingsModel.ShowRelatedProducts = quickViewsettings.ShowRelatedProducts;
            settingsModel.EnableEnlargePicture = quickViewsettings.EnableEnlargePicture;


            return View("QuickViewButton", settingsModel);


        }

        #endregion

        #region Product details page

        [HttpsRequirement(SslRequirement.No)]
        public ActionResult ProductDetails(int productId, int updatecartitemid = 0)
        {
            var product = _productService.GetProductById(productId);
            if (product == null || product.Deleted)
                return NotFound(); 

            //Is published?
            //Check whether the current user has a "Manage catalog" permission
            //It allows him to preview a product before publishing
            if (!product.Published && !_permissionService.Authorize(StandardPermissionProvider.ManageProducts))
                return NotFound();

            //ACL (access control list)
            if (!_aclService.Authorize(product))
                return NotFound();

            //Store mapping
            if (!_storeMappingService.Authorize(product))
                return NotFound();

            //visible individually?
            if (!product.VisibleIndividually)
            {
                //is this one an associated products?
                var parentGroupedProduct = _productService.GetProductById(product.ParentGroupedProductId);
                if (parentGroupedProduct != null)
                {
                    product = parentGroupedProduct;
                }
                else
                {
                    return NotFound();
                }
            }

            //update existing shopping cart item?
            ShoppingCartItem updatecartitem = null;
            if (_shoppingCartSettings.AllowCartItemEditing && updatecartitemid > 0)
            {
                var cart = _workContext.CurrentCustomer.ShoppingCartItems
                    .Where(x => x.ShoppingCartType == ShoppingCartType.ShoppingCart)
                    .LimitPerStore(_storeContext.CurrentStore.Id)
                    .ToList();
                updatecartitem = cart.FirstOrDefault(x => x.Id == updatecartitemid);
                //not found?
                if (updatecartitem == null)
                {
                     return NotFound();
                   // return RedirectToRoute("Product", new { SeName = product.GetSeName() });
                }
                //is it this product?
                if (product.Id != updatecartitem.ProductId)
                {
                    return NotFound();
                    // return RedirectToRoute("Product", new { SeName = product.GetSeName() });
                }
            }


            //model
            var model = _productModelFactory.PrepareProductDetailsModel(product, updatecartitem, false);
            //template
            var productTemplateViewPath = _productModelFactory.PrepareProductTemplateViewPath(product);


            //save as recently viewed
            _recentlyViewedProductsService.AddProductToRecentlyViewedList(product.Id);

            //activity log
            _customerActivityService.InsertActivity("PublicStore.ViewProduct", _localizationService.GetResource("ActivityLog.PublicStore.ViewProduct"), product.Name);






            var bsQuickViewModel = new BsQuickViewModel();
            bsQuickViewModel.ProductDetailsModel = model;

            var settingsModel = new BsQuickViewSettingsModel();
            var quickViewsettings = _settingService.LoadSetting<QuickViewSettings>();
            settingsModel.ButtonContainerName = quickViewsettings.ButtonContainerName;
            settingsModel.EnableWidget = quickViewsettings.EnableWidget;
            settingsModel.ShowAlsoPurchased = quickViewsettings.ShowAlsoPurchased;
            settingsModel.ShowRelatedProducts = quickViewsettings.ShowRelatedProducts;
            settingsModel.EnableEnlargePicture = quickViewsettings.EnableEnlargePicture;
            bsQuickViewModel.BsQuickViewSettingsModel = settingsModel;






            /*return View(model.ProductTemplateViewPath, model);*/
            if (productTemplateViewPath.Equals("ProductTemplate.Simple"))
            {
               return Json(new
                {
                    html= this.RenderPartialViewToString("BsQuickView/QuickViewProductTemplate.Simple", bsQuickViewModel),
                });
               
                //return View("QuickViewProductTemplate.Simple", bsQuickViewModel);
            }
            else if (productTemplateViewPath.Equals("ProductTemplate.Grouped"))
            {
                return Json(new
                {
                    html = this.RenderPartialViewToString("BsQuickView/QuickViewProductTemplate.Grouped", bsQuickViewModel),
                });
               
                //return View("QuickViewProductTemplate.Grouped", bsQuickViewModel);
            }
            return new NullJsonResult();
        }

        
        public ActionResult RelatedProducts(int productId, int? productThumbPictureSize)
        {
            //load and cache report
            var productIds = _cacheManager.Get(string.Format(ModelCacheEventConsumer.PRODUCTS_RELATED_IDS_KEY, productId, _storeContext.CurrentStore.Id),
                () =>
                    _productService.GetRelatedProductsByProductId1(productId).Select(x => x.ProductId2).ToArray()
                    );

            //load products
            var products = _productService.GetProductsByIds(productIds);
            //ACL and store mapping
            products = products.Where(p => _aclService.Authorize(p) && _storeMappingService.Authorize(p)).ToList();

            if (products.Count == 0)
                return Content("");

            var model = _productModelFactory.PrepareProductOverviewModels(products).ToList();
            return PartialView("QuickViewRelatedProducts", model);
        }

        
        public ActionResult ProductsAlsoPurchased(int productId, int? productThumbPictureSize)
        {
            if (!_catalogSettings.ProductsAlsoPurchasedEnabled)
                return Content("");

            //load and cache report
            var productIds = _cacheManager.Get(string.Format(ModelCacheEventConsumer.PRODUCTS_ALSO_PURCHASED_IDS_KEY, productId, _storeContext.CurrentStore.Id),
                () =>
                    _orderReportService
                    .GetAlsoPurchasedProductsIds(_storeContext.CurrentStore.Id, productId, _catalogSettings.ProductsAlsoPurchasedNumber)
                    );

            //load products
            var products = _productService.GetProductsByIds(productIds);
            //ACL and store mapping
            products = products.Where(p => _aclService.Authorize(p) && _storeMappingService.Authorize(p)).ToList();

            if (products.Count == 0)
                return Content("");

            //prepare model
            var model = _productModelFactory.PrepareProductOverviewModels(products).ToList();

            return PartialView("QuickViewProductsAlsoPurchased", model);
        }

     
        public ActionResult CrossSellProducts(int? productThumbPictureSize)
        {
            var cart = _workContext.CurrentCustomer.ShoppingCartItems
                .Where(sci => sci.ShoppingCartType == ShoppingCartType.ShoppingCart)
                .LimitPerStore(_storeContext.CurrentStore.Id)
                .ToList();

            var products = _productService.GetCrosssellProductsByShoppingCart(cart, _shoppingCartSettings.CrossSellsNumber);
            //ACL and store mapping
            products = products.Where(p => _aclService.Authorize(p) && _storeMappingService.Authorize(p)).ToList();

            if (products.Count == 0)
                return Content("");


            //Cross-sell products are dispalyed on the shopping cart page.
            //We know that the entire shopping cart page is not refresh
            //even if "ShoppingCartSettings.DisplayCartAfterAddingProduct" setting  is enabled.
            //That's why we force page refresh (redirect) in this case
            var model = _productModelFactory.PrepareProductOverviewModels(products)
                .ToList();

            return PartialView(model);
        }

        #endregion

        #endregion

      
    }
}