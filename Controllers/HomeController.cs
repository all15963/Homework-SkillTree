﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Homework_SkillTree.Models;

namespace Homework_SkillTree.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string[] categoryArray = new string[] { "支出", "收入" };
            List<HistoryRecord> records = new List<HistoryRecord>();
            for (int i = 1; i <= 100; i++)
            {
                HistoryRecord record = new HistoryRecord();
                record.Money = i * 100 - 50;
                record.Category = categoryArray[(i % 2)];
                record.Date = DateTime.Now.AddDays(-i).ToString("yyyy-MM-dd");
                records.Add(record);
            }
            return View(records);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}