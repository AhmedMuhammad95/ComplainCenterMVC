﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NetworkComplainCenter.Models;

namespace NetworkComplainCenter.Controllers
{
    public class ComplainController : Controller
    {
        ComplainCenterEntities db = new ComplainCenterEntities();
        public ActionResult Index(int p = 0, int pageSize = 10, string keyword = "", string sortBy = "")
        {
            List<Complain> complains = null;
            var _total = 0;




            if (String.IsNullOrEmpty(keyword))
            {
                switch (sortBy)
                {
                    case "ResolvedDate":
                        complains = db.Complains.OrderBy(x => x.ResolvedDate).Skip(p * pageSize).Take(pageSize).ToList();
                        break;
                    case "Title":
                        complains = db.Complains.OrderBy(x => x.Title).Skip(p * pageSize).Take(pageSize).ToList();
                        break;
                    case "ComplainStatusId":
                        complains = db.Complains.OrderBy(x => x.StatusId).Skip(p * pageSize).Take(pageSize).ToList();
                        break;
                    default:
                        complains = db.Complains.OrderBy(x => x.Id).Skip(p * pageSize).Take(pageSize).ToList();
                        break;
                }
                _total = db.Complains.Count();
            }
            else
            {
                keyword = keyword.ToLower();

                switch (sortBy)
                {
                    case "ResolvedDate":
                        complains = db.Complains.Where(c => c.Title.ToLower().Contains(keyword))
                    .OrderBy(x => x.ResolvedDate).Skip(p * pageSize).Take(pageSize).ToList();
                        break;
                    case "Title":
                        complains = db.Complains.Where(c => c.Title.ToLower().Contains(keyword))
                     .OrderBy(x => x.Title).Skip(p * pageSize).Take(pageSize).ToList();
                        break;
                    case "ComplainStatusId":
                        complains = db.Complains.Where(c => c.Title.ToLower().Contains(keyword))
                    .OrderBy(x => x.StatusId).Skip(p * pageSize).Take(pageSize).ToList();
                        break;
                    default:
                        complains = db.Complains.Where(c => c.Title.ToLower().Contains(keyword))
                   .OrderBy(x => x.Id).Skip(p * pageSize).Take(pageSize).ToList();
                        break;
                }

                _total = db.Complains.Count(c => c.Title.ToLower().Contains(keyword));
            }

            ComplainResult result = new ComplainResult();
            result.Complains = complains;
            result.CurrentPage = p;
            result.PageSize = pageSize;
            result.TotalComplains = _total;

            return View(result);
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}
