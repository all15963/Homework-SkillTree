using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Homework_SkillTree.Models.ViewModels
{
    /// <summary>
    /// 記帳表單ViewModel
    /// </summary>
    public class CashRecordFormViewModel
    {
        [Display(Name="類別")]
        public string category { get; set; }
        [Display(Name="金額")]
        public int money { get; set; }
        [Display(Name="日期")]
        public DateTime date { get; set; }
        [Display(Name="備註")]
        public string description { get; set; }
    }
}