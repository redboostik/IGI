using IGI_Web_953501_Smolyar.Middleware;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IGI_Web_953501_Smolyar.Extensions
{
    public static class AppExtensions
    {
        public static IApplicationBuilder UseFileLogging(this
        IApplicationBuilder app)
        => app.UseMiddleware<LogMiddleware>();
    }
}
