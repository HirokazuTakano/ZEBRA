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
    /// 新規登録クラス　藤本
    /// </summary>
    public partial class ReportInput : Form

    {

        // 顧客
        string _customerName;
        string _company;
        string _customerId;

        //上司のID
        string bossId;
        //ログインユーザーのID
        string userId;

        // 接続用のクラス
        SqlConnection con = new SqlConnection();


        //顧客IDのプロパティ
        public string CustomerId
        {
            get
            {
                return _customerId;
            }

            set
            {
                _customerId = value;
            }
        }
        //顧客名のプロパティ
        public string CustomerName
        {
            get
            {
                return _customerName;
            }

            set
            {
                _customerName = value;
            }
        }

        //会社名
        public string Company
        {
            get
            {
                return _company;
            }

            set
            {
                _company = value;
            }
        }

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
            string _createDate = createDate.Text;

            //訪問日時を取得
            DateTime _fromDate = DateTime.Parse(fromDate.Text);
            string _fromHour = fromHour.Text;
            string _fromMinute = fromMinute.Text;
            
            DateTime _toDate = DateTime.Parse(toDate.Text);
            string _toHour = toHour.Text;
            string _toMinute = toMinute.Text;

            //顧客を取得
            _customerId = customer.Text;

            string visitType = "";
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
            string _reportText = reportText.Text;


            //入力情報をチェック

            CommonValidater validate = new CommonValidater(_fromDate, _fromHour,_fromMinute, 
                _toDate, _toHour, _toMinute, _customerId, visitType, _reportText);

            //////////////Validateが通った場合、Insert実行
            if(validate.InputCheck())
            {
                //DateTime型の訪問日時を取得する
                DateTime _visitStart = validate.StartDateAll;
                DateTime _visitEnd = validate.EndDateAll;

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
                    command.Parameters.Add(new SqlParameter("@VISIT_STRAT_DATE", _visitStart));
                    command.Parameters.Add(new SqlParameter("@VISIT_END_DATE", _visitEnd));
                    command.Parameters.Add(new SqlParameter("@CUS_ID", _customerId));
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



            }else
            {
                

                MessageBox.Show("入力ミス！");
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
            //Customer = customer.Text;

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

            bossName.Text = MainMenu.loginUser.BossName;

        }
    }
}
