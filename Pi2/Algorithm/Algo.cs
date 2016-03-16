using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2.Algo
{
    class Algo
    {
        public List<string> algo(int monthE, int montW)
        {
            List<string> result = new List<string>();
            Controller.MongoDBClient mdg = new Controller.MongoDBClient();
            DateTime dt = new DateTime(2000,01,01);


            List<View.view.TrioResult> eqt = mdg.getByMonth(dt);
            //cree une fonction de saut de mois



            return result;
        }

        public List<DateTime> jupMonthE(int monthE)
        {
            int nbd;
            nbd = monthE * 30;
            List<DateTime> rst = new List<DateTime>();
            System.DateTime dt = new DateTime(2000, 01, 01);
            System.DateTime Edt = new DateTime(2015, 01, 01);
            System.TimeSpan duration = new System.TimeSpan(nbd, 0, 0, 0);
            while (dt.CompareTo(Edt) > 0)
            {
                dt = dt.Add(duration);
                rst.Add(dt);
            }
            return rst;
        }

        public List<DateTime> jupMonthW(int monthW)
        {
            int nbd;
            nbd = monthW * 30;
            List<DateTime> rst = new List<DateTime>();
            System.DateTime dt = new DateTime(2000, 01, 01);
            System.DateTime Edt = new DateTime(2015, 01, 01);
            System.TimeSpan duration = new System.TimeSpan(nbd, 0, 0, 0);
            while(dt.CompareTo(Edt)>0)
            {
                dt=dt.Add(duration);
                rst.Add(dt);
            }
            return rst;
        }

        public DateTime Add
        (
            TimeSpan value
        );

        public static int Compare(
            DateTime t1,
            DateTime t2
        );
    }
}
