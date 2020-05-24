using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HuxingMvc.Config
{
    public class ExceptionFilter : IExceptionFilter
    {
        public object Respose { get; private set; }

        /// <summary>
        /// 发生异常时进入
        /// </summary>
        /// <param name="context"></param>
        public void OnException(ExceptionContext context)
        {

            Task.Run(async () =>
               {
                   context.HttpContext.Response.ContentType = "text/html;charset=utf-8";
                   var message = context.Exception.Message.Replace("'", "\"");
                   await context.HttpContext.Response.WriteAsync($"<script>alert('{message}');history.go(-1);</script>");
               }).Wait();

        }

        /// <summary>
        /// 异步发生异常时进入
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Task OnExceptionAsync(ExceptionContext context)
        {
            OnException(context);
            return Task.CompletedTask;
        }

    }

}
