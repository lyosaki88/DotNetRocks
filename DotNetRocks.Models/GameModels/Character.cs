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
    /// 人物角色
    /// </summary>
    [Table("game_Characters")]
    public class Character
    {
        public Character()
        {

        }
        private Character(string userId, string name)
            : this()
        {
            this.CharacterId = Guid.NewGuid();
            this.Level = 1;
            this.Gold = 0;
            this.CurrentExp = 0;
            this.NextExp = 100;
            this.CurrentHP = 100;
            this.MaxHP = 100;
            this.Strength = 10;
            this.Dexterity = 10;
            this.Vitality = 10;
            this.Skills = new List<Skill>();
            this.SkillCapacity = 4;
            this.UserId = userId;
            this.Name = name;
        }
        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="userId">账号ID</param>
        /// <param name="name">角色名称</param>
        /// <returns></returns>
        public static bool Create(string userId, string name)
        {
            using (var _db = ApplicationDbContext.Create())
            {
                var user = _db.Users.FirstOrDefault(x => x.Id == userId);
                if (user != null && user.Characters.Count < user.CharacterCapacity)
                {
                    var character = new Character(userId, name);
                    character.Package = Package.Create(character.CharacterId);
                    _db.Characters.Add(character);
                    _db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        /// <summary>
        /// 角色ID
        /// </summary>
        [Key]
        public Guid CharacterId { get; set; }
        /// <summary>
        /// 账号ID
        /// </summary>
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 角色等级
        /// </summary>
        public int Level { get; set; }
        /// <summary>
        /// 当前经验
        /// </summary>
        public int CurrentExp { get; set; }
        /// <summary>
        /// 升级所需剩余经验
        /// </summary>
        public int NextExp { get; set; }
        /// <summary>
        /// MAX血量
        /// </summary>
        public int MaxHP { get; set; }
        /// <summary>
        /// 当前血量
        /// </summary>
        public int CurrentHP { get; set; }
        /// <summary>
        /// 力量属性，影响基本攻击力
        /// </summary>
        public int Strength { get; set; }
        /// <summary>
        /// 敏捷，影响出手顺序和攻击次数
        /// </summary>
        public int Dexterity { get; set; }
        /// <summary>
        /// 体力，影响防御和MAX，HP
        /// </summary>
        public int Vitality { get; set; }
        /// <summary>
        /// 金钱
        /// </summary>
        public int Gold { get; set; }
        /// <summary>
        /// 角色背包
        /// </summary>
        public virtual Package Package { get; set; }
        /// <summary>
        /// 技能数量上限
        /// </summary>
        public int SkillCapacity { get; set; }
        /// <summary>
        /// 人物的所有技能
        /// </summary>
        public virtual List<Skill> Skills { get; set; }
    }
}
