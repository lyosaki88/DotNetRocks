using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetRocks.Models.GameModels
{
    /// <summary>
    /// 人物背包
    /// </summary>
    [Table("game_Packages")]
    public class Package
    {
        public Package()
        {
            this.PackageId = Guid.NewGuid();
            this.Capacity = 50;
        }
        public static Package Create(Guid characterId)
        {
            return new Package() { CharacterId = characterId };
        }
        /// <summary>
        ///  所属角色的ID
        /// </summary>
        [Key]
        public Guid PackageId { get; set; }
        public Guid CharacterId { get; set; }
        [ForeignKey("CharacterId")]
        public virtual Character Character { get; set; }
        /// <summary>
        /// 最大容量
        /// </summary>
        public int Capacity { get; set; }
        /// <summary>
        /// 包内道具
        /// </summary>
        public virtual IList<Item> Items { get; set; }
    }
}
