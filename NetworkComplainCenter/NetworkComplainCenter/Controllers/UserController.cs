using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NetworkComplainCenter.Models;

namespace NetworkComplainCenter.Controllers
{
    public class UserController : Controller
    {

        ComplainCenterEntities db = new ComplainCenterEntities();
        public ActionResult Index(int p = 0, int pageSize = 10, string keyword = "", string sortBy = "")
        {
            List<User> users = null;
            var _total = 0;




            if (String.IsNullOrEmpty(keyword))
            {
                switch (sortBy)
                {
                    case "Name":
                        users = db.Users.OrderBy(x => x.Name).Skip(p * pageSize).Take(pageSize).ToList();
                        break;
                    case "Email":
                        users = db.Users.OrderBy(x => x.Email).Skip(p * pageSize).Take(pageSize).ToList();
                        break;
                    case "UserTypeId":
                        users = db.Users.OrderBy(x => x.UserTypeId).Skip(p * pageSize).Take(pageSize).ToList();
                        break;
                    default:
                        users = db.Users.OrderBy(x => x.Id).Skip(p * pageSize).Take(pageSize).ToList();
                        break;
                }
                _total = db.Users.Count();
            }
            else
            {
                keyword = keyword.ToLower();

                switch (sortBy)
                {
                    case "Name":
                        users = db.Users.Where(c => c.Name.ToLower().Contains(keyword))
                    .OrderBy(x => x.Name).Skip(p * pageSize).Take(pageSize).ToList();
                        break;
                    case "Email":
                        users = db.Users.Where(c => c.Name.ToLower().Contains(keyword))
                     .OrderBy(x => x.Email).Skip(p * pageSize).Take(pageSize).ToList();
                        break;
                    case "UserTypeId":
                        users = db.Users.Where(c => c.Name.ToLower().Contains(keyword))
                    .OrderBy(x => x.UserTypeId).Skip(p * pageSize).Take(pageSize).ToList();
                        break;
                    default:
                        users = db.Users.Where(c => c.Name.ToLower().Contains(keyword))
                   .OrderBy(x => x.Id).Skip(p * pageSize).Take(pageSize).ToList();
                        break;
                }

                _total = db.Users.Count(c => c.Name.ToLower().Contains(keyword));
            }

            UserResult result = new UserResult();
            result.Users = users;
            result.CurrentPage = p;
            result.PageSize = pageSize;
            result.TotalUsers = _total;

            return View(result);
        }
        public ActionResult Create()
        {
            return View();
        }
    }
}
