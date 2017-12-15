﻿using System;
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
    /// 新規登録クラス　藤本
    /// </summary>
    public partial class ReportInput : Form

    {
        // 記入日
        string _createDate;
        // 訪問日時
        string _fromDate;
        int _fromHour;
        int _fromMinute;
        string _toDate;
        int _toHour;
        int _toMinute;
        // 顧客
        string _cus;
        // 訪問種別
        string visitType = "";
        // 内容
        string _reportText;
        //上司のID
        string bossId;
        //ログインユーザーのID
        string userId;

        // 接続用のクラス
        SqlConnection con = new SqlConnection();


        public ReportInput()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 「トップページ」ボタンが押下されたら、MainMenuに遷移する
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
      /// 「登録」ボタンを押下された時のイベント
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
        private void registButton_Click(object sender, EventArgs e)
        {
            //入力された記入日を取得
            _createDate = createDate.Text;

            //訪問日時を取得
            _fromDate = fromDate.Text;
            _fromHour = int.Parse(fromHour.Text);
            _fromMinute = int.Parse(fromMinute.Text);
            
            DateTime visitStart = DateTime.Parse(_fromDate + " " + _fromHour + ":" + _fromMinute);
            
            _toDate = toDate.Text;
            _toHour = int.Parse(toHour.Text);
            _toMinute = int.Parse(toMinute.Text);
            
            DateTime visitEnd = DateTime.Parse(_toDate + " " + _toHour + ":" + _toMinute);

            //顧客を取得
            _cus = customer.Text;

            //訪問種別を取得
            if(tell.Checked == true)
            {
                visitType = "電話";
            }else if(mail.Checked == true)
            {
                visitType = "メール";
            }
            else if (opponentHouse.Checked == true)
            {
                visitType = "相手宅";
            }
            else if (their.Checked == true)
            {
                visitType = "自社";
            }
            else if (another.Checked == true)
            {
                visitType = "その他";
            }

            //内容を取得
            _reportText = reportText.Text;




            //////////////Validateが通った場合、Insert実行

            

            // DBへの接続文字列。
            con.ConnectionString = "data source=localhost\\SQLEXPRESS;" + // 接続先のDBサーバーを指定
                                   "initial catalog=zebradb;" +            // 接続先のDBを指定
                                   "user id=sa;" +                        // ユーザー
                                   "password=p@ssw0rd;" +                 // パスワード
                                   "Connect Timeout=60;";

            try
            {
                    con.Open(); // DBに接続

                // 問い合わせのSQLを生成
                string sql =
                    "INSERT INTO TM_DAILY_REPORT"+
                    "(VISIT_STRAT_DATE, VISIT_END_DATE, CUS_ID, VISIT_TYPE, DETAILS, AUTHOR_ID, AUTHOR_BOSS_ID, BOSS_COMMENT, APPROVAL_STATUS)" +
                    "VALUES"+
                    "(@VISIT_STRAT_DATE, @VISIT_END_DATE, @CUS_ID, @VISIT_TYPE, @DETAILS, @AUTHOR_ID, @AUTHOR_BOSS_ID, @BOSS_COMMENT, 1); ";

                // コネクションオブジェクトを使用して、SQLの発行準備
                SqlCommand command = new SqlCommand(sql, con);

                //// SQL文を実行。approvalStatus
                //SqlDataReader reader = command.ExecuteReader();

                // パラメタに値を設定
                command.Parameters.Add(new SqlParameter("@VISIT_STRAT_DATE", visitStart));
                command.Parameters.Add(new SqlParameter("@VISIT_END_DATE", visitEnd));
                command.Parameters.Add(new SqlParameter("@CUS_ID", _cus));
                command.Parameters.Add(new SqlParameter("@VISIT_TYPE", visitType));
                command.Parameters.Add(new SqlParameter("@DETAILS", _reportText));
                command.Parameters.Add(new SqlParameter("@AUTHOR_ID", userId));
                command.Parameters.Add(new SqlParameter("@AUTHOR_BOSS_ID", bossId)); 
                command.Parameters.Add(new SqlParameter("@BOSS_COMMENT", ""));

                // 登録を実行する
                int ret = command.ExecuteNonQuery();

                // 登録が成功したら、完了メールを表示させてメインメニューへ遷移する
                if (ret == 1)
                {
                    MessageBox.Show("登録が完了しました。");

                    Hide();
                    MainMenu mainMenu = new MainMenu();
                    mainMenu.Show(this);
                    Debug.WriteLine("トップページに飛びました");

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
        }



        /// <summary>
        /// 顧客の「検索」ボタンが押下されたら、顧客検索フォームへ遷移する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchButton_Click(object sender, EventArgs e)
        {
            //会社名or顧客名を取得
            _cus = customer.Text;

            CustomerSearch search = new CustomerSearch();
            search.Show(this);  // ここで処理が止まる。
        }



        /// <summary>
        /// 新規登録をロードするときに上司の名前を取得し、表示させる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void ReportInput_Load(object sender, EventArgs e)
        {
            //ログインしているユーザー情報を取得
            Employee emp = MainMenu.loginUser;

            userId = emp.EmpId;
            bossId = emp.BossId;

            bossName.Text = "上司（仮）";

            //// DBへの接続文字列。
            //con.ConnectionString = "data source=localhost\\SQLEXPRESS;" + // 接続先のDBサーバーを指定
            //                       "initial catalog=zebradb;" +            // 接続先のDBを指定
            //                       "user id=sa;" +                        // ユーザー
            //                       "password=p@ssw0rd;" +                 // パスワード
            //                       "Connect Timeout=60;";
            //try
            //{
            //    con.Open();

            //    //SQL文を生成
            //    string sql =
            //        "SELECT NAME_SEI, NAME_MEI FROM dbo.TM_EMPLOYEE WHERE EMP_ID; ";

            //    //コネクションをオブジェクトとして、SQL発行準備
            //    SqlCommand command = new SqlCommand(sql, con);

            //    //アダプター生成
            //    SqlDataAdapter adapter = new SqlDataAdapter(command);

            //    //データセットを作成
            //    DataSet ds = new DataSet();

            //    //CUSTOMER_TABLEという名前のテーブルクラスに結果をセットし、保持させる
            //    adapter.Fill(ds, "CUSTOMER_TABLE");


            //    // データテーブルを生成
            //    DataTable customerDt = ds.Tables["CUSTOMER_TABLE"];

            //    //データを一行ずつ読みこんで、リストに追加する
            //    foreach (DataRow dr in customerDt.Rows)
            //    {
            //        string cusId = dr["CUS_ID"].ToString();
            //        string companyName = dr["COMPANY_NAME"].ToString();
            //        string cusName = dr["CUS_NAME"].ToString();
            //        string cusTel = dr["CUS_TEL"].ToString();

            //        Customer customer = new Customer(cusId, companyName, cusName, cusTel);
            //        customerList.Add(customer);

            //    }

            //}
            //catch (SqlException ex)
            //{
            //    Debug.WriteLine(ex.Message);
            //}

        }
    }
}
