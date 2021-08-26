using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homework_SkillTree.Models
{
    /// <summary>
    /// 記帳歷史紀錄
    /// </summary>
    public class RecordModel
    {
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public int Money { get; set; }
    }
}