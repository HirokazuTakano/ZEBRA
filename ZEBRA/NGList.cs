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
    /// NG一覧クラス　沢谷　犬伏
    /// 
    /// </summary>
    public partial class NGList : Form
    {
        private List<Report> reportList = new List<Report>();

        private Dictionary<int, string> customerList = new Dictionary<int, string>();

        private string cusName;
        private string compName;






        public NGList()
        {
            InitializeComponent();
        }



            /// <summary>
            /// NGリストを取得して表示させます
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
        private void NGList_Load(object sender, EventArgs e)
        {
            // 接続用のクラス
            SqlConnection con = new SqlConnection();

            // DBへの接続文字列。
            con.ConnectionString = "data source=localhost\\SQLEXPRESS;" + // 接続先のDBサーバーを指定
                                   "initial catalog=zebradb;" +            // 接続先のDBを指定
                                   "user id=sa;" +                        // ユーザー
                                   "password=p@ssw0rd;" +                 // パスワード
                                   "Connect Timeout=60;";


            // 問い合わせのSQLを生成
            string sql =
                "SELECT * " +
                 "FROM dbo.TM_DAILY_REPORT R INNER JOIN dbo.TM_CUSTOMER C " +
                 "ON R.CUS_ID = C.CUS_ID " +
                 "WHERE (AUTHOR_ID = @userId) AND (APPROVAL_STATUS = 2 ) " +
                 "ORDER BY REPORT_ID ;";

            // コネクションオブジェクトを使用して、SQLの発行準備
            SqlCommand command = new SqlCommand(sql, con);

            command.Parameters.Add(
                new SqlParameter("@userId", MainMenu.loginUser.EmpId));


            // アダプターを作成
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "NGViewList");

            List<string> reportlist = new List<string>();


            con.Open(); // DBに接続



            // DataGridViewが持つ、列の自動生成機能をオフ
            NGViewList.AutoGenerateColumns = false;

            // DataGridViewのデータをセット
            NGViewList.DataSource = ds;

            Report repo = null;

            DataTable reportDt = ds.Tables["NGViewList"];
            foreach (DataRow dr in reportDt.Rows)
            {
                //          [REPORT_ID]
                //,[CREATE_DATE]
                //,[UPDATE_DATE]
                //,[VISIT_STRAT_DATE]
                //,[VISIT_END_DATE]
                //,[VISIT_TYPE]
                //,[DETAILS]
                //,[CUS_ID]
                //,[APPROVAL_STATUS]
                //,[AUTHOR_ID]
                //,[AUTHOR_BOSS_ID]
                //,[BOSS_COMMENT]
                repo = new Report(int.Parse(dr["REPORT_ID"].ToString()), DateTime.Parse(dr["CREATE_DATE"].ToString()), DateTime.Parse(dr["UPDATE_DATE"].ToString()),
                    DateTime.Parse(dr["VISIT_STRAT_DATE"].ToString()), DateTime.Parse(dr["VISIT_END_DATE"].ToString()),
                    (dr["VISIT_TYPE"].ToString()), (dr["DETAILS"].ToString()), (dr["CUS_ID"].ToString()), int.Parse(dr["APPROVAL_STATUS"].ToString()),
                        (dr["AUTHOR_ID"].ToString()), (dr["AUTHOR_BOSS_ID"].ToString()), "田中", "太郎", (dr["BOSS_COMMENT"].ToString()));

                reportList.Add(repo);

                customerList.Add(int.Parse(dr["REPORT_ID"].ToString()), (dr["COMPANY_NAME"].ToString() + dr["CUS_NAME"].ToString()));
            }


            NGViewList.DataMember = "NGViewList";

            // 表示列を追加
            NGViewList.Columns.Add("reportId", "レポート番号");
            NGViewList.Columns["reportId"].DataPropertyName = "REPORT_ID";

            NGViewList.Columns.Add("createdate", "作成日");
            NGViewList.Columns["createdate"].DataPropertyName = "CREATE_DATE";

            NGViewList.Columns.Add("start", "訪問開始日時");
            NGViewList.Columns["start"].DataPropertyName = "VISIT_STRAT_DATE";

            NGViewList.Columns.Add("end", "訪問終了日時");
            NGViewList.Columns["end"].DataPropertyName = "VISIT_END_DATE";

            NGViewList.Columns.Add("type", "訪問種別");
            NGViewList.Columns["type"].DataPropertyName = "VISIT_TYPE";
            

            // ボタンを追加
            DataGridViewButtonColumn button = new DataGridViewButtonColumn();
            button.Name = "editButton";
            button.HeaderText = "操作";
            button.UseColumnTextForButtonValue = true;  // Textプロパティ値をボタンに表示させる。
            button.Text = "修正";
            NGViewList.Columns.Add(button);


        }

        /// <summary>
        /// トップページへ遷移します
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void topPageButton_Click(object sender, EventArgs e)
        {
            Hide();
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show(this);
            Debug.WriteLine("トップページに飛びました");
        }

        /// <summary>
        /// クリックした要素を詳細に渡します。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NGViewList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ReportModify modify = new ReportModify();
            
            // senderにはイベントを発生させたコントロールが入っている
            DataGridView dgv = (DataGridView)sender;

            if (dgv.Columns[e.ColumnIndex].Name == "editButton")
            {
                int cellIndex = dgv.Columns["reportId"].Index;
                for(int i = 0; i < (reportList.Capacity - 1) ; i++)
                {
                    if ((int)dgv.Rows[e.RowIndex].Cells[cellIndex].Value == reportList[i].ReportId)
                    {
                        //Report report = new Report(dgv.Columns["reportId"].Index, DateTime.Parse(""  + dgv.Columns["createdate"].Index), DateTime.Parse("" + dgv.Columns["update"].Index),
                        //        DateTime.Parse("" + dgv.Columns["start"].Index), DateTime.Parse("" + dgv.Columns["start"].Index),
                        //        "" + dgv.Columns["type"].Index, "" + dgv.Columns["detail"].Index, "" + dgv.Columns["cusId"].Index, dgv.Columns["approval"].Index,
                        //            "" + dgv.Columns["authorId"].Index, "" + dgv.Columns["authorBoss"].Index, "田中", "太郎", "" + dgv.Columns["bossComment"].Index);

                        // []で値を取得する
                        if (customerList.ContainsKey((int)dgv.Rows[e.RowIndex].Cells[cellIndex].Value))
                        {
                            cusName = customerList[(int)dgv.Rows[e.RowIndex].Cells[cellIndex].Value];
                        }
                        modify.getReport(reportList[i], cusName);
                        modify.Show(this);

                        break;
                    }     
                }

            }
        }
    }
}
