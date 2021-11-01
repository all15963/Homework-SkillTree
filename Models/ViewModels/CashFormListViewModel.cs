using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using X.PagedList;

namespace Homework_SkillTree.Models.ViewModels
{
    public class CashFormListViewModel
    {
        public CashRecordFormViewModel CashRecordForm { get; set; }
        public IPagedList<CashRecordFormViewModel> CashRecords { get; set; }
        public List<SelectListItem> SelectListItems { get; set; }

        public CashFormListViewModel()
        {
            SelectListItems = new List<SelectListItem>();
        }
    }
}