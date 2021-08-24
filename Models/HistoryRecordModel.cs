using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homework_SkillTree.Models
{
    /// <summary>
    /// 標題與歷史紀錄Model
    /// </summary>
    public class HistoryRecordModel
    {
        public string IdTitle { get; set; }
        public string MoneyTitle { get; set; }
        public string CategoryTitle { get; set; }
        public string DateTitle { get; set; }
        public List<RecordModel> Records { get; set; }
    }
}