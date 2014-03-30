using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetRocks.Models.GameModels
{
    /// <summary>
    /// 游戏道具的基类
    /// </summary>
    public abstract class Item
    {
        /// <summary>
        /// 物品的ID
        /// </summary>
        [Key]
        public Guid Id { get; set; }
        /// <summary>
        /// 物品等级
        /// </summary>
        public int ItemLevel { get; set; }
        /// <summary>
        /// 物品名称
        /// </summary>
        public string Name { get; set; }
    }
    /// <summary>
    /// 装备
    /// </summary>
    public class Equipment : Item
    {

    }
    /// <summary>
    /// 武器类
    /// </summary>
    public class Weapon : Equipment
    {

    }
    /// <summary>
    /// 盔甲类
    /// </summary>
    public class Armor : Equipment
    {

    }
    /// <summary>
    /// 护身符，类似戴在脖子上的项链
    /// </summary>
    public class Amulet : Equipment
    {

    }
    /// <summary>
    /// 戒指类
    /// </summary>
    public class Ring : Equipment
    {

    }

}
