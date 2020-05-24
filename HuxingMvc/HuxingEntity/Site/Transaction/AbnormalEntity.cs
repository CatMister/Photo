using HuxingEntity.BaseEntity;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuxingEntity.Site
{
    /// <summary>
    /// 交易异议表
    /// </summary>
    [SugarTable("abnormal")]
    public class AbnormalEntity : BaseEntity<long>
    {
        public long OrderId { get; set; }

        public long BuyerId { get; set; }

        /// <summary>
        /// 买入方异议原因
        /// </summary>
        [SugarColumn(Length = 1000, IsNullable = true)]
        public string BuyerDetail { get; set; }

        /// <summary>
        /// 买家选择
        /// </summary>
        [SugarColumn(Length = 50, IsNullable = true)]
        public string SellerAttitudeType { get; set; }


        public long SellerId { get; set; }


        /// <summary>
        /// 买家选择描述
        /// </summary>
        [SugarColumn(Length = 1000, IsNullable = true)]
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
