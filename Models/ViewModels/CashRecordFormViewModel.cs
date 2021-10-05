using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Homework_SkillTree.Models.ViewModels
{
    /// <summary>
    /// 記帳表單ViewModel
    /// </summary>
    public class CashRecordFormViewModel
    {
        [Display(Name = "#")]
        public int Id { get; set; }

        [Display(Name = "類別")]
        [Required(ErrorMessage = "請選擇{0}!")]
        public string Category { get; set; }

        [Display(Name = "金額")]
        [Required(ErrorMessage ="請填寫金額!")]
        [Range(1, Int32.MaxValue, ErrorMessage = "{0}必須為正整數!")]
        public int Money { get; set; }

        [Display(Name = "日期")]
        [Required(ErrorMessage = "請填寫日期!")]
        //[Range(typeof(DateTime), "1753/1/1", "2021/9/22", ErrorMessage = "{0}區間必須介於{1}到{2}之間!")]
        public DateTime Date { get; set; }

        [Display(Name = "備註")]
        [Required(ErrorMessage = "請填寫備註!")]
        [StringLength(100, ErrorMessage = "{0}不得超過{1}字!")]
        public string Description { get; set; }
    }
}