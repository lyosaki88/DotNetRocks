using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetRocks.Models.GameModels
{
    /// <summary>
    /// 技能基类
    /// </summary>
    public class Skill
    {
        /// <summary>
        /// 技能ID
        /// </summary>
        [Key]
        public Guid SkillId { get; set; }
        /// <summary>
        /// 技能名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 技能描述
        /// </summary>
        public string Description { get; set; }
    }
}
