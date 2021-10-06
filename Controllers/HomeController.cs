using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        [Route("skilltree")]
        public ActionResult Index()
        {
            // 下拉選單選項
            string[] categoryArray = new string[] { "支出", "收入" };
            List<SelectListItem> selectListItems = new List<SelectListItem>()
            {
                new SelectListItem {Text = "請選擇", Value = "", Selected = true}
            };

            int index = 0;
            foreach (string category in categoryArray)
            {
                selectListItems.Add(new SelectListItem { Text = category, Value = index.ToString() });
                index++;
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

        /// <summary>
        /// 記帳表單action
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index([Bind(Prefix = "CashRecordForm")] CashRecordFormViewModel form)
        {
            if (Request.IsAjaxRequest() && ModelState.IsValid)
            {
                try
                {
                    _cashRecordService.AddCashRecord(form);
                    ViewData["recordCount"] = _cashRecordService.GetAccountBooks().Count;
                    return PartialView("_CashFormAjax", form);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                    throw;
                }
            }

            return RedirectToAction("Index");
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

        /// <summary>
        /// 給Remote驗證日期是否大於今天
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public ActionResult DateValid([Bind(Prefix = "CashRecordForm.Date")] DateTime date)
        {
            if (date > DateTime.Today)
            {
                return Json($"日期不能比今天日期 {DateTime.Today.ToString("yyyy/MM/dd")} 大!", JsonRequestBehavior.AllowGet);
            }
            
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}