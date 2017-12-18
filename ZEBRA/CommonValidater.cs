using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZEBRA
{
    class CommonValidater
    {
        private string startDate;
        private string startHour;
        private string startMin;
        private string endDate;
        private string endHour;
        private string endMin;
        private string customerName;
        private string visitType;
        private string detail;
        private DateTime dt = DateTime.Now;
        private DateTime startDateAll;
        private DateTime endDateAll;

        //どこでエラーが引っ掛かったのかわかるようにエラーメッセージ用リストを作成
        private List<string> errorList = new List<string>();

        int resultDate;



        public CommonValidater(string startDate, string startHour,
             string startMin, string endDate, string endHour, string endMin, string customerName,
             string visitType, string detail)
        {
            this.startDate = startDate;
            this.startHour = startHour;
            this.startMin = startMin;
            this.endDate = endDate;
            this.endHour = endHour;
            this.endMin = endMin;
            this.customerName = customerName;
            this.visitType = visitType;
            this.detail = detail;
        }

        /// <summary>
        /// 日報作成・修正時の入力が正しいかチェックをする
        /// </summary>
        /// <returns>result 正常ならtrueを返却</returns>
        /// 
        public Boolean InputCheck()
        {
            Boolean result = true;

            if (startHour == null || startHour.Equals(""))
            {
                result = false;
                errorList.Add("・日時のFrom（時間）が未入力です");
            }

            if (startMin == null || startMin.Equals(""))
            {
                result = false;
                errorList.Add("・日時のFrom（分）が未入力です");
            }

            if (endHour == null || endHour.Equals(""))
            {
                result = false;
                errorList.Add("・日時のTo（時間）が未入力です");
            }

            if (endMin == null || endMin.Equals(""))
            {
                result = false;
                errorList.Add("・日時のTo（分）が未入力です");
            }
            
            if(result)
            {
                //日にち、時間、分をつなげてDateTime型をstartDateAllへ
                int startH = int.Parse(startHour);
                int startM = int.Parse(startMin);
                startDateAll = DateTime.Parse(startDate + " " + startH + ":" + startM);

                //日にち、時間、分をつなげてDateTime型をendDateAllへ
                int endH = int.Parse(endHour);
                int endM = int.Parse(endMin);
                endDateAll = DateTime.Parse(endDate + " " + endH + ":" + endM);


                //開始日時が未来にならないか
                resultDate = DateTime.Compare(startDateAll, dt);

                if (resultDate == 1)
                {
                    result = false;
                    errorList.Add("・訪問日時は現在日時以前の時間を指定してください");
                }
                else
                {
                    //終了が開始より前にならないか
                    if (endDateAll <= startDateAll)
                    {
                        result = false;
                        errorList.Add("・ToはFromより後の時間にしてください");
                    }

                }


            }             

            if (customerName == null || customerName.Equals(""))
            {
                result = false;
                ErrorList.Add("・訪問先の顧客を選択してください");
            }

            if (visitType == null || visitType.Equals(""))
            {
                result = false;
                ErrorList.Add("・訪問種別を選択してください");
            }



            if (detail == null || detail.Equals(""))
            {
                result = false;
                ErrorList.Add("・内容を入力してください");
            }


            return result;

           
        }


        public DateTime StartDateAll
        {
            get
            {
                return startDateAll;
            }
        }

        public DateTime EndDateAll
        {
            get
            {
                return endDateAll;
            }
        }

        public List<string> ErrorList
        {
            get
            {
                return errorList;
            }

        }
    }
}

