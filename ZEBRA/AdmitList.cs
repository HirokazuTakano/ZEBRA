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


        public AdmitList(int reportId, DateTime createDate, DateTime updateDate, DateTime visitStratDate, DateTime visitEndDate
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


        public int ReportId
        {
            get
            {
                return reportId;
            }
        }


        public DateTime CreateDate
        {
            get
            {
                return createDate;
            }
            set
            {
                createDate = value;
            }
        }


        public DateTime UpdateDate
        {
            get
            {
                return updateDate;
            }
            set
            {
                updateDate = value;
            }
        }

        public DateTime VisitStratDate
        {
            get
            {
                return visitStratDate;
            }
            set
            {
                visitStratDate = value;
            }
        }

        public DateTime VisitEndDate
        {
            get
            {
                return visitEndDate;
            }
            set
            {
                visitEndDate = value;
            }
        }


        public string Detaile
        {
            get
            {
                return detaile;
            }
            set
            {
                detaile = value;
            }
        }


        public string Visittype
        {
            get
            {
                return visittype;
            }
            set
            {
                visittype = value;
            }
        }

        public string CusId
        {
            get
            {
                return cusId;
            }
        }


        public int Approvalstatus
        {
            get
            {
                return approvalstatus;
            }
            set
            {
                approvalstatus = value;
            }
        }



        public string AutherId
        {
            get
            {
                return autherId;
            }
        }

        public string BossId
        {
            get
            {
                return bossId;
            }
        }

        public string BossSei
        {
            get
            {
                return bossSei;
            }
            set
            {
                bossSei = value;
            }
        }

        public string BossMei
        {
            get
            {
                return bossMei;
            }
            set
            {
                bossMei = value;
            }
        }

        public string Bsscomment
        {
            get
            {
                return bosscomment;
            }
            set
            {
                bosscomment = value;
            }
        }

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

        private void topPageButton_Click(object sender, EventArgs e)
        {
            Hide();
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show(this);
            Debug.WriteLine("トップページに飛びました");
        }
    }
}
