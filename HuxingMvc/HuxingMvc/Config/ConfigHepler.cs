using HuxingModel.Global;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HuxingMvc.Config
{
    public static class ConfigHepler
    {

        public static IServiceCollection RegisterConfig(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            DatabaseConfigModel.Photo = configuration.GetSection("DataBaseConfig:PhotoDb").Value;
            SystemConfigModel.FileExtensionList = configuration.GetSection("SystemConfig:FileExtension").Get<List<string>>() ?? new List<string>();
            SystemConfigModel.PhotoFileName = configuration.GetSection("SystemConfig:PhotoFileName").Value;
            return serviceCollection;
        }
    }
}
