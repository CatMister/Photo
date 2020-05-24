using HuxingEntity.BaseEntity;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuxingEntity.Site
{

    /// <summary>
    ///订单表
    /// </summary>
    [SugarTable("orders")]
    public class OrderEntity : BaseEntity<long>
    {

        public long PhotoOrAtlasId { get; set; }

        
        public long OrdersType { get; set; }

        public long UserId { get; set; }


        public long SellerId { get; set; }

        [SugarColumn(Length = 50,IsNullable =true)]
        public string OrderStatus { get; set; }

        [SugarColumn(Length = 50)]
        public string OrderNumber { get; set; }


        public long Price { get; set; }
    }
}
