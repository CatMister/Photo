using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HuxingEntity.Site;
using HuxingModel;
using HuxingModel.Community;
using HuxingModel.Global;
using HuxingModel.Transaction;
using HuxingService.Community;
using HuxingService.Config;
using HuxingService.Login;
using HuxingService.Transaction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HuxingMvc.Contorller
{

    /// <summary>
    /// 社区
    /// </summary>
    [Authorize]
    public class CommunityController : MainController
    {

        private IPhotoService PhotoService { get; set; }
        private ITransactionService TransactionService { get; set; }

        private ILoginService LoginService { get; set; }

        private IConfigService ConfigService { get; set; }
        public CommunityController(IPhotoService photoService,
            ILoginService loginService,
            ITransactionService transactionService,
            IConfigService configService)
        {
            PhotoService = photoService;
            LoginService = loginService;
            TransactionService = transactionService;
            ConfigService = configService;
        }



        #region  单页面
        public IActionResult AddPhotoUrl()
        {
            return View();
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddNews()
        {
            return View();
        }

        public IActionResult HomePage()
        {
            return View();
        }


        public IActionResult Main()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult NewList(GetNewsModel input )
        {

            input = input ?? new GetNewsModel();
            return View(PhotoService.GetNewsList(UserId, input));
        }
        [AllowAnonymous]
        public IActionResult PhotoList(GetPhotoModel input)
        {
            input = input ?? new GetPhotoModel();
            return View(PhotoService.GetPhoto(UserId, input));
        }

        public IActionResult OutMain()
        {
            return View(PhotoService.OutMain(UserId, new GetPhotoModel()));
        }

        public IActionResult AddShellPhotoUrl()
        {


            return View();
        }

        public IActionResult AddSellAtlasUrl()
        {

            return View();
        }

        public IActionResult AddPhotoToSellAtlasUrl(long Id)
        {

            return View(Id);
        }
        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult UpdateUser()
        {

            return View(LoginService.GetUser(UserId));
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        public IActionResult AdmninPage()
        {
            return View();

        }
        #endregion

        #region  用户
        /// <summary>
        /// 获取个人简介
        /// </summary>
        /// <returns></returns>
        public IActionResult Selfintroduce()
        {
            return View(LoginService.GetUser(UserId));
        }

        /// <summary>
        /// 获取用户关注
        /// </summary>
        /// <returns></returns>
        public IActionResult GetUser()
        {
            return View(LoginService.GetUserLsit(UserId, true));
        }


        /// <summary>
        /// 获取用户关注
        /// </summary>
        /// <returns></returns>
        public IActionResult GetAddUser()
        {
            return View(LoginService.GetUserLsit(UserId, false));
        }


        /// <summary>
        /// 获取用户关注
        /// </summary>
        /// <returns></returns>
        public void UpdateUserEnable(long id, bool IsEnable)
        {
            LoginService.UpdateUserEnable(id, IsEnable);
            UpdateUrl();
        }

        /// <summary>
        /// 获取用户关注
        /// </summary>
        /// <returns></returns>
        public void UpdateUserAttention(long AttentionUserId)
        {
            LoginService.UpdateUserAttention(UserId, AttentionUserId, false);
        }
        #endregion

        #region  图片
        /// <summary>
        /// 添加图片
        /// </summary>
        /// <param name="file"></param>
        /// <param name="input"></param>
        public void AddPhoto(IFormFile file, PhotoModel input)
        {
            var url = $"{this.HttpContext.Request.Scheme}://{HttpContext.Request.Host}";
            PhotoService.AddPhoto(UserId, file, input, url);
            //CloseUrl();
            CloseLayUi();
        }


        /// <summary>
        /// 修改图片
        /// </summary>
        /// <param name="input"></param>
        public void UpdatePhoto(PhotoModel input)
        {
            PhotoService.UpdatePhoto(UserId, input);
        }

        /// <summary>
        /// 获取图片列表
        /// </summary>
        /// <param name="input"></param>
        public IActionResult GetPhoto(GetPhotoModel input)
        {
            return View(PhotoService.GetPhoto(UserId, input));
        }

        public IActionResult OutMain(GetPhotoModel input)
        {
            return View(PhotoService.OutMain(UserId, input));
        }

        /// <summary>
        /// 获取图片详情
        /// </summary>
        /// <param name="input"></param>
        public IActionResult GetPhotoDetail(GetPhotoModel input)
        {
            return View(PhotoService.GetPhotoDetail(UserId, input));
        }


        /// <summary>
        /// 获取图片详情
        /// </summary>
        /// <param name="input"></param>
        public void DeletePhoto(EntityDto<long> input)
        {
            PhotoService.DeletePhoto(UserId, input);
        }


        /// <summary>
        /// 点赞
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="input"></param>
        public void UpdateGoodPhoto([FromBody]UpdateGoodModel input)
        {
            PhotoService.UpdateGoodPhoto(UserId, input);
        }
        #endregion

        #region 动态
        /// <summary>
        /// 获取动态列表
        /// </summary>
        /// <param name="input"></param>
        public IActionResult GetDynamicList(GetDynamicModel input)
        {
            return View(PhotoService.GetDynamicList(UserId, input));
        }

        /// <summary>
        /// 添加动态
        /// </summary>
        /// <param name="input"></param>
        public IActionResult AddDynaimic(DynamicModel input)
        {
            PhotoService.AddDynaimic(UserId, input);
            return Redirect("GetDynamicList");
        }

        /// <summary>
        /// 删除动态
        /// </summary>
        /// <param name="input"></param>
        public void DeleteDynainic(EntityDto<long> input)
        {
            PhotoService.DeleteDynainic(UserId, input);
        }



        /// <summary>
        /// 点赞
        /// </summary>
        /// <param name="input"></param>
        public void UpdateGoodDynainic([FromBody]UpdateGoodModel input)
        {
            PhotoService.UpdateGoodDynainic(UserId, input);
        }
        #endregion

        #region 图文
        /// <summary>
        /// 获取图文列表
        /// </summary>
        /// <param name="input"></param>
        public IActionResult GetNewsList(GetNewsModel input)
        {
            return View(PhotoService.GetNewsList(UserId, input));
        }

        /// <summary>
        /// 删除图文
        /// </summary>
        /// <param name="input"></param>
        public void DeleteNews(EntityDto<long> input)
        {
            PhotoService.DeleteNews(UserId, input);
        }

        /// <summary>
        /// 添加图文
        /// </summary>
        /// <param name="input"></param>
        [HttpPost]
        public IActionResult AddNews(IFormFile file, NewsModel input)
        {
            var url = $"{this.HttpContext.Request.Scheme}://{HttpContext.Request.Host}";
            var item = ConfigService.Upload(file);
            input.Url = $"{url}/{item.Item1}";
            PhotoService.AddNews(UserId, input);
            return Redirect("GetNewsList");
        }


        /// <summary>
        /// 获取图文详情
        /// </summary>
        /// <param name="input"></param>
        public IActionResult GetNewsDetail(EntityDto<long> input)
        {
            return View(PhotoService.GetNewsDetail(UserId, input));
        }


        /// <summary>
        /// 点赞
        /// </summary>
        /// <param name="input"></param>
        public void UpdateGoodNews([FromBody]UpdateGoodModel input)
        {
            PhotoService.UpdateGoodNews(UserId, input);
        }

        #endregion

        #region   回复
        /// <summary>
        /// 添加回复
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="input"></param>
        public void AddReply(ReplyModel input)
        {
            PhotoService.AddReply(UserId, input);
            UpdateUrl();
        }
        #endregion

        #region 交易
        /// <summary>
        /// 获取交易图片列表
        /// </summary>
        /// <param name="input"></param>
        public IActionResult GetSellPhotoList(GetSellPhotoModel input)
        {
            return View(TransactionService.GetSellPhotoList(UserId, input));
        }

        /// <summary>
        /// 获取交易图片列表
        /// </summary>
        /// <param name="input"></param>
        public IActionResult GetSellPhotoListById(long id, bool isAtlasId)
        {
            return View(TransactionService.GetSellPhotoListById(id, isAtlasId));
        }

        /// <summary>
        /// 添加交易图片
        /// </summary>
        /// <param name="input"></param>
        public void AddSellPhoto(IFormFile file, SellPhotoModel input)
        {
            var url = $"{this.HttpContext.Request.Scheme}://{HttpContext.Request.Host}";
            TransactionService.AddSellPhoto(UserId, file, url, input);
            CloseLayUi();
        }


        /// <summary>
        /// 添加交易图片
        /// </summary>
        /// <param name="input"></param>
        public void AddSellPhotoList(List<IFormFile> goods_album, long Id)
        {
            var url = $"{this.HttpContext.Request.Scheme}://{HttpContext.Request.Host}";
            foreach (var item in goods_album)
            {
                TransactionService.AddSellPhoto(UserId, item, url, new SellPhotoModel() { AtlasId = Id });
            }
            CloseLayUi();

        }

        /// <summary>
        /// 删除交易图片
        /// </summary>
        /// <param name="input"></param>
        public void DeleteSellPhoto([FromBody]EntityDto<long> input)
        {
            TransactionService.DeleteSellPhoto(UserId, input);
        }

        /// <summary>
        /// 获取图集列表
        /// </summary>
        /// <param name="input"></param>
        public IActionResult GetSellAtlasList(GetSellAtlasModel input)
        {
            var result = TransactionService.GetSellAtlasList(UserId, input);

            return View(result);
        }


        /// <summary>
        /// 添加图集交易
        /// </summary>
        /// <param name="input"></param>
        public IActionResult AddSellAtlas(IFormFile file, SellAtlasModel input)
        {

            var url = $"{this.HttpContext.Request.Scheme}://{HttpContext.Request.Host}";
            var item = ConfigService.Upload(file);
            input.ShowUrl = $"{url}/{item.Item1}";
            var id = TransactionService.AddSellAtlas(UserId, input);

            return Redirect($"/Community/AddPhotoToSellAtlasUrl?Id={id}");


        }

        /// <summary>
        /// 删除图片交易信息
        /// </summary>
        /// <param name="input"></param>
        public void DeleteSellAtlas([FromBody]EntityDto<long> input)
        {
            TransactionService.DeleteSellAtlas(UserId, input);
        }


        /// <summary>
        /// 购买图片
        /// </summary>
        /// <param name="input"></param>
        public void BuyPhoto([FromBody]OrderEntity input)
        {
            TransactionService.BuyPhoto(UserId, input);
        }

        /// <summary>
        /// 买家更新订单状态
        /// </summary>
        /// <param name="input"></param>
        public void BuyerUpdateOrderStatus([FromBody]UpdateOrderStatusModel input)
        {
            TransactionService.BuyerUpdateOrderStatus(UserId, input);
        }


        /// <summary>
        /// 买家更新订单状态
        /// </summary>
        /// <param name="input"></param>
        public void SellerUpdateOrderStatus([FromBody]UpdateOrderStatusModel input)
        {
            TransactionService.SellerUpdateOrderStatus(UserId, input);
        }

        /// <summary>
        /// 管理员更新订单状态
        /// </summary>
        /// <param name="input"></param>
        public void AdminUpdateOrderStatus([FromBody]UpdateOrderStatusModel input)
        {
            TransactionService.AdminUpdateOrderStatus(UserId, input);
        }


        /// <summary>
        /// 获取图集列表
        /// </summary>
        /// <param name="input"></param>
        public IActionResult GetOrderList()
        {
            return View(TransactionService.GetOrder(UserId));
        }
        #endregion

    }
}