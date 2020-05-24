using System;
using System.Collections.Generic;
using System.Text;

namespace HuxingModel.Transaction
{
    public class UpdateOrderStatusModel
    {
        public long Id { get; set; }



        public string OrderStatus { get; set; }

        public string BuyerDetail { get; set; }

        public string SellerDetail { get; set; }


        public bool IsConfirm { get; set; }

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
