using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Dapper;
using Dapper.FluentColumnMapping;
using Homework_SkillTree.Models.ViewModels;

namespace Homework_SkillTree.DAOs
{
    public class CashRecordDAO
    {
        private string _AccountBookConnString { get; set; }

        public CashRecordDAO()
        {
            this._AccountBookConnString = WebConfigurationManager.ConnectionStrings["AccountBook"].ConnectionString; ;
        }

        /// <summary>
        /// 自定義欄位對應
        /// </summary>
        private void MappingColumn()
        {
            var columnMappings = new ColumnMappingCollection();

            columnMappings.RegisterType<CashRecordFormViewModel>()
                          .MapProperty(m => m.Category).ToColumn("Categoryyy")
                          .MapProperty(m => m.Money).ToColumn("Amounttt")
                          .MapProperty(m => m.Date).ToColumn("Dateee")
                          .MapProperty(m => m.Description).ToColumn("Remarkkk");

            columnMappings.RegisterWithDapper();
        }

        public List<CashRecordFormViewModel> GetCashRecords()
        {
            MappingColumn();

            var result = new List<CashRecordFormViewModel>();
            const string sqlStatement = "SELECT Categoryyy,Amounttt,Dateee,Remarkkk FROM AccountBook";

            using (var conn = new SqlConnection(this._AccountBookConnString))
            {
                result = conn.Query<CashRecordFormViewModel>(sqlStatement).ToList();
            }
            return result;
        }
    }
}