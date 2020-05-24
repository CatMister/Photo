using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuxingTool
{

    /// <summary>
    /// 常规操作
    /// </summary>
    public static class OperatingHelp
    {

        /// <summary>
        /// 检查值为空
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <param name="Message"></param>
        public static void CheckEntity<T>(this T input, string message) where T : struct
        {
            if (input.Equals(0))
            {
                throw new Exception(message);
            }
        }


        /// <summary>
        /// 检查引用类型的为空
        /// </summary>
        /// <param name="input"></param>
        /// <param name="message"></param>
        public static void CheckEntity(this object input, string message)
        {
            if (input == null)
            {
                throw new Exception(message);
            }
        }
        /// <summary>
        ///检查字符串类型是否为空
        /// </summary>
        /// <param name="input"></param>
        /// <param name="message"></param>
        public static string CheckEntity(this string input, string message)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new Exception(message);
            }
            return input.Trim();
        }

        /// <summary>
        ///   实体类转json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToJsonString<T>(this T input)
        {
            if (input != null)
            {
                if (typeof(T) is string)
                {

                }
                return JsonConvert.ToString(input);
            }
            return null;
        }

    }
}
