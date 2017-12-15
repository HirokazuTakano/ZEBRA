using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZEBRA
{
    class CommonValidater
    {
        private DateTime createDate;
        private DateTime startDate;
        private string startHour;
        private string startMin;
        private DateTime endDate;
        private string endHour;
        private string endMin;
        private string customerName;
        private string visitType;
        private string detail;
        private DateTime dt = DateTime.Now;
        private DateTime startDateAll;
        private DateTime endDateAll;

        int resultDate;



        public CommonValidater(DateTime startDate, string startHour,
            string startMin, DateTime endDate, string endHour, string endMin, string customerName,
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
                string str = startDate.ToString() + "" + startHour + ":" + startMin + ":" + "00";

                startDateAll = DateTime.Parse(str);

                //日にち、時間、分をつなげてDateTime型をendDateAllへ
                string str2 = endDate.ToString() + "" + endHour + ":" + endMin + ":" + "00";

                endDateAll = DateTime.Parse(str2);


                //開始日時が未来にならないか
                resultDate = DateTime.Compare(startDateAll, dt);

                if (resultDate == 1)
                {
                    result = false;
                }
                else
                {
                    //終了が開始より前にならないか
                    resultDate = DateTime.Compare(endDateAll, startDateAll);
                    if (resultDate == 1)
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

