using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Homework_SkillTree.Models.ViewModels
{
    /// <summary>
    /// 記帳表單ViewModel
    /// </summary>
    public class CashRecordFormViewModel
    {
        [DisplayName("類別")]
        public string category { get; set; }
        [DisplayName("金額")]
        public int money { get; set; }
        [DisplayName("日期")]
        public string date { get; set; }
        [DisplayName("備註")]
        public string description { get; set; }
    }
}