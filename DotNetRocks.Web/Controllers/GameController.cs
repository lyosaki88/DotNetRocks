using DotNetRocks.Models.GameModels;
using DotNetRocks.Web.ViewModels.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace DotNetRocks.Web.Controllers
{
    public class GameController : BaseController
    {
        // 登录游戏后的首页
        // GET: /Game/
        public ActionResult Index()
        {
            var user = UserManager.FindById(_currentUserId);
            if (user.Characters.Count < 1)
            {
                return View("CreateCharacter");
            }
            var character = user.Characters.FirstOrDefault();
            if (character == null)
            {
                return View("Error");
            }
            return View(character);
        }
        // 创建游戏角色
        // GET: /Game/CreateCharacter
        public ActionResult CreateCharacter()
        {
            return View();
        }
        // 创建游戏角色
        // POST: /Game/CreateCharacter
        [HttpPost]
        public ActionResult CreateCharacter(CreateCharacterViewModel model)
        {
            // TO DO 暂时只能注册一个角色
            var user = UserManager.FindById(_currentUserId);
            if (user.Characters.Count < 1)
            {
                if (Character.Create(user.Id, model.Name))
                {
                    return Redirect("Index");
                }
            }
            return View("Error");
        }

        public ActionResult Battle()
        {
            return PartialView();
        }
        public ActionResult Skill()
        {
            return PartialView();
        }
        public ActionResult Equipment()
        {
            return PartialView();
        }
    }
}