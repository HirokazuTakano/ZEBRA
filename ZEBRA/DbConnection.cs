using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZEBRA
{
    /// <summary>
    /// データベースのopen/closeするクラスです.
    /// </summary>
    public class DbConnection
    {
        SqlConnection con = new SqlConnection();

        /// <summary>
        /// データベースに接続するクラスです（必ずクローズしてください！）.
        /// SqlDataReader型でreturnします
        /// </summary>
        public SqlDataReader dbConnect(string sql)
        {
            
            // DBへの接続文字列。
            con.ConnectionString = "data source=localhost\\SQLEXPRESS;" + // 接続先のDBサーバーを指定
                                   "initial catalog=testdb;" +            // 接続先のDBを指定
                                   "user id=sa;" +                        // ユーザー
                                   "password=p@ssw0rd;" +                 // パスワード
                                   "Connect Timeout=60;";
            try
            {
                con.Open();

                // コネクションオブジェクトを使用して、SQLの発行準備
                SqlCommand command = new SqlCommand(sql, con);

                // SQL文を実行。
                SqlDataReader reader = command.ExecuteReader();

                return reader;
            }
            catch (SqlException ex)
            {
                //thorowのほうがいいかも
                SqlDataReader notRead = null;
                Debug.WriteLine(ex.Message);


                return notRead;
            }
        }

        /// <summary>
        /// データベースをクローズします。
        /// </summary>
        public void dbClose()
        {
            con.Close();
        }

    }
}
