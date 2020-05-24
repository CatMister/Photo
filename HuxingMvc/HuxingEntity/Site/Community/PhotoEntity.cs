
using HuxingEntity.BaseEntity;
using SqlSugar;
namespace HuxingEntity.Site
{


    /// <summary>
    /// 图片
    /// </summary>
    [SugarTable("photo")]
    public class PhotoEntity : BaseEntity<long>
    {

        /// <summary>
        /// 地址
        /// </summary>
        [SugarColumn(Length = int.MaxValue)]
        public string Url { get; set; }

        [SugarColumn(Length = 100)]
        public string Name { get; set; }

        [SugarColumn(Length = int.MaxValue)]
        public string SiteUrl { get; set; }

        [SugarColumn(Length = int.MaxValue, IsNullable = true)]
        public string Detail { get; set; }

        public long UserId { get; set; }


        public long GoodNum { get; set; }

        public long ViewingNum { get; set; }
    }
}
