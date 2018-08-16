using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nop.Core.Infrastructure;
using Nop.Plugin.BrainStation.QuickView.ViewEngines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.BrainStation.QuickView.Infrastructure
{
   
        public class NopStartup : INopStartup
        {

            public void ConfigureServices(IServiceCollection services, IConfigurationRoot configuration)
            {
                services.Configure<RazorViewEngineOptions>(options =>
                {
                    options.ViewLocationExpanders.Add(new CustomViewEngine());
                });
            }

            public void Configure(IApplicationBuilder application)
            {
            }

            public int Order
            {
                get { return 1001; } //add after nopcommerce is done
            }

        }
    
}
