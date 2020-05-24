using System;
using System.Collections.Generic;
using System.Text;

namespace HuxingService
{
    public class BaseService
    {


        /// <summary>
        /// 检查字符串是否为空
        /// </summary>
        /// <param name="value"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public string CheckEmpty(string value, string message)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception(message);
            }
            return value.Trim();
        }

        /// <summary>
        /// 检查对象是否为空
        /// </summary>
        /// <param name="value"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public void CheckEmpty<T>(T value, string message) where T : class
        {
            if (value == null)
            {
                throw new Exception(message);
            }
        }

        /// <summary>
        /// 检查整型是否为空
        /// </summary>
        /// <param name="value"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public void CheckEmpty(long? value, string message)
        {
            if (value == null || value == 0)
            {
                throw new Exception(message);
            }
        }


        /// <summary>
        /// 检查整型是否为空
        /// </summary>
        /// <param name="value"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public void CheckEmpty(long value, string message)
        {
            if ( value == 0)
            {
                throw new Exception(message);
            }
        }

        /// <summary>
        /// 检查是否为真
        /// </summary>
        /// <param name="value"></param>
        /// <param name="message"></param>
        public void CheckExit(bool value, string message)
        {
            if (value)
            {
                throw new Exception(message);
            }
        }


    }
}
