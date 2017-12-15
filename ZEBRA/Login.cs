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
    public partial class Login : Form
    {
        DbConnection db = new DbConnection();

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {         

        }

        private void loginButton_Click(object sender, EventArgs e)
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
                 "FROM dbo.TM_EMPLOYEE " +
                "WHERE EMP_ID = @EMP_ID AND EMP_PASSWORD = @EMP_PASSWORD ";

            // コネクションオブジェクトを使用して、SQLの発行準備
            SqlCommand command = new SqlCommand(sql, con);

            // パラメタに値を設定
            command.Parameters.Add(
                    new SqlParameter("@EMP_ID", id.Text));
            command.Parameters.Add(
                    new SqlParameter("@EMP_PASSWORD", password.Text));

            try
            {
                con.Open(); // DBに接続

                // SQL文を実行。
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                    //ログイン
                {
                    Employee loginUser =
                        new Employee(reader.GetString(0),
                                     reader.GetString(1),
                                     reader.GetString(2) + " " + reader.GetString(3),
                                     reader.GetString(4),
                                     "上司名(仮)",
                                     reader.GetString(5),
                                     "部署名(仮)",
                                     reader.GetString(6)
                                     );
                    MainMenu.loginUser = loginUser;

                    Hide();
                    MainMenu mainMenu = new MainMenu();
                    mainMenu.Show(this);
                    Debug.WriteLine("メインメニューを表示");
                }
                else
                   //ログイン不可
                {
                    MessageBox.Show("ログインできませんでした");
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
    }
}
