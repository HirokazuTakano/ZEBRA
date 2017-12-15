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


            if (startDate == null || startDate.Equals(""))
            {
                result = false;
            }
            else if (startHour == null || startHour.Equals(""))
            {
                result = false;
            }

            else if (startMin == null || startMin.Equals(""))
            {
                result = false;
            }

            else if (endDate == null || endDate.Equals(""))
            {
                result = false;
            }

            else if (endHour == null || endHour.Equals(""))
            {
                result = false;
            }

            else if (endMin == null || endMin.Equals(""))
            {
                result = false;
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
                }
                else
                {
                    //終了が開始より前にならないか
                    if(endDateAll < StartDateAll)
                    {
                        result = false;
                    }

                }


            }


            if (customerName == null || customerName.Equals(""))
            {
                result = false;
            }

            if (visitType == null || visitType.Equals(""))
            {
                result = false;
            }



            if (detail == null || detail.Equals(""))
            {
                result = false;
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
    }
}

