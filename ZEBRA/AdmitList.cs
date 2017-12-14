using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZEBRA
{
    public partial class AdmitList : Form
    {
        public AdmitList()
        {
            InitializeComponent();
        }

        private void AdmitList_Load(object sender, EventArgs e)
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
            admitViewList.AutoGenerateColumns = false;

            // DataGridViewのデータをセット
            admitViewList.DataSource = ds;
            admitViewList.DataMember = "DS_AdmitList";

            // 表示列を追加
            admitViewList.Columns.Add("reportId", "レポート番号");
            admitViewList.Columns["reportId"].DataPropertyName = "REPORT_ID";

            admitViewList.Columns.Add("createdate", "作成日");
            admitViewList.Columns["createdate"].DataPropertyName = "CREATE_DATE";


            admitViewList.Columns.Add("start", "訪問開始日時");
            admitViewList.Columns["start"].DataPropertyName = "VISIT_STRAT_DATE";


            admitViewList.Columns.Add("end", "訪問終了日時");
            admitViewList.Columns["end"].DataPropertyName = "VISIT_END_DATE";

            admitViewList.Columns.Add("type", "訪問種別");
            admitViewList.Columns["type"].DataPropertyName = "VISIT_TYPE";


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
            //DataGridView dgv = (DataGridView)sender;
            ////"Button"列ならば、ボタンがクリックされた
            //if (dgv.Columns[e.ColumnIndex].Name == "button")
            //{
            //    MessageBox.Show(e.RowIndex.ToString() +
            //        "行のボタンがクリックされました。");
            //}

        }
    }
}
