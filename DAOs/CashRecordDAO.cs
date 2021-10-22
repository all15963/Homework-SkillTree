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

        public List<CashRecordFormViewModel> GetCashRecordsByDate(int? year, int? month)
        {
            MappingColumn();

            var result = new List<CashRecordFormViewModel>();
            const string sqlStatement = @"SELECT Categoryyy,Amounttt,Dateee,Remarkkk FROM AccountBook
                WHERE year(Dateee)=@year AND month(Dateee)=@month";

            using (var conn = new SqlConnection(this._AccountBookConnString))
            {
                result = conn.Query<CashRecordFormViewModel>(sqlStatement, new {
                    year = year,
                    month = month
                }).ToList();
            }
            return result;
        }

        /// <summary>
        /// 寫入一筆記帳紀錄
        /// </summary>
        /// <param name="cashRecord"></param>
        /// <returns></returns>
        public int AddCashRecord(CashRecordFormViewModel cashRecord)
        {
            int count = 0;
            const string sqlStatement = @"INSERT INTO AccountBook(Id,Categoryyy,Amounttt,Dateee,Remarkkk) VALUES (@id,@category,@amount,@date,@remark)";

            using (var conn = new SqlConnection(this._AccountBookConnString))
            {
                try
                {
                    count = conn.Execute(sqlStatement, new
                    {
                        id = Guid.NewGuid(),
                        category = cashRecord.Category,
                        amount = cashRecord.Money,
                        date = cashRecord.Date,
                        remark = cashRecord.Description
                    });
                    return count;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}