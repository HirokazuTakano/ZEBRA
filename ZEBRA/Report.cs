using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZEBRA
{
    /// <summary>
    /// 日報クラス　高野
    /// </summary>
    public class Report
    {
        private readonly int reportId; // 日報ID
        private DateTime createDate; // 作成日時
        private DateTime updateDate; // 更新日時
        private DateTime visitStratDate; // 訪問開始日時
        private DateTime visitEndDate;　　// 訪問終了日時
        private string visittype;　　　　// 訪問種別
        private string detaile;         //本文
        private readonly string cusId;          //顧客ID 
        private int approvalstatus;    // 承認フラグ
        private readonly string autherId;       // 作成者ID
        private readonly string bossId;         // 上司ID
        private string bossSei;        // 上司姓
        private string bossMei;        //　上司名
        private string bosscomment;    //　上司コメント


        public Report(int reportId, DateTime createDate, DateTime updateDate, DateTime visitStratDate, DateTime visitEndDate
                     , string visittype, string detaile, string cusId, int approvalstatus, string autherId, string bossId
                     , string bossSei, string bossMei, string bosscomment)
        {
            this.reportId = reportId;
            this.createDate = createDate;
            this.updateDate = updateDate;
            this.visitStratDate = visitStratDate;
            this.visitEndDate = visitEndDate;
            this.visittype = visittype;
            this.detaile = detaile;
            this.cusId = cusId;
            this.autherId = autherId;
            this.bossId = bossId;
            this.bossSei = bossSei;
            this.bossMei = bossMei;
            this.bosscomment = bosscomment;


        }



        public int ReportId
        {
            get
            {
                return reportId;
            }
        }


        public DateTime CreateDate
        {
            get
            {
                return createDate;
            }
            set
            {
                createDate = value;
            }
        }


        public DateTime UpdateDate
        {
            get
            {
                return updateDate;
            }
            set
            {
                updateDate = value;
            }
        }

        public DateTime VisitStratDate
        {
            get
            {
                return visitStratDate;
            }
            set
            {
                visitStratDate = value;
            }
        }

        public DateTime VisitEndDate
        {
            get
            {
                return visitEndDate;
            }
            set
            {
                visitEndDate = value;
            }
        }


        public string Detaile
        {
            get
            {
                return detaile;
            }
            set
            {
                detaile = value;
            }
        }


        public string Visittype
        {
            get
            {
                return visittype;
            }
            set
            {
                visittype = value;
            }
        }

        public string CusId
        {
            get
            {
                return cusId;
            }
        }


        public int Approvalstatus
        {
            get
            {
                return approvalstatus;
            }
            set
            {
                approvalstatus = value;
            }
        }



        public string AutherId
        {
            get
            {
                return autherId;
            }
        }

        public string BossId
        {
            get
            {
                return bossId;
            } 
        }

        public string BossSei
        {
            get
            {
                return bossSei;
            }
            set
            {
                bossSei = value;
            }
        }

        public string BossMei
        {
            get
            {
                return bossMei;
            }
            set
            {
                bossMei = value;
            }
        }

        public string Bsscomment
        {
            get
            {
                return bosscomment;
            }
            set
            {
                bosscomment = value;
            }
        }


        



    }
}
