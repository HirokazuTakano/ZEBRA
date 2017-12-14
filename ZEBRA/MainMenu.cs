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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            //// 接続用のクラス
            //SqlConnection con = new SqlConnection();

            //// DBへの接続文字列。
            //con.ConnectionString = "data source=localhost;" + // 接続先のDBサーバーを指定
            //                       "initial catalog=zebradb;" +            // 接続先のDBを指定
            //                       "user id=sa;" +                        // ユーザー
            //                       "password=p`ssw0rd;" +                 // パスワード
            //                       "Connect Timeout=60;";

            //// 問い合わせのSQLを生成
            //string sql =
            //    "SELECT * " +
            //      "FROM dbo.TM_DAILY_REPORT " +
            //     "ORDER BY REPORT_ID ";

            //// コネクションオブジェクトを使用して、SQLの発行準備
            //SqlCommand command = new SqlCommand(sql, con);


            //// アダプターを作成
            //SqlDataAdapter adapter = new SqlDataAdapter(command);
            //DataSet ds = new DataSet();
            //adapter.Fill(ds, "DS_REPORT");

            //List<string> reportlist = new List<string>();


            ////con.Open(); // DBに接続



            //// DataGridViewが持つ、列の自動生成機能をオフ
            //list.AutoGenerateColumns = false;

            //// DataGridViewのデータをセット
            //list.DataSource = ds;
            //list.DataMember = "DS_REPORT";

            //// 表示列を追加
            //list.Columns.Add("reportId", "ID");
            //list.Columns["reportId"].DataPropertyName = "REPORT_ID";

            //list.Columns.Add("createDate", "作成日");
            //list.Columns["createDate"].DataPropertyName = "CREATE_DATE";

            //list.Columns.Add("createdate", "作成者");
            //list.Columns["createdate"].DataPropertyName = "CREATE_DATE";

            ////list.Columns.Add("createdate", "顧客名");
            ////list.Columns["createdate"].DataPropertyName = "CREATE_DATE";

            //// ボタンを追加
            //DataGridViewButtonColumn button = new DataGridViewButtonColumn();
            //button.Name = "editButton";
            //button.HeaderText = "操作";
            //button.UseColumnTextForButtonValue = true;  // Textプロパティ値をボタンに表示させる。
            //button.Text = "詳細画面へ";
            //list.Columns.Add(button);
        }

        private void admitLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hide();
            AdmitList admitList = new AdmitList();
            admitList.Show(this);
            Debug.WriteLine("承認待ちリスト表示");
        }
    }
}

