using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        [Required(ErrorMessage ="請填寫{0}!")]
        [Range(1, Int32.MaxValue, ErrorMessage = "{0}必須為正整數!")]
        public int Money { get; set; }

        [Display(Name = "日期")]
        [Required(ErrorMessage = "請填寫{0}!")]
        [Remote("DateValid", "Home")]
        public DateTime Date { get; set; }

        [Display(Name = "備註")]
        [Required(ErrorMessage = "請填寫備註!")]
        [StringLength(100, ErrorMessage = "{0}不得超過{1}字!")]
        public string Description { get; set; }
    }
}