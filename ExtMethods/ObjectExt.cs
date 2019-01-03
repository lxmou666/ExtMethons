using System;

namespace ExtMethods
{
    public static class ObjectExt
    {
        /// <summary>
        /// 类型是否为默认值
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsDefaultValue(this object obj)
        {
            if (obj==null)
            {
                return true;
            }
            var defaultValue = DefaultForType(obj.GetType());
            if (defaultValue==null)
            {
                return defaultValue == obj;
            }
            return defaultValue.Equals(obj);
        }
        /// <summary>
        /// 获取类型的默认值
        /// </summary>
        /// <param name="targetType"></param>
        /// <returns></returns>
        private static object DefaultForType(Type targetType)
        {
            return targetType.IsValueType ? Activator.CreateInstance(targetType) : null;
        }
    }
}
