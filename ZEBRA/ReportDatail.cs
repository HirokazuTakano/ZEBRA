using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZEBRA
{
    /// <summary>
    /// 日報の詳細を表示させます　犬伏
    /// </summary>
    public partial class ReportDatail : Form
    {
        public ReportDatail()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 詳細へというボタンを押下すると、親から引き継いだ値をラベルに入力する.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SetData(string fill, string visitDate, string visitTo, string visitType, string content)
        {
            this.fillDate.Text = fill;
            this.visitDate.Text = visitDate;
            this.visitTo.Text = visitTo;
            this.visitType.Text = visitType;
            this.content.Text = content;
        }

        private void ReportDatail_Load(object sender, EventArgs e)
        {

        }
    }
}
