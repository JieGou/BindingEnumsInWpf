using System;
using System.Windows.Markup;

namespace Utilities.BindingEnums
{
    /// <summary>
    /// 绑定枚举扩展类
    /// </summary>
    public class EnumBindingSourceExtension : MarkupExtension
    {
        /// <summary>
        /// 枚举的Type类型
        /// </summary>
        private Type _enumType;

        /// <summary>
        /// 枚举的Type类型
        /// </summary>
        public Type EnumType
        {
            get { return this._enumType; }
            set
            {
                if (value != this._enumType)
                {
                    if (null != value)
                    {
                        Type enumType = Nullable.GetUnderlyingType(value) ?? value;

                        if (!enumType.IsEnum)
                            throw new ArgumentException("Type must be for an Enum.");
                    }

                    this._enumType = value;
                }
            }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        public EnumBindingSourceExtension()
        {
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="enumType"></param>
        public EnumBindingSourceExtension(Type enumType)
        {
            this.EnumType = enumType;
        }

        /// <summary>
        /// 枚举到绑定值提供者
        /// </summary>
        /// <remarks>
        /// 把枚举转换为列表返回
        /// </remarks>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (null == this._enumType)
                throw new InvalidOperationException("The EnumType must be specified.");

            Type actualEnumType = Nullable.GetUnderlyingType(this._enumType) ?? this._enumType;
            Array enumValues = Enum.GetValues(actualEnumType);

            if (actualEnumType == this._enumType)
                return enumValues;

            Array tempArray = Array.CreateInstance(actualEnumType, enumValues.Length + 1);
            enumValues.CopyTo(tempArray, 1);
            return tempArray;
        }
    }
}