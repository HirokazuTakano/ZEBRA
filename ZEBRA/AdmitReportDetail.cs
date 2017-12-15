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
    /// <summary>
    /// 承認詳細クラス　沢谷
    /// 
    /// </summary>
    public partial class AdmitReportDetail : Form
    {
        public AdmitReportDetail()
        {
            InitializeComponent();
        }


        //親画面からアクセスできるプロパティを作る----
        private String _reportId;
        private String _date;
        private String _visit;
        private String _visitTo;
        private String _type;
        private String _content;
        private String _company;

        public String Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
            }
        }

        public string Visit
        {
            get
            {
                return _visit;
            }

            set
            {
                _visit = value;
            }
        }

        public string VisitTo
        {
            get
            {
                return _visitTo;
            }

            set
            {
                _visitTo = value;
            }
        }

        public string Type
        {
            get
            {
                return _type;
            }

            set
            {
                _type = value;
            }
        }

        public string Content
        {
            get
            {
                return _content;
            }

            set
            {
                _content = value;
            }
        }

        public string ReportId
        {
            get
            {
                return _reportId;
            }

            set
            {
                _reportId = value;
            }
        }

        public string Company
        {
            get
            {
                return _company;
            }

            set
            {
                _company = value;
            }
        }

        private void AdmitReportDetail_Load(object sender, EventArgs e)
        {
            this.reportId.Text = _reportId;
            this.fillDate.Text = _date;
            this.visitDate.Text = _visit;
            this.visitTo.Text = _visitTo;
            this.visitType.Text = _type;
            this.content.Text = _content;
            this.visitTo.Text = _company;

        }

        //承認する場合
        private void admitButton_Click(object sender, EventArgs e)
        {


            // 接続用のクラス
            SqlConnection con = new SqlConnection();

            // DBへの接続文字列。
            con.ConnectionString = "data source=localhost\\SQLEXPRESS;" + // 接続先のDBサーバーを指定
                                   "initial catalog=zebradb;" +            // 接続先のDBを指定
                                   "user id=sa;" +                        // ユーザー
                                   "password=p@ssw0rd;" +                 // パスワード
                                   "Connect Timeout=60;";

            try
            {
                con.Open(); // DBに接続

                // 問い合わせのSQLを生成
                string sql =
                    "UPDATE TM_DAILY_REPORT " +
                    
                    "SET BOSS_COMMENT = @BOSS_COMMENT, APPROVAL_STATUS = 3 " +
                    "WHERE REPORT_ID = @REPORT_ID;";

                // コネクションオブジェクトを使用して、SQLの発行準備
                SqlCommand command = new SqlCommand(sql, con);

                //// SQL文を実行。approvalStatus
                //SqlDataReader reader = command.ExecuteReader();

                string bosscomment = bossComments.Text;
                // パラメタに値を設定
                command.Parameters.Add(new SqlParameter("@REPORT_ID", _reportId));
                command.Parameters.Add(new SqlParameter("@BOSS_COMMENT", bosscomment));

                int ret = command.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }



            Hide();
            AdmitList admitList = new AdmitList();
            admitList.Show(this);
    




        }


        //承認しない場合
        private void Noadmit_Click(object sender, EventArgs e)
        {
            // 接続用のクラス
            SqlConnection con = new SqlConnection();

            // DBへの接続文字列。
            con.ConnectionString = "data source=localhost\\SQLEXPRESS;" + // 接続先のDBサーバーを指定
                                   "initial catalog=zebradb;" +            // 接続先のDBを指定
                                   "user id=sa;" +                        // ユーザー
                                   "password=p@ssw0rd;" +                 // パスワード
                                   "Connect Timeout=60;";

            try
            {
                con.Open(); // DBに接続

                // 問い合わせのSQLを生成
                string sql =
                    "UPDATE TM_DAILY_REPORT " +

                    "SET BOSS_COMMENT = @BOSS_COMMENT, APPROVAL_STATUS = 2 " +
                    "WHERE REPORT_ID = @REPORT_ID;";

                // コネクションオブジェクトを使用して、SQLの発行準備
                SqlCommand command = new SqlCommand(sql, con);

                //// SQL文を実行。approvalStatus
                //SqlDataReader reader = command.ExecuteReader();

                string bosscomment = bossComments.Text;
                // パラメタに値を設定
                command.Parameters.Add(new SqlParameter("@REPORT_ID", _reportId));
                command.Parameters.Add(new SqlParameter("@BOSS_COMMENT", bosscomment));

                int ret = command.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }

            Hide();
            AdmitList admitList = new AdmitList();
            admitList.Show(this);
        }
    }
}
