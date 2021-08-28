using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Homework_SkillTree.Models;
using Homework_SkillTree.Models.ViewModels;

namespace Homework_SkillTree.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // 下拉選單選項
            string[] categoryArray = new string[] { "支出", "收入" };
            List<SelectListItem> selectListItems = new List<SelectListItem>()
            {
                new SelectListItem {Text = "請選擇", Value = "", Selected = true}
            };
            foreach (string category in categoryArray)
            {
                selectListItems.Add(new SelectListItem { Text = category });
            }
            ViewData["category_option"] = selectListItems;

            // 製作假資料list
            List<CashRecordFormViewModel> cashRecords = new List<CashRecordFormViewModel>();
            for (int i = 1; i <= 100; i++)
            {
                CashRecordFormViewModel record = new CashRecordFormViewModel();
                record.Money = i * 100 - 50;
                record.Category = categoryArray[(i % 2)];
                record.Date = DateTime.Now.AddDays(-i);
                cashRecords.Add(record);
            }
            ViewData["cash_records"] = cashRecords;

            return View();
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