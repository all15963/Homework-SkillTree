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
        [Required(ErrorMessage = "請選擇類別!")]
        public string Category { get; set; }

        [Display(Name = "金額")]
        [Required(ErrorMessage ="請填寫金額!")]
        public int Money { get; set; }

        [Display(Name = "日期")]
        [Required(ErrorMessage = "請填寫日期!")]
        public DateTime Date { get; set; }

        [Display(Name = "備註")]
        [Required(ErrorMessage = "請填寫備註!")]
        public string Description { get; set; }
    }
}