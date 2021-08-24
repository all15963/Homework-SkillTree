using System;
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
            return View();
        }

        public ActionResult ShowRecords()
        {
            HistoryRecordModel historyRecordModel = new HistoryRecordModel();
            string[] titleArray = new string[] { "#", "類別", "日期", "金額" };
            historyRecordModel.IdTitle = titleArray[0];
            historyRecordModel.CategoryTitle = titleArray[1];
            historyRecordModel.DateTitle = titleArray[2];
            historyRecordModel.MoneyTitle = titleArray[3];
            historyRecordModel.Records = new List<RecordModel>();

            string[] categoryArray = new string[] { "支出", "收入" };
            for (int i = 1; i <= 100; i++)
            {
                RecordModel record = new RecordModel();
                record.Money = i * 100 - 50;
                record.Category = categoryArray[(i % 2)];
                record.Date = DateTime.Now.AddDays(-i).ToString("yyyy-MM-dd");
                historyRecordModel.Records.Add(record);
            }

            return View(historyRecordModel);
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