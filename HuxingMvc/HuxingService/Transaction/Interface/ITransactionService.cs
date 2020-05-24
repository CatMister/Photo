using HuxingEntity.Site;
using HuxingModel;
using HuxingModel.Community;
using HuxingModel.Transaction;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuxingService.Transaction
{
    public interface ITransactionService
    {

        /// <summary>
        /// 获取交易图片列表
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        PageReturnModel<SellPhotoModel> GetSellPhotoList(long userId, GetSellPhotoModel input);


        List<SellPhotoModel> GetSellPhotoListById(long id, bool IsAtlasId);
        /// <summary>
        /// 添加交易图片
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="input"></param>
        void AddSellPhoto(long userId, IFormFile file, string url, SellPhotoModel input);


        /// <summary>
        /// 删除交易图片
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="input"></param>
        void DeleteSellPhoto(long userId, EntityDto<long> input);



        /// <summary>
        /// 获取图集列表
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        PageReturnModel<SellAtlasModel> GetSellAtlasList(long userId, GetSellAtlasModel input);


        /// <summary>
        /// 添加图片交易
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="input"></param>
        long AddSellAtlas(long userId, SellAtlasModel input);


        /// <summary>
        /// 删除图片交易信息
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="input"></param>
        void DeleteSellAtlas(long userId, EntityDto<long> input);


        /// <summary>
        /// 购买图片
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="input"></param>
        void BuyPhoto(long userId, OrderEntity input);


        /// <summary>
        /// 买家更新订单状态
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="input"></param>
        void BuyerUpdateOrderStatus(long userId, UpdateOrderStatusModel input);

        /// <summary>
        /// 卖家更新订单状态
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="input"></param>
        void SellerUpdateOrderStatus(long userId, UpdateOrderStatusModel input);


        /// <summary>
        /// 管理员更新订单状态
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="input"></param>
        void AdminUpdateOrderStatus(long userId, UpdateOrderStatusModel input);


        /// <summary>
        /// 获订单列表
        /// </summary>
        /// <param name="userId"></param>
        List<OrderModel> GetOrder(long userId);
    }
}
