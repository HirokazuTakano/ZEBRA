﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZEBRA
{
    /// <summary>
    /// 顧客クラス 高野
    /// </summary>
    public class Customer
    {
        private string cusId; // 顧客ID
        private string companyName; // 会社名
        private string cusName; // 担当者名
        private string cusTel; // 顧客電話番号 

       
       public Customer(string cusId, string companyName, string cusName, string cusTel)
        {
            this.cusId = cusId;
            this.companyName = companyName;
            this.cusName = cusName;
            this.cusTel = cusTel;
        }

    }
}
