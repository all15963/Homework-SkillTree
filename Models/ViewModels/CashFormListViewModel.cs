using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework_SkillTree.Models.ViewModels
{
    public class CashFormListViewModel
    {
        public CashRecordFormViewModel CashRecordForm { get; set; }
        public List<CashRecordFormViewModel> CashRecords { get; set; }
        public List<SelectListItem> SelectListItems { get; set; }

        public CashFormListViewModel()
        {
            CashRecords = new List<CashRecordFormViewModel>();
            SelectListItems = new List<SelectListItem>();
        }
    }
}