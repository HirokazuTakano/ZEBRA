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
    public partial class CustomerSearch : Form
    {
        private string _cus;

        public CustomerSearch()
        {
            InitializeComponent();
        }

        //コンストラクタ　　会社名or顧客名を取得
        public CustomerSearch(string _cus)
        {
            this._cus = _cus;
        }

        //「トップページ」ボタンを押下
        private void topPageButton_Click(object sender, EventArgs e)
        {
            MainMenu main = new MainMenu();
            main.ShowDialog(this);  // ここで処理が止まる。
            Debug.WriteLine("画面を表示後。"); // 子画面が閉じてから、実行される。
        }


        /// <summary>
        /// 顧客検索フォームをロードするときのイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomerSearch_Load(object sender, EventArgs e)
        {
            Debug.WriteLine("顧客検索フォームです");

            SqlConnection con = new SqlConnection();


            // DBへの接続文字列。
            con.ConnectionString = "data source=localhost\\SQLEXPRESS;" + // 接続先のDBサーバーを指定
                                   "initial catalog=zebradb;" +            // 接続先のDBを指定
                                   "user id=sa;" +                        // ユーザー
                                   "password=p@ssw0rd;" +                 // パスワード
                                   "Connect Timeout=60;";

            try
            {
                //SQL文を生成
                string sql =
                    "SELECT * " +
                        "FROM TM_CUSTOMER " +
                        "WHERE COMPANY_NAME LIKE '%@companyName%'  OR COS_NAME LIKE '%@cusName%'; ";

                //コネクションをオブジェクトとして、SQL発行準備
                SqlCommand command = new SqlCommand(sql, con);


                // パラメタに値を設定
                command.Parameters.Add(new SqlParameter("@companyName", _cus));
                command.Parameters.Add(new SqlParameter("@cusName", _cus));

                //アダプター生成
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                //データセットを作成
                DataSet ds = new DataSet();

                //DS_VEHICLEという名前のテーブルクラスに結果をセットし、保持させる
                adapter.Fill(ds, "DS_VEHICLE");

                // DataGridViewが持つ、列の自動生成機能をオフ
                customerList.AutoGenerateColumns = false;

                // DataGridViewのデータをセット
                customerList.DataSource = ds;
                customerList.DataMember = "DS_CUSTOMER";

                // 表示列を追加
                customerList.Columns.Add("cusId", "顧客ID");
                customerList.Columns["cusId"].DataPropertyName = "CUS_ID";

                customerList.Columns.Add("companyName", "会社名");
                customerList.Columns["companyName"].DataPropertyName = "COMPANY_NAME";

                customerList.Columns.Add("cusName", "顧客名");
                customerList.Columns["cusName"].DataPropertyName = "CUS_NAME";

                customerList.Columns.Add("cusTel", "電話番号");
                customerList.Columns["cusTel"].DataPropertyName = "CUS_TEL";



                // ボタンを追加
                DataGridViewButtonColumn button = new DataGridViewButtonColumn();
                button.Name = "editButton";
                button.HeaderText = "操作";
                // Textプロパティ値をボタンに表示させる。
                button.UseColumnTextForButtonValue = true;
                button.Text = "選択";
                customerList.Columns.Add(button);

            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }
    }
}
