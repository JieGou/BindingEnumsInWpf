using System;
using System.ComponentModel;
using System.Reflection;

namespace Utilities.BindingEnums
{
    /// <summary>
    /// 枚举的描述转换
    /// </summary>
    public class EnumDescriptionTypeConverter : EnumConverter
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="type"></param>
        public EnumDescriptionTypeConverter(Type type) : base(type)
        {
        }

        /// <summary>
        /// 转换
        /// </summary>
        /// <param name="context"></param>
        /// <param name="culture"></param>
        /// <param name="value"></param>
        /// <param name="destinationType"></param>
        /// <returns></returns>
        public override object ConvertTo(
            ITypeDescriptorContext context,
            System.Globalization.CultureInfo culture,
            object value,
            Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                if (value != null)
                {
                    FieldInfo fi = value.GetType().GetField(value.ToString());
                    if (fi != null)
                    {
                        var attributes = (DescriptionAttribute[])fi
                            .GetCustomAttributes(typeof(DescriptionAttribute), false);

                        return ((attributes.Length > 0) && (!String.IsNullOrEmpty(attributes[0].Description)))
                            ? attributes[0].Description
                            : value.ToString();
                    }
                }

                return string.Empty;
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}