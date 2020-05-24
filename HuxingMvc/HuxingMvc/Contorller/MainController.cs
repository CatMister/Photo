using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HuxingMvc.Contorller
{


    public class MainController : Controller
    {

        public long UserId
        {
            get
            {
                if (HttpContext.User.Identity.IsAuthenticated)
                {
                    var userId = HttpContext.User.Claims.First().Value;
                    return Convert.ToInt64(userId);
                }
                else
                {
                    //todo： 添加需要跳转的异常
                    throw new Exception();

                }
            }
        }


        /// <summary>
        /// 刷线当前界面
        /// </summary>
        public void UpdateUrl()
        {
            Task.Run(async () =>
            {
                HttpContext.Response.ContentType = "text/html;charset=utf-8";
                await HttpContext.Response.WriteAsync($"<script>history.go(-1);</script>");
            }).Wait();
        }

        public void BackUrl()
        {

            Task.Run(async () =>
            {
                HttpContext.Response.ContentType = "text/html;charset=utf-8";
                await HttpContext.Response.WriteAsync($"<script>self.location=document.referrer;</script>");
            }).Wait();
         
        }

        /// <summary>
        /// 关闭当前界面
        /// </summary>
        public void CloseUrl()
        {
            Task.Run(async () =>
            {
                HttpContext.Response.ContentType = "text/html;charset=utf-8";
                await HttpContext.Response.WriteAsync("<script > window.opener = null; window.open('', '_self', ''); window.close();</script>");
            }).Wait();

        }

        public void CloseLayUi()
        {
            Task.Run(async () =>
            {
                HttpContext.Response.ContentType = "text/html;charset=utf-8";
                await HttpContext.Response.WriteAsync("<script > var index = parent.layer.getFrameIndex(window.name); parent.layer.close(index);</script>");
            }).Wait();


        }

    }
}