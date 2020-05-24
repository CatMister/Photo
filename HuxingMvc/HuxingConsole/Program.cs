using SqlSugar;
using System;
using System.Linq;
using System.Reflection;

namespace HuxingConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            UpdatePhoto();
            Console.ReadKey();
        }

        public static SqlSugarClient GetPhotoClient()
        {
            return  new SqlSugarClient(new ConnectionConfig
            {
                ConnectionString = "data source=localhost;database=photo; uid=root;pwd=123456;",
                DbType = DbType.MySql,
                IsAutoCloseConnection = true,
                IsShardSameThread = true,
                InitKeyType = InitKeyType.Attribute
            });
        }

        public static void UpdatePhoto()
        {
            var db = GetPhotoClient();
            var types = Assembly.Load("HuxingEntity").GetTypes().Where(c => c.Namespace== "HuxingEntity.Site").ToArray();
            db.CodeFirst.SetStringDefaultLength(100).InitTables(types);
            Console.WriteLine("更新基础库");
        }
    }
}
