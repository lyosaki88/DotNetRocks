using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DotNetRocks.Web.Configurations
{
    public class WebSiteConfig : ConfigurationSection
    {

        /// <summary>
        /// 网站名称
        /// </summary>
        [ConfigurationProperty("name", DefaultValue = "", IsRequired = true)]
        public string Name
        {
            get
            {
                return (string)this["name"];
            }
            set
            {
                this["name"] = value;
            }
        }
        /// <summary>
        /// 版本
        /// </summary>
        [ConfigurationProperty("version", DefaultValue = "0.0.0", IsRequired = true)]
        public string Version
        {
            get
            {
                return (string)this["version"];
            }
            set
            {
                this["version"] = value;
            }
        }
        /// <summary>
        /// 验证码位数
        /// </summary>
        [ConfigurationProperty("chkCodeNumberOfChars", DefaultValue = "4", IsRequired = false)]
        public int ChkCodeNumberOfChars
        {
            get
            {
                return (int)this["chkCodeNumberOfChars"];
            }
            set
            {
                this["chkCodeNumberOfChars"] = value;
            }
        }
    }
}
