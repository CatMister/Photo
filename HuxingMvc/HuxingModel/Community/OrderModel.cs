using HuxingModel.Transaction;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuxingModel.Community
{
    public class OrderModel
    {
        public long Id { get; set; }


        public long PhotoOrAtlasId { get; set; }


        public long OrdersType { get; set; }

        public long UserId { get; set; }


        public long SellerId { get; set; }

        public string OrderStatus { get; set; }

        public string OrderNumber { get; set; }


        public long Price { get; set; }


        public AbnormalModel Abnormal { get; set; }

        public bool IsSeller { get;set; }

    }

    public class AbnormalModel
    {
        public long OrderId { get; set; }

        public long BuyerId { get; set; }

        /// <summary>
        /// 买入方异议原因
        /// </summary>
        public string BuyerDetail { get; set; }

        /// <summary>
        /// 买家选择
        /// </summary>
        public string SellerAttitudeType { get; set; }


        public long SellerId { get; set; }


        /// <summary>
        /// 买家选择描述
        /// </summary>
        public string SellerDetail { get; set; }



        public long AdminId { get; set; }


        /// <summary>
        /// 管理员选择方式
        /// </summary>
        public string AdminAttitudeType { get; set; }


        /// <summary>
        /// 管理员调解描述
        /// </summary>
        public string AdminDetail { get; set; }
    }

}
