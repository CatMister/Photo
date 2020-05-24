using HuxingEntity;
using HuxingModel.Global;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace HuxingService.Config.Impl
{
    public class ConfigService : PhotoClient, IConfigService
    {

        public ConfigService()
        {

        }

        public Tuple<string, string> Upload(IFormFile file)
        {
            CheckEmpty(file, "文件不能为空");
            var fileName = Path.GetFileName(file.FileName);
            var ext = Path.GetExtension(file.FileName);
            if (string.IsNullOrEmpty(ext) || !SystemConfigModel.FileExtensionList.Contains(ext.ToLower()))
            {
                throw new Exception("上传文件格式有误");
            }
            var ms = file.OpenReadStream();
            return UploadByStream(ms, ext);

        }

        private Tuple<string, string> UploadByStream(Stream ms, string ext)
        {
            var fileName = $"{Guid.NewGuid().ToString("N")}{ext}";
            var ss = DateTime.Now.ToShortTimeString();
            var date = DateTime.Now.ToLongDateString();
            var time = DateTime.Now.ToShortTimeString();
            var directoryName = $"{SystemConfigModel.PhotoFileName}\\{DateTime.Now.ToString("yyyyMM")}";
            var folderName = string.Format(@"{0}{1}", AppDomain.CurrentDomain.BaseDirectory, directoryName);
            if (!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
            }
            var funpath = $"{folderName}\\{fileName}";
            ms.Seek(0, SeekOrigin.Begin);
            byte[] byteList = new byte[ms.Length];
            ms.Read(byteList, 0, (int)ms.Length);
            ms.Close();
            using (FileStream file = File.Create(funpath))
            {
                file.Write(byteList, 0, byteList.Length);
                file.Close();
            }
            return new Tuple<string, string>($"{SystemConfigModel.PhotoFileName}/{DateTime.Now.ToString("yyyyMM")}/{fileName}", funpath);

        }
    }
}
