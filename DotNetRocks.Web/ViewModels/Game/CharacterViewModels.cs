using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DotNetRocks.Web.ViewModels.Game
{
    public class CreateCharacterViewModel
    {
        /// <summary>
        /// 角色名称，2~6位
        /// </summary>
        [Required]
        [StringLength(maximumLength: 6, MinimumLength = 2, ErrorMessage = "角色名称必须是2-6位")]
        [Display(Name = "角色名称")]
        public string Name { get; set; }
    }
}