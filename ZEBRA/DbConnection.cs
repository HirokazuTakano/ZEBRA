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
        /// </summary>
        public void dbConnect()
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

            } catch(SqlException ex)
            {
                Debug.WriteLine(ex.Message);
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
