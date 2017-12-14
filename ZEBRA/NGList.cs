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

        private readonly int reportId; // 日報ID
        private DateTime createDate; // 作成日時
        private DateTime updateDate; // 更新日時
        private DateTime visitStratDate; // 訪問開始日時
        private DateTime visitEndDate;　　// 訪問終了日時
        private string visittype;　　　　// 訪問種別
        private string detaile;         //本文
        private readonly string cusId;          //顧客ID 
        private int approvalstatus;    // 承認フラグ
        private readonly string autherId;       // 作成者ID
        private readonly string bossId;         // 上司ID
        private string bossSei;        // 上司姓
        private string bossMei;        //　上司名
        private string bosscomment;    //　上司コメント


        public NGList(int reportId, DateTime createDate, DateTime updateDate, DateTime visitStratDate, DateTime visitEndDate
                     , string visittype, string detaile, string cusId, int approvalstatus, string autherId, string bossId
                     , string bossSei, string bossMei, string bosscomment)
        {
            this.reportId = reportId;
            this.createDate = createDate;
            this.updateDate = updateDate;
            this.visitStratDate = visitStratDate;
            this.visitEndDate = visitEndDate;
            this.visittype = visittype;
            this.detaile = detaile;
            this.cusId = cusId;
            this.autherId = autherId;
            this.bossId = bossId;
            this.bossSei = bossSei;
            this.bossMei = bossMei;
            this.bosscomment = bosscomment;
        }


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
