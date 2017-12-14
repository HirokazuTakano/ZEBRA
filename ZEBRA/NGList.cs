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
    /// NG一覧クラス　沢谷
    /// 
    /// </summary>
    public partial class NGList : Form
    {
        public NGList()
        {
            InitializeComponent();
        }

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
                 "ORDER BY REPORT_ID ";

            // コネクションオブジェクトを使用して、SQLの発行準備
            SqlCommand command = new SqlCommand(sql, con);


            // アダプターを作成
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "DS_AdmitList");

            List<string> reportlist = new List<string>();


            con.Open(); // DBに接続



            // DataGridViewが持つ、列の自動生成機能をオフ
            NGViewList.AutoGenerateColumns = false;

            // DataGridViewのデータをセット
            NGViewList.DataSource = ds;
            NGViewList.DataMember = "DS_AdmitList";

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

        private void topPageButton_Click(object sender, EventArgs e)
        {
            Hide();
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show(this);
            Debug.WriteLine("トップページに飛びました");
        }
    }
}
