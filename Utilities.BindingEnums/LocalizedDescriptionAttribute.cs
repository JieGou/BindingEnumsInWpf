using System;
using System.ComponentModel;
using System.Resources;

namespace Utilities.BindingEnums
{
    /// <summary>
    /// 本地化的描述
    /// </summary>
    public class LocalizedDescriptionAttribute : DescriptionAttribute
    {
        /// <summary>
        /// 资源管理器
        /// </summary>
        private ResourceManager _resourceManager;

        /// <summary>
        /// 资源的名字
        /// </summary>
        private string _resourceKey;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="resourceKey">资源的名字</param>
        /// <param name="resourceType">资源的类型 可理解为项目的资源文件名称</param>
        public LocalizedDescriptionAttribute(string resourceKey, Type resourceType)
        {
            _resourceManager = new ResourceManager(resourceType);
            _resourceKey = resourceKey;
        }

        /// <summary>
        /// 描述
        /// </summary>
        /// <remarks>
        /// 可以直接给描述内容
        /// 也可以通过资源来给
        /// </remarks>
        public override string Description
        {
            get
            {
                string description = _resourceManager.GetString(_resourceKey);
                return string.IsNullOrWhiteSpace(description)
                    ? string.Format("[[{0}]]", _resourceKey)
                    : description;
            }
        }
    }
}