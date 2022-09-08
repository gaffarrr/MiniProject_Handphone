using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MiniProject_Handphone.Data.Interface.Repositories;
using MiniProject_Handphone.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject_Handphone.Data
{
    public class DataDependencyProfile
    {
        public static void Register(IConfiguration configuration, IServiceCollection service)
        {
            service.AddScoped<IHandphoneRepository, HandphoneRepository>();
        }
    }
}
