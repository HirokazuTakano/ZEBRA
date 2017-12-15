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


        public Boolean InputCheck()
        {
            Boolean result = true;

            if (startHour == null || startHour.Equals(""))
            {
                result = false;
                ErrorList.Add("startHour");
            }

            else if (startMin == null || startMin.Equals(""))
            {
                result = false;
                ErrorList.Add("startMin");
            }

            else if (endHour == null || endHour.Equals(""))
            {
                result = false;
                ErrorList.Add("endHour");
            }

            else if (endMin == null || endMin.Equals(""))
            {
                result = false;
                ErrorList.Add("endMin");
            }
            else
            {

                //日にち、時間、分をつなげてDateTime型をstartDateAllへ
                int startH = int.Parse(startHour);
                int startM = int.Parse(startMin);
                DateTime visitStart = DateTime.Parse(startDate + " " + startH + ":" + startM);
                startDateAll = visitStart;

                //日にち、時間、分をつなげてDateTime型をendDateAllへ
                int endH = int.Parse(endHour);
                int endM = int.Parse(endMin);
                DateTime visitEnd = DateTime.Parse(endDate + " " + endH + ":" + endM);
                endDateAll = visitEnd;


                //開始日時が未来にならないか
                resultDate = DateTime.Compare(startDateAll, dt);

                if (resultDate == 1)
                {
                    result = false;
                    ErrorList.Add("fromFuture");
                }
                else
                {
                    //終了が開始より前にならないか
                    if(endDateAll < StartDateAll)
                    {
                        result = false;
                        ErrorList.Add("endFuture");
                    }

                }


            }


            if (customerName == null || customerName.Equals(""))
            {
                result = false;
                ErrorList.Add("customerName");
            }

            if (visitType == null || visitType.Equals(""))
            {
                result = false;
                ErrorList.Add("visitType");
            }



            if (detail == null || detail.Equals(""))
            {
                result = false;
                ErrorList.Add("detail");
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

            set
            {
                errorList = value;
            }
        }
    }
}

