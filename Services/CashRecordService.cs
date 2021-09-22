﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Homework_SkillTree.DAOs;
using Homework_SkillTree.Models.ViewModels;

namespace Homework_SkillTree.Services
{
    public class CashRecordService
    {
        private readonly CashRecordDAO _cashRecordDAO;

        public CashRecordService()
        {
            this._cashRecordDAO = new CashRecordDAO();
        }

        /// <summary>
        /// 取得所有的記帳紀錄
        /// </summary>
        /// <returns></returns>
        public List<CashRecordFormViewModel> GetAccountBooks()
        {
            List<CashRecordFormViewModel> cashRecords = _cashRecordDAO.GetCashRecords();
            return cashRecords;
        }

        /// <summary>
        /// 寫入一筆記帳紀錄
        /// </summary>
        /// <param name="cashRecord"></param>
        /// <returns></returns>
        public int AddCashRecord(CashRecordFormViewModel cashRecord)
        {
            try
            {
                return _cashRecordDAO.AddCashRecord(cashRecord);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 製作假資料list
        /// </summary>
        /// <param name="cashRecords"></param>
        /// <param name="categoryArray"></param>
        /// <returns></returns>
        public List<CashRecordFormViewModel> CreateFakeRecords(List<CashRecordFormViewModel> cashRecords, string[] categoryArray)
        {
            Random random = new Random();
            for (int i = 1; i <= 100; i++)
            {
                CashRecordFormViewModel record = new CashRecordFormViewModel
                {
                    Money = random.Next(minValue: 100, maxValue: 10000),
                    Category = categoryArray[(random.Next(maxValue: 100) % 2)],
                    Date = DateTime.Now.AddDays(-i)
                };
                cashRecords.Add(record);
            }
            return cashRecords;
        }
    }
}