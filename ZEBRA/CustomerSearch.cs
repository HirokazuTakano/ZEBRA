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
        private string _cusId;
        private string _compName;
        private string _cusName;
        private List<Customer> searchCusList;


        //コンストラクタ
        public CustomerSearch()
        {
            InitializeComponent();
            this.searchCusList = new List<Customer>();
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

            // グリットビューのガワを作成
            customerList.Columns.Add("cusId", "顧客ID");
            customerList.Columns.Add("companyName", "会社名");
            customerList.Columns.Add("cusName", "顧客名");
            customerList.Columns.Add("cusTel", "電話番号");

            
            // ボタンを追加
            DataGridViewButtonColumn button = new DataGridViewButtonColumn();
            button.Name = "editButton";
            button.HeaderText = "操作";
            // Textプロパティ値をボタンに表示させる。
            button.UseColumnTextForButtonValue = true;
            button.Text = "選択";
            customerList.Columns.Add(button);

        }

        private void cusSearch_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("顧客検索ボタンが押されました");

            string inputSerrchStr = searchCusText.Text;
            Debug.WriteLine("入力文字は" + "「" + inputSerrchStr + "」");



            // 接続用のクラス
            SqlConnection con = new SqlConnection();


            // DBへの接続文字列。
            con.ConnectionString = "data source=localhost\\SQLEXPRESS;" + // 接続先のDBサーバーを指定
                                   "initial catalog=zebradb;" +            // 接続先のDBを指定
                                   "user id=sa;" +                        // ユーザー
                                   "password=p@ssw0rd;" +                 // パスワード
                                   "Connect Timeout=60;";


            //SQL文を生成
            string sql =
                "SELECT * " +
                    "FROM TM_CUSTOMER " +
                    "WHERE COMPANY_NAME LIKE @companyName  OR CUS_NAME LIKE @cusName; ";


            // コネクションオブジェクトを使用して、SQLの発行準備
            SqlCommand command = new SqlCommand(sql, con);
            command.Parameters.Add(
                new SqlParameter("@companyName", "%" + inputSerrchStr + "%"));
            command.Parameters.Add(
                new SqlParameter("@cusName", "%" + inputSerrchStr + "%"));

            // アダプターを作成
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            // データセットを作成
            DataSet ds = new DataSet();
            adapter.Fill(ds, "DS_CUSTOMER");


            string forbreakpoint = "ブレイクポイントを作成";


            //// レコードを1行ずつ読む。
            //Customer cus = null;
            //foreach (DataRow dr in customerDt.Rows)
            //{
            //    cus = new Customer(dr["CUS_ID"].ToString(),
            //                       dr["COMPANY_NAME"].ToString(),
            //                       dr["CUS_NAME"].ToString(),
            //                       dr["CUS_TEL"].ToString());

            //    searchCusList.Add(cus);

            //}


            // DataGridViewが持つ、列の自動生成機能をオフ
            customerList.AutoGenerateColumns = false;


            // DataGridViewのデータをセット
            customerList.DataSource = ds;
            customerList.DataMember = "DS_CUSTOMER"; // Nullぽ

            
            customerList.Columns["cusId"].DataPropertyName = "CUS_ID";
            customerList.Columns["companyName"].DataPropertyName = "COMPANY_NAME";
            customerList.Columns["cusName"].DataPropertyName = "CUS_NAME";
            customerList.Columns["cusTel"].DataPropertyName = "CUS_TEL";





        }

        /// <summary>
        /// 顧客検索画面の選択ボタンが押された時のイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void customerList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // senderにはイベントを発生させたコントロールが入っている
            DataGridView dgv = (DataGridView)sender;

            if (dgv.Columns[e.ColumnIndex].Name == "editButton")
            {
                // 顧客IDのインデックスを取得
                int cellIndexCusId = dgv.Columns["cusId"].Index;
                int cellIndexCompName = dgv.Columns["companyName"].Index;
                int cellIndexCusName = dgv.Columns["cusName"].Index;

                // e.ColumnIndexは列インデックス
                // e.RowIndexは行インデックス

                // クリックされた行の顧客IDの表示
                _cusId = (string)dgv.Rows[e.RowIndex].Cells[cellIndexCusId].Value;
                _compName = (string)dgv.Rows[e.RowIndex].Cells[cellIndexCompName].Value;
                _cusName = (string)dgv.Rows[e.RowIndex].Cells[cellIndexCusName].Value;

                    //MessageBox.Show(_cusId + _compName + _cusName);
                    //Owner.(TextBox)customer.Text = _cusId;

                    ReportInput ri = (ReportInput)Owner;
                    ri.CustomerId = _cusId;
                    ri.Company = _compName;
                    ri.CustomerName = _cusName;



                this.Close();


            }


        }
    }
}
