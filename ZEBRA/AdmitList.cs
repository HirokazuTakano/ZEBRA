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
    /// 承認一覧クラス　　沢谷
    /// 
    /// </summary>
    public partial class AdmitList : Form
    {

        private List<string> reportlist = null;

        public AdmitList()
        {
            InitializeComponent();
        }

        private void AdmitList_Load(object sender, EventArgs e)
        {
            //// 接続用のクラス
            //SqlConnection con = new SqlConnection();

            //// DBへの接続文字列。
            //con.ConnectionString = "data source=localhost\\SQLEXPRESS;" + // 接続先のDBサーバーを指定
            //                       "initial catalog=zebradb;" +            // 接続先のDBを指定
            //                       "user id=sa;" +                        // ユーザー
            //                       "password=p@ssw0rd;" +                 // パスワード
            //                       "Connect Timeout=60;";


            //// 問い合わせのSQLを生成
            //string sql =
            //     "SELECT * " +
            //     "FROM dbo.TM_DAILY_REPORT R INNER JOIN dbo.TM_CUSTOMER C " +
            //     "ON R.CUS_ID = C.CUS_ID " +
            //     "WHERE  APPROVAL_STATUS = 1 AND AUTHOR_BOSS_ID = @EMP_ID";



            //// コネクションオブジェクトを使用して、SQLの発行準備
            //SqlCommand command = new SqlCommand(sql, con);

            //// パラメタに値を設定
            //command.Parameters.Add(
            //        new SqlParameter("@EMP_ID", MainMenu.loginUser.EmpId));


            //// アダプターを作成
            //SqlDataAdapter adapter = new SqlDataAdapter(command);
            //DataSet ds = new DataSet();
            //adapter.Fill(ds, "DS_AdmitList");

            //List<string> reportlist = new List<string>();


            //con.Open(); // DBに接続



            //reportlist = setDate();



            SqlConnection con = setDate();


            DataSet ds = setDataSet(con);



            reportlist = new List<string>();

            //if (admitViewList.RowCount == 0)
            //{
            //    MessageBox.Show("あなた宛ての認証待ち日報はありません");
            //    this.Close();
            //}


            // DataGridViewが持つ、列の自動生成機能をオフ
            admitViewList.AutoGenerateColumns = false;

            // DataGridViewのデータをセット
            admitViewList.DataSource = ds;
            admitViewList.DataMember = "DS_AdmitList";

            // 表示列を追加
            admitViewList.Columns.Add("reportId", "レポート番号");
            admitViewList.Columns["reportId"].DataPropertyName = "REPORT_ID";


            admitViewList.Columns.Add("createdate", "作成日");
            admitViewList.Columns["createdate"].DataPropertyName = "CREATE_DATE";


            admitViewList.Columns.Add("company", "訪問先");
            admitViewList.Columns["company"].DataPropertyName = "COMPANY_NAME";


            admitViewList.Columns.Add("start", "訪問開始日時");
            admitViewList.Columns["start"].DataPropertyName = "VISIT_STRAT_DATE";


            admitViewList.Columns.Add("end", "訪問終了日時");
            admitViewList.Columns["end"].DataPropertyName = "VISIT_END_DATE";

            admitViewList.Columns.Add("type", "訪問種別");
            admitViewList.Columns["type"].DataPropertyName = "VISIT_TYPE";

            admitViewList.Columns.Add("detail", "内容");
            admitViewList.Columns["detail"].DataPropertyName = "DETAILS";


            // ボタンを追加
            DataGridViewButtonColumn button = new DataGridViewButtonColumn();
            button.Name = "editButton";
            button.HeaderText = "操作";
            button.UseColumnTextForButtonValue = true;  // Textプロパティ値をボタンに表示させる。
            button.Text = "詳細";
            admitViewList.Columns.Add(button);



        }

        private void admitViewList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            // senderにはイベントを発生させたコントロールが入っている
            DataGridView dgv = (DataGridView)sender;


            if (dgv.Columns[e.ColumnIndex].Name == "editButton")
            {
                // 日報IDのインデックスを取得
                int _reportId = dgv.Columns["reportId"].Index;
                int _date = dgv.Columns["createdate"].Index;
                int _visit = dgv.Columns["start"].Index;
                int _visitTo = dgv.Columns["start"].Index;
                int _type = dgv.Columns["type"].Index;
                int _content = dgv.Columns["detail"].Index;
                int _company = dgv.Columns["company"].Index;


                AdmitReportDetail f = new AdmitReportDetail();
                //子画面のプロパティに値をセットする
                f.ReportId = "" + dgv.Rows[e.RowIndex].Cells[_reportId].Value;
                f.Date = "" + dgv.Rows[e.RowIndex].Cells[_date].Value;
                f.Visit = "" + dgv.Rows[e.RowIndex].Cells[_visit].Value;
                f.VisitTo = "" + dgv.Rows[e.RowIndex].Cells[_visitTo].Value;
                f.Type = "" + dgv.Rows[e.RowIndex].Cells[_type].Value;
                f.Content = "" + dgv.Rows[e.RowIndex].Cells[_content].Value;
                f.Company = "" + dgv.Rows[e.RowIndex].Cells[_company].Value;

                f.ShowDialog();
                f.Dispose();

                //this.();


                SqlConnection con = setDate();

                DataSet ds = setDataSet(con);


                reportlist = new List<string>();



                //if (reportlist.Count == 0)
                //{
                //    MessageBox.Show("あなた宛ての認証待ち日報はありません");
                //    this.Close();
                //}


                // DataGridViewが持つ、列の自動生成機能をオフ
                admitViewList.AutoGenerateColumns = false;

                // DataGridViewのデータをセット
                admitViewList.DataSource = ds;
                admitViewList.DataMember = "DS_AdmitList";

                // 表示列を追加
                admitViewList.Columns.Add("reportId", "レポート番号");
                admitViewList.Columns["reportId"].DataPropertyName = "REPORT_ID";


                admitViewList.Columns.Add("createdate", "作成日");
                admitViewList.Columns["createdate"].DataPropertyName = "CREATE_DATE";


                admitViewList.Columns.Add("company", "訪問先");
                admitViewList.Columns["company"].DataPropertyName = "COMPANY_NAME";


                admitViewList.Columns.Add("start", "訪問開始日時");
                admitViewList.Columns["start"].DataPropertyName = "VISIT_STRAT_DATE";


                admitViewList.Columns.Add("end", "訪問終了日時");
                admitViewList.Columns["end"].DataPropertyName = "VISIT_END_DATE";

                admitViewList.Columns.Add("type", "訪問種別");
                admitViewList.Columns["type"].DataPropertyName = "VISIT_TYPE";

                admitViewList.Columns.Add("detail", "内容");
                admitViewList.Columns["detail"].DataPropertyName = "DETAILS";


                // ボタンを追加
                DataGridViewButtonColumn button = new DataGridViewButtonColumn();
                button.Name = "editButton";
                button.HeaderText = "操作";
                button.UseColumnTextForButtonValue = true;  // Textプロパティ値をボタンに表示させる。
                button.Text = "詳細";
                admitViewList.Columns.Add(button);




                //// 再起動後のForm2を生成
                //AdmitList admitList = new AdmitList();
                //// 自身を閉じる
                //this.Close();
                ////再起動のForm2を起動する
                //admitList.Show();

                ////子画面から値を取得する
                //this.label1.Text = f.strParam;
                //f.Dispose();

            }
        }

        private void topPageButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AdmitList_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Hide();
            Owner.Show();
            Debug.WriteLine("トップページに飛びました");
        }




        private SqlConnection setDate()
        {
            // 接続用のクラス
            SqlConnection con = new SqlConnection();

            // DBへの接続文字列。
            con.ConnectionString = "data source=localhost\\SQLEXPRESS;" + // 接続先のDBサーバーを指定
                                   "initial catalog=zebradb;" +            // 接続先のDBを指定
                                   "user id=sa;" +                        // ユーザー
                                   "password=p@ssw0rd;" +                 // パスワード
                                   "Connect Timeout=60;";

            return con;

        }


        private DataSet setDataSet(SqlConnection con)
        {


            // 問い合わせのSQLを生成
            string sql =
                 "SELECT * " +
                 "FROM dbo.TM_DAILY_REPORT R INNER JOIN dbo.TM_CUSTOMER C " +
                 "ON R.CUS_ID = C.CUS_ID " +
                 "WHERE  APPROVAL_STATUS = 1 AND AUTHOR_BOSS_ID = @EMP_ID";



            // コネクションオブジェクトを使用して、SQLの発行準備
            SqlCommand command = new SqlCommand(sql, con);

            // パラメタに値を設定
            command.Parameters.Add(
                    new SqlParameter("@EMP_ID", MainMenu.loginUser.EmpId));


            // アダプターを作成
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "DS_AdmitList");


            return ds;

        }


    }
}
