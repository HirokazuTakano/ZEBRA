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
                 "FROM dbo.TM_DAILY_REPORT R INNER JOIN dbo.TM_CUSTOMER C " +
                 "ON R.CUS_ID = C.CUS_ID " +
                 "ORDER BY REPORT_ID ";

            // コネクションオブジェクトを使用して、SQLの発行準備
            SqlCommand command = new SqlCommand(sql, con);


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

            list.Columns.Add("companyName", "顧客");
            list.Columns["companyName"].DataPropertyName = "COMPANY_NAME";

            //list.Columns.Add("createdate", "顧客名");
            //list.Columns["createdate"].DataPropertyName = "CREATE_DATE";

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

        private void logoutButton_Click(object sender, EventArgs e)
        {
            Hide();
            Login logint = new Login();
            logint.Show(this);
            Debug.WriteLine("ログアウトしました");
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            Hide();
            CustomerSearch customerSearch = new CustomerSearch();
            customerSearch.Show(this);
            Debug.WriteLine("顧客選択画面表示");
        }

        private void newReportButton_Click(object sender, EventArgs e)
        {
            Hide();
            ReportInput customerSearch = new ReportInput();
            customerSearch.Show(this);
            Debug.WriteLine("新規作成画面表示");
        }

        private void list_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Hide();
            ReportDatail reportDatail = new ReportDatail();
            reportDatail.Show(this);
            Debug.WriteLine("新規作成画面表示");
        }
    }
}

