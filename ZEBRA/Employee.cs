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

    }
}
