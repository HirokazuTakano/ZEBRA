using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZEBRA
{
    public partial class NGList : Form
    {
        public NGList()
        {
            InitializeComponent();
        }

        private void NGList_Load(object sender, EventArgs e)
        {
            ////データベース接続します.
            //DbConnection db = new DbConnection();

            //db.dbConnect();

            //// 問い合わせのSQLを生成
            //string sql =
            //    "SELECT VEHICLE_ID, VEHICLE_NAME " +
            //      "FROM dbo.TM_VEHICLE " +
            //     "ORDER BY VEHICLE_ID ";

            //// コネクションオブジェクトを使用して、SQLの発行準備
            //SqlCommand command = new SqlCommand(sql, con);
        }
    }
}
