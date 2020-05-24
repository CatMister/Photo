using HuxingEntity.Site;
using HuxingModel;
using HuxingModel.Community;
using HuxingModel.Enum;
using HuxingModel.Global;
using HuxingModel.Transaction;
using HuxingService.Config;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace HuxingService.Transaction.Impl
{
    class TransactionService : PhotoClient, ITransactionService
    {
        private IConfigService ConfigService { get; set; }
        public TransactionService(IConfigService configService)
        {
            ConfigService = configService;
        }


        #region  图片交易
        /// <summary>
        /// 获取交易图片列表
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public PageReturnModel<SellPhotoModel> GetSellPhotoList(long userId, GetSellPhotoModel input)
        {
            var result = new List<SellPhotoModel>();
            var total = 0;
            var entityList = DbContext.Queryable<SellPhotoEntity>().
                Where(c => c.AtlasId == 0)
                .WhereIF(input.IsMyself, c => c.UserId == userId)
                .WhereIF(input.UserId != 0, c => c.UserId == input.UserId)
                .Select(c => new SellPhotoModel()
                {
                    Id = c.Id,
                    UserId = c.UserId,
                    AtlasId = c.AtlasId,
                    IsEnable = c.IsEnable,
                    SiteUrl = c.SiteUrl,
                    Url = c.Url,
                    ShowUrl = c.ShowUrl,
                    ShowSiteUrl = c.ShowSiteUrl,
                    Price = c.Price,
                    Titile = c.Titile,
                    Detail = c.Detail,
                    IsShow = c.IsShow
                }).ToPageList(input.PageIndex, input.PageSize, ref total);
            return new PageReturnModel<SellPhotoModel>()
            {
                TotalNum = total,
                DateList = entityList
            };
        }


        /// <summary>
        /// 获取交易图片列表
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<SellPhotoModel> GetSellPhotoListById(long id, bool IsAtlasId)
        {
            var result = new List<SellPhotoModel>();
            var total = 0;
            var entityList = DbContext.Queryable<SellPhotoEntity>()
                .WhereIF(IsAtlasId, c => c.AtlasId == id)
                .WhereIF(!IsAtlasId, c => c.Id == id)
                .Select(c => new SellPhotoModel()
                {
                    Id = c.Id,
                    UserId = c.UserId,
                    AtlasId = c.AtlasId,
                    IsEnable = c.IsEnable,
                    SiteUrl = c.SiteUrl,
                    Url = c.Url,
                    ShowUrl = c.ShowUrl,
                    ShowSiteUrl = c.ShowSiteUrl,
                    Price = c.Price,
                    Titile = c.Titile,
                    Detail = c.Detail,
                    IsShow = c.IsShow
                }).ToList();
            return entityList;

        }

        /// <summary>
        /// 添加交易图片
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="input"></param>
        public void AddSellPhoto(long userId, IFormFile file, string url, SellPhotoModel input)
        {
            var cunrrentTime = DateTime.Now;
            //CheckEmpty(input, "请输入售卖的图片信息");

            if (input.AtlasId != 0)
            {
                var entity = DbContext.Queryable<SellAtlasEntity>().First(c => c.Id == input.AtlasId);
                CheckEmpty(entity, "图集信息有误");
                CheckExit(entity.IsEnable, "已经上架的图集无法再次上传图片");
            }
            else
            {
                CheckEmpty(input.Price, "价格不能为空");
                CheckEmpty(input.Titile, "标题不能为空");
            }
            var originalPhoto = ConfigService.Upload(file);
            var originalUrl = $"{url}/{originalPhoto.Item1}";
            DbContext.Insertable(new SellPhotoEntity()
            {
                UserId = userId,
                Titile = input.Titile,
                Price = input.Price,
                Detail = input.Detail,
                IsShow = input.IsShow,
                AtlasId = input.AtlasId,
                IsSell = input.IsEnable,
                IsEnable = input.IsEnable,
                Url = originalUrl,
                SiteUrl = originalPhoto.Item2,
                ShowUrl = originalUrl,
                ShowSiteUrl = originalPhoto.Item2,
                CreateTime = cunrrentTime,
                UpdateTime = cunrrentTime
            }).ExecuteCommand();
        }

        /// <summary>
        /// 删除交易图片
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="input"></param>
        public void DeleteSellPhoto(long userId, EntityDto<long> input)
        {
            var cunrrentTime = DateTime.Now;
            DbContext.Deleteable<SellPhotoEntity>().Where(c => c.Id == input.Id).ExecuteCommand();
        }
        #endregion

        #region  图集
        /// <summary>
        /// 获取图集列表
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public PageReturnModel<SellAtlasModel> GetSellAtlasList(long userId, GetSellAtlasModel input)
        {
            var result = new List<SellAtlasModel>();
            var total = 0;
            var entityList = DbContext.Queryable<SellAtlasEntity>()
                .WhereIF(input.IsMyself, c => c.UserId == userId)
                .WhereIF(input.UserId != 0, c => c.UserId == input.UserId)
                .Select(c => new SellAtlasModel()
                {
                    Id = c.Id,
                    UserId = c.UserId,
                    IsEnable = c.IsEnable,
                    SiteUrl = c.SiteUrl,
                    ShowUrl = c.ShowUrl,
                    ShowSiteUrl = c.ShowSiteUrl,
                    Price = c.Price,
                    Titile = c.Titile,
                    Detail = c.Detail
                }).ToPageList(input.PageIndex, input.PageSize, ref total);
            return new PageReturnModel<SellAtlasModel>() { TotalNum = total, DateList = entityList };
        }


        /// <summary>
        /// 添加图片交易
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="input"></param>
        public long AddSellAtlas(long userId, SellAtlasModel input)
        {
            var cunrrentTime = DateTime.Now;
            CheckEmpty(input, "请输入售卖的图片信息");
            CheckEmpty(input.Price, "价格不能为空");
            CheckEmpty(input.Titile, "标题不能为空");
            return DbContext.Insertable(new SellAtlasEntity()
            {
                UserId = userId,
                Detail = input.Detail,
                IsSell = input.IsEnable,
                IsEnable = input.IsEnable,
                ShowUrl = input.ShowUrl,
                Price = input.Price,
                Titile = input.Titile,
                CreateTime = cunrrentTime,
                UpdateTime = cunrrentTime
            }).ExecuteReturnBigIdentity();
        }



        /// <summary>
        /// 删除图片交易信息
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="input"></param>
        public void DeleteSellAtlas(long userId, EntityDto<long> input)
        {
            var cunrrentTime = DateTime.Now;
            DbContext.Deleteable<SellAtlasEntity>().Where(c => c.Id == input.Id).ExecuteCommand();
        }



        public Tuple<string, string> AddImageSignPic(Stream ms, string watermarkFilename, int watermarkStatus, int quality, int watermarkTransparency)
        {
            //if (!File.Exists(imgPath))
            //    return;
            //byte[] _ImageBytes = File.ReadAllBytes(imgPath);
            Image img = Image.FromStream(ms);


            //if (!File.Exists(watermarkFilename))
            //    return;
            Graphics g = Graphics.FromImage(img);
            //设置高质量插值法
            //g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            //设置高质量,低速度呈现平滑程度
            //g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            Image watermark = new Bitmap(watermarkFilename);

            //if (watermark.Height >= img.Height || watermark.Width >= img.Width)
            //    return;

            ImageAttributes imageAttributes = new ImageAttributes();
            ColorMap colorMap = new ColorMap();

            colorMap.OldColor = Color.FromArgb(255, 0, 255, 0);
            colorMap.NewColor = Color.FromArgb(0, 0, 0, 0);
            ColorMap[] remapTable = { colorMap };

            imageAttributes.SetRemapTable(remapTable, ColorAdjustType.Bitmap);

            float transparency = 0.5F;
            if (watermarkTransparency >= 1 && watermarkTransparency <= 10)
                transparency = (watermarkTransparency / 10.0F);


            float[][] colorMatrixElements = {
                                                new float[] {1.0f,  0.0f,  0.0f,  0.0f, 0.0f},
                                                new float[] {0.0f,  1.0f,  0.0f,  0.0f, 0.0f},
                                                new float[] {0.0f,  0.0f,  1.0f,  0.0f, 0.0f},
                                                new float[] {0.0f,  0.0f,  0.0f,  transparency, 0.0f},
                                                new float[] {0.0f,  0.0f,  0.0f,  0.0f, 1.0f}
                                            };

            ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);

            imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            int xpos = 0;
            int ypos = 0;

            switch (watermarkStatus)
            {
                case 1:
                    xpos = (int)(img.Width * (float).01);
                    ypos = (int)(img.Height * (float).01);
                    break;
                case 2:
                    xpos = (int)((img.Width * (float).50) - (watermark.Width / 2));
                    ypos = (int)(img.Height * (float).01);
                    break;
                case 3:
                    xpos = (int)((img.Width * (float).99) - (watermark.Width));
                    ypos = (int)(img.Height * (float).01);
                    break;
                case 4:
                    xpos = (int)(img.Width * (float).01);
                    ypos = (int)((img.Height * (float).50) - (watermark.Height / 2));
                    break;
                case 5:
                    xpos = (int)((img.Width * (float).50) - (watermark.Width / 2));
                    ypos = (int)((img.Height * (float).50) - (watermark.Height / 2));
                    break;
                case 6:
                    xpos = (int)((img.Width * (float).99) - (watermark.Width));
                    ypos = (int)((img.Height * (float).50) - (watermark.Height / 2));
                    break;
                case 7:
                    xpos = (int)(img.Width * (float).01);
                    ypos = (int)((img.Height * (float).99) - watermark.Height);
                    break;
                case 8:
                    xpos = (int)((img.Width * (float).50) - (watermark.Width / 2));
                    ypos = (int)((img.Height * (float).99) - watermark.Height);
                    break;
                case 9:
                    xpos = (int)((img.Width * (float).99) - (watermark.Width));
                    ypos = (int)((img.Height * (float).99) - watermark.Height);
                    break;
            }

            g.DrawImage(watermark, new Rectangle(xpos, ypos, watermark.Width, watermark.Height), 0, 0, watermark.Width, watermark.Height, GraphicsUnit.Pixel, imageAttributes);

            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            ImageCodecInfo ici = null;
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.MimeType.IndexOf("jpeg") > -1)
                    ici = codec;
            }
            var fileName = $"{Guid.NewGuid().ToString("N")}.jpeg";
            var directoryName = $"{SystemConfigModel.PhotoFileName}\\{DateTime.Now.ToString("yyyyMM")}";
            var folderName = string.Format(@"{0}{1}", AppDomain.CurrentDomain.BaseDirectory, directoryName);
            if (!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
            }
            var funpath = $"{folderName}\\{fileName}";

            EncoderParameters encoderParams = new EncoderParameters();
            long[] qualityParam = new long[1];
            if (quality < 0 || quality > 100)
                quality = 80;
            qualityParam[0] = quality;
            EncoderParameter encoderParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qualityParam);
            encoderParams.Param[0] = encoderParam;

            if (ici != null)
                img.Save(funpath, ici, encoderParams);
            else
                img.Save(funpath);

            g.Dispose();
            img.Dispose();
            watermark.Dispose();
            imageAttributes.Dispose();
            return new Tuple<string, string>($"{SystemConfigModel.PhotoFileName}/{DateTime.Now.ToString("yyyyMM")}/{fileName}", funpath);
        }
        #endregion

        #region  购买
        /// <summary>
        /// 购买图片
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="input"></param>
        public void BuyPhoto(long userId, OrderEntity input)
        {
            var entity = DbContext.Context.Queryable<UserEntity>().First(c => c.Id == userId);

            entity.Integral = entity.Integral - input.Price;
            if (entity.Integral < 0)
            {
                throw new Exception("您的积分不足");
            }
            Random rand = new Random();
            int shu2 = rand.Next(1000, 9999);
            input.OrderNumber = DateTime.Now.ToString("yyyyMMddHHmmss") + shu2;
            input.UserId = userId;
            input.CreateTime = DateTime.Now;
            input.UpdateTime = DateTime.Now;
            DbContext.Insertable(input).ExecuteCommand();
            DbContext.Updateable(entity).ExecuteCommand();

        }




        /// <summary>
        /// 更新订单状态
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="input"></param>
        public void BuyerUpdateOrderStatus(long userId, UpdateOrderStatusModel input)
        {
            var entity = DbContext.Context.Queryable<OrderEntity>().First(c => c.Id == input.Id);
            if (input.OrderStatus == OrderStatusOfType.Confirm.ToString())
            {
                var userEntity = DbContext.Context.Queryable<UserEntity>().First(c => c.Id == input.Id);
                userEntity.Integral = userEntity.Integral + entity.Price;
                DbContext.Context.Updateable(userEntity);
            }
            else if (input.OrderStatus == OrderStatusOfType.Refuse.ToString())
            {
                var abmormalEnity = new AbnormalEntity()
                {
                    OrderId = entity.Id,
                    BuyerId = entity.UserId,
                    BuyerDetail = input.BuyerDetail,
                    SellerId = entity.SellerId,
                    CreateTime = entity.CreateTime,
                    UpdateTime = entity.UpdateTime
                };
                DbContext.Context.Insertable(abmormalEnity).ExecuteCommand();
            }
        }
        /// <summary>
        /// 买方更新订单状态
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="input"></param>
        public void SellerUpdateOrderStatus(long userId, UpdateOrderStatusModel input)
        {
            var entity = DbContext.Context.Queryable<AbnormalEntity>().First(c => c.Id == input.Id);

            if (input.OrderStatus == OrderStatusOfType.Confirm.ToString())
            {
                var orderEntity = DbContext.Context.Queryable<OrderEntity>().First(c => c.Id == entity.OrderId);
                var userEntity = DbContext.Context.Queryable<UserEntity>().First(c => c.Id == entity.BuyerId);
                userEntity.Integral = userEntity.Integral + orderEntity.Price;

                entity.SellerAttitudeType = input.OrderStatus;
                DbContext.Context.Updateable(userEntity).ExecuteCommand();
                DbContext.Context.Updateable(entity).ExecuteCommand();
            }
            else if (input.OrderStatus == OrderStatusOfType.Refuse.ToString())
            {
                entity.AdminDetail = input.AdminDetail;
                DbContext.Context.Updateable(entity).ExecuteCommand();
            }
        }

        /// <summary>
        /// 买方更新订单状态
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="input"></param>
        public void AdminUpdateOrderStatus(long userId, UpdateOrderStatusModel input)
        {
            var entity = DbContext.Context.Queryable<AbnormalEntity>().First(c => c.Id == input.Id);
            entity.AdminAttitudeType = input.AdminAttitudeType;
            entity.AdminDetail = input.AdminDetail;
            DbContext.Context.Updateable(entity).ExecuteCommand();
            var orderEntity = DbContext.Context.Queryable<OrderEntity>().First(c => c.Id == entity.OrderId);
            if (input.AdminAttitudeType == AdminAttitudeOfType.Buyer.ToString())
            {
                var userEntity = DbContext.Context.Queryable<UserEntity>().First(c => c.Id == entity.BuyerId);
                userEntity.Integral = userEntity.Integral + orderEntity.Id;
                DbContext.Context.Updateable(userEntity).ExecuteCommand();
            }
            else
            {
                var userEntity = DbContext.Context.Queryable<UserEntity>().First(c => c.Id == entity.SellerId);
                userEntity.Integral = userEntity.Integral + orderEntity.Id;
                DbContext.Context.Updateable(userEntity).ExecuteCommand();
            }
        }
        /// <summary>
        /// 获订单列表
        /// </summary>
        /// <param name="userId"></param>
        public List<OrderModel> GetOrder(long userId)
        {
            var result = new List<OrderModel>();
            var IdList = DbContext.Queryable<SellAtlasEntity>().Where(c => c.UserId == userId).Select(c => c.Id).ToList();
            var IdsList = DbContext.Queryable<SellAtlasEntity>().Where(c => c.UserId == userId).Select(c => c.Id).ToList();
            if (IdsList != null && IdsList.Count > 0)
            {
                IdList.AddRange(IdsList);
            }
            var entityList = DbContext.Union(
                 DbContext.Queryable<OrderEntity>().Where(c => c.UserId == userId),
                 DbContext.Queryable<OrderEntity>().Where(c => IdList.Contains(c.UserId))
                 ).ToList();

            var entityIdList = entityList.Select(c => c.Id).ToList();
            var abnormalEntityList = DbContext.Context.Queryable<AbnormalEntity>().Where(c => entityIdList.Contains(c.OrderId)).ToList();
            foreach (var item in entityList)
            {
                var model = new OrderModel()
                {
                    Id = item.Id,
                    PhotoOrAtlasId = item.PhotoOrAtlasId,
                    OrdersType = item.OrdersType,
                    UserId = -item.UserId,
                    SellerId = item.SellerId,
                    OrderStatus = item.OrderStatus,
                    OrderNumber = item.OrderNumber,
                    Price = item.Price,
                    IsSeller = item.UserId == userId
                };
                var abormal = abnormalEntityList.FirstOrDefault(c => c.OrderId == item.Id);
                if (abormal != null)
                {
                    model.Abnormal = new AbnormalModel()
                    {
                        OrderId = abormal.OrderId,

                        BuyerId = abormal.BuyerId,
                        BuyerDetail = abormal.BuyerDetail,
                        SellerAttitudeType = abormal.SellerAttitudeType,
                        SellerId = abormal.SellerId,
                        SellerDetail = abormal.SellerDetail,
                        AdminId = abormal.AdminId,
                        AdminAttitudeType = abormal.AdminAttitudeType,
                        AdminDetail = abormal.AdminDetail,

                    };
                }
                result.Add(model);
            }
            return result;
        }



        #endregion
    }
}
