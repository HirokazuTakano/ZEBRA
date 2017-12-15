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
        private Report report;
        private string cusName;

        

        public ReportModify()
        {
            InitializeComponent();
        }



        public void getReport(Report repo, string cus)
        {
            report = repo;
            cusName = cus;

          
        }

        private void registButton_Click(object sender, EventArgs e)
        {
            

            int reportId = 0;
            string radioButton = "";
            DateTime dt = DateTime.Now;
            DateTime startDate = dt;
            DateTime endDate = dt;

            //レポートIDをもらいます
            reportId = report.ReportId;

            //ラジオボックスでチェックされたものを確認
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
            }else
        
            {
                radioButton = null;
            }



            CommonValidater validater = new CommonValidater(DateTime.Parse(fromDate.Text), fromHour.Text, fromMinute.Text, DateTime.Parse(toDate.Text), toHour.Text, toMinute.Text, customerId.Text, radioButton, reportText.Text);

            Boolean commonValidateCheck = validater.InputCheck();

            if (commonValidateCheck == true)
            {

                //入力されたfrom日付をデータ型に結合
                string str = fromDate.ToString() + "" + fromHour.Text + ":" + fromMinute.Text + ":" + "00";
                startDate = DateTime.Parse(str);


                //入力されたto日付をデータ型に結合
                string str2 = toDate.ToString() + "" + toHour.Text + ":" + toMinute.Text + ":" + "00";
                endDate = DateTime.Parse(str);

            }
            else
            {
                MessageBox.Show("入力間違いがあります");
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
      "SET UPDATE_DATE= @UPDATE_DATE, VISIT_STRAT_DATE= @VISIT_STRAT_DATE, " +
      "VISIT_END_DATE= @VISIT_END_DATE, VISIT_TYPE= @VISIT_TYPE, DETAILS = @DETAIL, " +
      "APPROVAL_STATUS = @APPROVAL_STATUS " + 
      "WHERE REPORT_ID = @REPORT_ID" ;

            // コネクションオブジェクトを使用して、SQLの発行準備
            SqlCommand command = new SqlCommand(sql, con);

                command.Parameters.Add(
                         new SqlParameter("@UPDATE_DATE", dt));
                command.Parameters.Add(
                        new SqlParameter("@VISIT_STRAT_DATE", startDate));
                command.Parameters.Add(
                       new SqlParameter("@VISIT_END_DATE", endDate));
                command.Parameters.Add(
                        new SqlParameter("@VISIT_TYPE", radioButton));
                command.Parameters.Add(
                      new SqlParameter("@DETAIL", reportText.Text));
                command.Parameters.Add(
                       new SqlParameter("@APPROVAL_STATUS", 1));
                command.Parameters.Add(
                        new SqlParameter("@REPORT_ID", reportId));






                // 更新を実行する
                int ret = command.ExecuteNonQuery();

            // 更新が成功したらmessage
            if (ret == 1)
            {
                    DialogResult result =  MessageBox.Show("更新が完了しました", "確認ダイアログ", MessageBoxButtons.OK);
                    
                    if(result == DialogResult.Yes)
                    {
                        NGList ngList = new NGList();
                        ngList.ShowDialog(this);
                        Debug.WriteLine("画面を表示後。"); // 子画面が閉じてから、実行される。
                    }
                    else
                    {
                        MessageBox.Show("error");
                    }
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

       

        private void ReportModify_Load(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            DateTime startdt = report.VisitStratDate;
            DateTime enddt = report.VisitEndDate;
            string visitType = report.Visittype;

            createDate.Text = dt.ToString();
            fromDate.Text = startdt.ToString();
            fromHour.Text = (startdt.Hour).ToString();
            fromMinute.Text = (startdt.Minute).ToString();
            toDate.Text = enddt.ToString();
            toHour.Text = (enddt.Hour).ToString();
            toMinute.Text = (enddt.Minute).ToString();
            customerId.Text = report.CusId;
            reportText.Text = report.Detaile;
            bossName.Text = report.BossSei + report.BossMei;

            //ラジオボックスでチェックされたものを確認
            if (visitType == "電話")
            {
                tell.Checked = true;
            }
            else if (visitType == "メール")
            {
                mail.Checked = true;
            }
            else if (visitType == "相手宅")
            {

                opponentHouse.Checked = true;
            }
            else if (visitType == "自社")
            {
                their.Checked = true;

            }
            else if (visitType == "その他")
            {
                another.Checked = true;

            }
            else

            {
                visitType = null;
            }





        }
    }
    
}
