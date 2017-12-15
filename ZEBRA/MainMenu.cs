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

//RyohShimabukuro

namespace ZEBRA
{
    public partial class MainMenu : Form
    {
        public static Employee loginUser;

        public MainMenu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// メインメニュー画面表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainMenu_Load(object sender, EventArgs e)
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
                 "FROM dbo.TM_DAILY_REPORT R LEFT JOIN dbo.TM_CUSTOMER C " +
                 "ON R.CUS_ID = C.CUS_ID " +
                 "LEFT JOIN dbo.TS_STATUS ON APPROVAL_STATUS = STATUS " +
                 "LEFT JOIN dbo.TM_EMPLOYEE E ON R.AUTHOR_ID = EMP_ID " +
                 "WHERE R.AUTHOR_ID = @EMP_ID " +
                 "ORDER BY REPORT_ID ";


            // コネクションオブジェクトを使用して、SQLの発行準備
            SqlCommand command = new SqlCommand(sql, con);

            // パラメタに値を設定
            command.Parameters.Add(
                    new SqlParameter("@EMP_ID", MainMenu.loginUser.EmpId));

            // アダプターを作成
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "DS_REPORT");

            // DataGridViewが持つ、列の自動生成機能をオフ
            list.AutoGenerateColumns = false;

            // DataGridViewのデータをセット
            list.DataSource = ds;
            list.DataMember = "DS_REPORT";

            // 表示列を追加
            list.Columns.Add("reportId", "ID");
            list.Columns["reportId"].DataPropertyName = "REPORT_ID";

            list.Columns.Add("createDate", "作成日");
            list.Columns["createDate"].DataPropertyName = "CREATE_DATE";

            list.Columns.Add("createUser", "作成者");
            list.Columns["createUser"].DataPropertyName = "NAME_SEI";

            list.Columns.Add("companyName", "顧客");
            list.Columns["companyName"].DataPropertyName = "COMPANY_NAME";

            list.Columns.Add("status", "ステータス");
            list.Columns["status"].DataPropertyName = "STATUS_NAME";

            // ボタンを追加
            DataGridViewButtonColumn button = new DataGridViewButtonColumn();
            button.Name = "editButton";
            button.HeaderText = "操作";
            button.UseColumnTextForButtonValue = true;  // Textプロパティ値をボタンに表示させる。
            button.Text = "詳細画面へ";
            list.Columns.Add(button);

        }
        /// <summary>
        /// 承認待ちリスト画面に遷移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void admitLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hide();
            AdmitList admitList = new AdmitList();
            admitList.Show(this);
            Debug.WriteLine("承認待ちリスト表示");
        }

        /// <summary>
        /// NGリスト画面に遷移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NGLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hide();
            NGList ngList = new NGList();
            ngList.Show(this);
            Debug.WriteLine("NGリスト表示");
        }

        /// <summary>
        /// ボタン押下でログアウト
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void logoutButton_Click(object sender, EventArgs e)
        {
            Hide();
            Login logint = new Login();
            logint.Show(this);
            Debug.WriteLine("ログアウトしました");
        }

        /// <summary>
        /// ボタン押下で検索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchButton_Click(object sender, EventArgs e)
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
                "FROM  dbo.TM_DAILY_REPORT R LEFT JOIN dbo.TM_EMPLOYEE E " +
                "ON R.AUTHOR_ID = E.EMP_ID " +
                "LEFT JOIN dbo.TM_CUSTOMER C ON R.CUS_ID = C.CUS_ID " +
                "LEFT JOIN dbo.TS_STATUS ON APPROVAL_STATUS = STATUS " +
                "WHERE (E.NAME_SEI + E.NAME_MEI) LIKE @SEARCHNAME "+
                "ORDER BY REPORT_ID ";

            // コネクションオブジェクトを使用して、SQLの発行準備
            SqlCommand command = new SqlCommand(sql, con);

            // パラメタに値を設定
            command.Parameters.Add(
                    new SqlParameter("@SEARCHNAME", "%"+searchWord.Text+"%"));


            // アダプターを作成
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "DS_REPORT");

            // DataGridViewが持つ、列の自動生成機能をオフ
            list.AutoGenerateColumns = false;

            // DataGridViewのデータをセット
            list.DataSource = ds;
            list.DataMember = "DS_REPORT";

            // 表示列を追加
            list.Columns["reportId"].DataPropertyName = "REPORT_ID";
            list.Columns["createDate"].DataPropertyName = "CREATE_DATE";
            list.Columns["createUser"].DataPropertyName = "NAME_SEI";
            list.Columns["companyName"].DataPropertyName = "COMPANY_NAME";
            list.Columns["status"].DataPropertyName = "STATUS_NAME";
        }

        /// <summary>
        /// ボタン押下で新規作成画面に遷移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newReportButton_Click(object sender, EventArgs e)
        {
            Hide();
            ReportInput customerSearch = new ReportInput();
            customerSearch.Show(this);
            Debug.WriteLine("新規作成画面表示");
        }

        /// <summary>
        /// ボタン押下で詳細画面に遷移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void list_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            //Hide();
            ReportDatail reportDatail = new ReportDatail();


            DataGridView dgv = (DataGridView)sender;
            int cellIndex = dgv.Columns["reportId"].Index;

            object o = dgv.Rows[e.RowIndex].Cells[cellIndex].Value;


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
               "SELECT CREATE_DATE,VISIT_STRAT_DATE,VISIT_END_DATE,VISIT_TYPE,DETAILS,STATUS,BOSS_COMMENT,COMPANY_NAME " +
                 "FROM dbo.TM_DAILY_REPORT R LEFT JOIN dbo.TM_CUSTOMER C " +
                 "ON R.CUS_ID = C.CUS_ID " +
                 "LEFT JOIN dbo.TS_STATUS S ON APPROVAL_STATUS = STATUS " +
                "WHERE REPORT_ID = @REPORT_ID ";

            // コネクションオブジェクトを使用して、SQLの発行準備
            SqlCommand command = new SqlCommand(sql, con);

            // パラメタに値を設定
            command.Parameters.Add(
                    new SqlParameter("@REPORT_ID", o));

            try
            {
                con.Open(); // DBに接続

                // SQL文を実行。
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

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

            reportDatail.Show(this);
            Debug.WriteLine("詳細画面表示");
        }
    }
}

