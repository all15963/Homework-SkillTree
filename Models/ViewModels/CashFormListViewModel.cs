using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homework_SkillTree.Models.ViewModels
{
    public class CashFormListViewModel
    {
        public CashRecordFormViewModel CashRecordForm { get; set; }
        public List<CashRecordFormViewModel> CashRecords { get; set; }
    }
}