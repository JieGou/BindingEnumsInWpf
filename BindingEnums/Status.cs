using BindingEnums.Resources;
using System.ComponentModel;

namespace BindingEnums
{
    /// <summary>
    /// 状态类型
    /// </summary>
    /// <remarks>
    /// 通过设置特性达到两个目的
    /// 1.枚举转换为列表
    /// 2.获取枚举每项的描述内容，即转换为更有意义的友好的名称
    /// </remarks>
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum Status
    {
        [Description("This is horrible")]
        Horrible,

        [Description("This is bad")]
        Bad,

        [Description("This is so so")]
        SoSo,

        [LocalizedDescription("Good", typeof(EnumResources))]
        Good,

        [LocalizedDescription("Better", typeof(EnumResources))]
        Better,

        [LocalizedDescription("Best", typeof(EnumResources))]
        Best
    }
}