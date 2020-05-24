using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HuxingService.Config;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HuxingMvc.Contorller
{
    public class ConfigController : Controller
    {
        private IConfigService configService { get; set; }
        public ConfigController(IConfigService _configService)
        {
            configService = _configService;
        }




        [HttpPost]
        public ActionResult Upload(IFormFile file)
        {
            var url = $"{this.HttpContext.Request.Scheme}://{HttpContext.Request.Host}";
            try
            {
                var result = configService.Upload(file);
                return Json(new { uploaded = 1, url = $"{url}/{result.Item1}" });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    uploaded = 0,
                    error = new
                    {
                        message = ex.Message
                    }
                });
            }
        }



        [HttpPost]
        public ActionResult CkeditorUpload(IFormFile Upload)
        {
            var url = $"{this.HttpContext.Request.Scheme}://{HttpContext.Request.Host}";
            try
            {
                var result = configService.Upload(Upload);
                return Json(new { uploaded = 1, url = $"{url}/{result.Item1}" });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    uploaded = 0,
                    error = new
                    {
                        message = ex.Message
                    }
                });
            }
        }


        [HttpPost]
        public async Task<IActionResult> UploadImageAsync(IFormFile file)
        {
            
                if (file.Length > 0)
                {
                    var name = Path.GetFileName(file.FileName);
                    if (name != null)
                    {
                        using (var stream = new MemoryStream())
                        {
                            await file.CopyToAsync(stream);

                            // Add watermark
                            var watermarkedStream = new MemoryStream();
                            using (var img = Image.FromStream(stream))
                            {
                                using (var graphic = Graphics.FromImage(img))
                                {
                                    var font = new Font(FontFamily.GenericSansSerif, 20, FontStyle.Bold, GraphicsUnit.Pixel);
                                    var color = Color.FromArgb(128, 255, 255, 255);
                                    var brush = new SolidBrush(color);
                                    var point = new Point(img.Width - 120, img.Height - 30);

                                    graphic.DrawString("cnblogs.com/zaranet", font, brush, point);
                                    img.Save(watermarkedStream, ImageFormat.Png);
                                }
                                //img.Save(hostingEnv.WebRootPath + "/" + name);

                            }
                            return StatusCode(StatusCodes.Status200OK);
                        }
                    }
                }
                return BadRequest();
            
        }


    }
}