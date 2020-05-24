using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuxingService.Config
{
    public interface IConfigService
    {

        Tuple<string, string> Upload(IFormFile file);
    }
}
