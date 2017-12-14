using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZEBRA
{
    /// <summary>
    /// 従業員クラス　高野
    /// </summary>
    public class Employee
    {
        private string empId; // 従業員ID
        private string password; // パスワード
        private string empName; // 従業員名(DBは姓と名は別項目なのでSQｌ文で結合させること)
        private string bossId; // 上司ID
        private string bossName; // 上司氏名
        private string empSecId; // 部署ID
        private string empSecName; // 部署名
        private string empTel; // 従業員電話番号
        

        /// <summary>
        /// 引数付きコンストラクタ
        /// </summary>
        /// <param name="empId"></param>
        /// <param name="password"></param>
        /// <param name="empName"></param>
        /// <param name="bossId"></param>
        /// <param name="bossName"></param>
        /// <param name="empSecId"></param>
        /// <param name="empSecName"></param>
        /// <param name="empTel"></param>
        public Employee(string empId, string password, string empName,
            string bossId, string bossName, string empSecId, string empSecName, string empTel)
        {
            this.EmpId = empId;
            this.Password = password;
            this.EmpName = empName;
            this.BossId = bossId;
            this.BossName = bossName;
            this.EmpSecId = empSecId;
            this.EmpSecName = empSecName;
            this.EmpTel = empTel;
        }

        public string EmpId
        {
            get
            {
                return empId;
            }

            set
            {
                empId = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public string EmpName
        {
            get
            {
                return empName;
            }

            set
            {
                empName = value;
            }
        }

        public string BossId
        {
            get
            {
                return bossId;
            }

            set
            {
                bossId = value;
            }
        }

        public string BossName
        {
            get
            {
                return bossName;
            }

            set
            {
                bossName = value;
            }
        }

        public string EmpSecId
        {
            get
            {
                return empSecId;
            }

            set
            {
                empSecId = value;
            }
        }

        public string EmpSecName
        {
            get
            {
                return empSecName;
            }

            set
            {
                empSecName = value;
            }
        }

        public string EmpTel
        {
            get
            {
                return empTel;
            }

            set
            {
                empTel = value;
            }
        }
    }
}
