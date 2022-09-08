using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MiniProject_Handphone.Service.Interface.Services;
using MiniProject_Handphone.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject_Handphone.Service
{
    public class ServiceDependencyProfile
    {
        public static void Register(IConfiguration configuration, IServiceCollection service)
        {
            service.AddScoped<IHandphoneService, HandphoneService>();
            service.AddScoped<IDbService, DbService>();
        }
    }
}
