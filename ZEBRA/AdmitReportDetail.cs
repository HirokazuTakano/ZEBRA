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
    public partial class AdmitReportDetail : Form
    {
        public AdmitReportDetail()
        {
            InitializeComponent();
        }


        //親画面からアクセスできるプロパティを作る----
        private String _date;
        private String _visit;
        private String _visitTo;
        private String _type;
        private String _content;

        public String Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
            }
        }

        public string Visit
        {
            get
            {
                return _visit;
            }

            set
            {
                _visit = value;
            }
        }

        public string VisitTo
        {
            get
            {
                return _visitTo;
            }

            set
            {
                _visitTo = value;
            }
        }

        public string Type
        {
            get
            {
                return _type;
            }

            set
            {
                _type = value;
            }
        }

        public string Content
        {
            get
            {
                return _content;
            }

            set
            {
                _content = value;
            }
        }

        private void AdmitReportDetail_Load(object sender, EventArgs e)
        {
            this.fillDate.Text = _date;
            this.visitDate.Text = _visit;
            this.visitTo.Text = _visitTo;
            this.visitType.Text = _type;
            this.content.Text = _content;


       


    }

        private void admitButton_Click(object sender, EventArgs e)
        {
            if (status.Text.Equals("承認"))
            {

            }
            if (status.Text.Equals("承認不可"))
            {

            }
            else
            {
                MessageBox.Show("ステータスを選択してください");

            }
        }
    }
}
