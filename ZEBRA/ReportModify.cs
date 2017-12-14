using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZEBRA
{
    public partial class ReportModify : Form
    {
       

        public ReportModify()
        {
            InitializeComponent();
        }

        private void registButton_Click(object sender, EventArgs e)
        {
            string radioButton = "";
            DateTime dt = DateTime.Now;

            if (tell.Checked == true)
            {
                radioButton = "電話";
            }
            else if (mail.Checked == true)
            {
                radioButton = "メール";
            }
            else if (opponentHouse.Checked == true)
            {
                radioButton = "相手宅";
            }
            else if (their.Checked == true)
            {
                radioButton = "自社";
            }
            else if (another.Checked == true)
            {
                radioButton = "その他";
            }
           


            // 接続用のクラス
            SqlConnection con = new SqlConnection();

            // DBへの接続文字列。
            con.ConnectionString = "data source=localhost\\SQLEXPRESS;" + // 接続先のDBサーバーを指定
                                   "initial catalog=testdb;" +            // 接続先のDBを指定
                                   "user id=sa;" +                        // ユーザー
                                   "password=p@ssw0rd;" +                 // パスワード
                                   "Connect Timeout=60;";

            try
            {
                con.Open(); // DBに接続

                string sql =
      "UPDATE dbo.TM_DAILY_REPORT " +
      "SET UPDATE_DATE= @UPDATE_DATE, VISIT_STRAT_DATE= @VISIT_STRAT_DATE, VISIT_END_DATE= @VISIT_END_DATE, VISIT_TYPE= @VISIT_TYPE, DETAILS = @DETAIL. CUS_ID= @CUS_ID, APPROVAL_STATUS = @APPROVAL_STATUS " + 
      "WHERE REPORT_ID = @REPORT_ID" ;

            // コネクションオブジェクトを使用して、SQLの発行準備
            SqlCommand command = new SqlCommand(sql, con);

                command.Parameters.Add(
                         new SqlParameter("@UPDATE_DATE", dt));
                command.Parameters.Add(
                        new SqlParameter("@VISIT_STRAT_DATE", fromDate.Text));
                command.Parameters.Add(
                       new SqlParameter("@VISIT_END_DATE", customer.Text));
                command.Parameters.Add(
                        new SqlParameter("@VISIT_TYPE", radioButton));
                command.Parameters.Add(
                      new SqlParameter("@DETAIL", reportText.Text));
                command.Parameters.Add(
                        new SqlParameter("@CUS_ID", customer.Text));
                command.Parameters.Add(
                       new SqlParameter("@APPROVAL_STATUS", 1));
                command.Parameters.Add(
                        new SqlParameter("@REPORT_ID", 1));






                // 更新を実行する
                int ret = command.ExecuteNonQuery();

            // 更新が成功したらmessage
            if (ret == 1)
            {
                    MessageBox.Show("更新が完了しました");
            }
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }


        }




    }
    
}
