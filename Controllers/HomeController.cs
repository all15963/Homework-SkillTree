using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Homework_SkillTree.Models;
using Homework_SkillTree.Models.ViewModels;
using Homework_SkillTree.Services;

namespace Homework_SkillTree.Controllers
{
    public class HomeController : Controller
    {
        private readonly CashRecordService _cashRecordService;

        public HomeController()
        {
            this._cashRecordService = new CashRecordService();
        }

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

            List<CashRecordFormViewModel> cashRecords = new List<CashRecordFormViewModel>();
            cashRecords = _cashRecordService.GetAccountBooks();

            // 將資料、下拉選單選項都包入ViewModel中
            CashFormListViewModel cashFormListViewModel = new CashFormListViewModel
            {
                CashRecords = cashRecords,
                SelectListItems = selectListItems
            };

            return View(cashFormListViewModel);
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