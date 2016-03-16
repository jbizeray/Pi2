using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace ConsoleApplication2.Controller
{
    class YQLClient
    {
        public static List<HistoricalStock> DowloadData(string ticker, int startDate, int endDate)
        {
            List<HistoricalStock> retval = new List<HistoricalStock>();

            using (WebClient web = new WebClient())
            {
                string row = web.DownloadString(string.Format("http://ichart.finance.yahoo.com/table.csv?s={0}&a=00&b=01&c={1}&d=00&e=01&f={2}&g=w&ignore=.csv", ticker, startDate,endDate));
              
                string[] rows = row.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
               
                for (int i = 1; i < rows.Length-1; i++)
                {

                    string[] cols = rows[i].Split(',');
                    //cols[1] = cols[1].Replace(".", ",");
                    //cols[2] = cols[2].Replace(".", ",");
                    //cols[3] = cols[3].Replace(".", ",");
                    cols[4] = cols[4].Replace(".", ",");
                    //cols[5] = cols[5].Replace(".", ",");
                    //cols[6] = cols[6].Replace(".", ",");
                    HistoricalStock hs = new HistoricalStock();
                    hs.Date = Convert.ToDateTime(cols[0]);
                    //hs.Open = Convert.ToDouble(cols[1]);
                    //hs.High = Convert.ToDouble(cols[2]);
                    //hs.Low = Convert.ToDouble(cols[3]);
                    hs.Close = Convert.ToDouble(cols[4]);
                    //hs.Volume = Convert.ToDouble(cols[5]);
                    //hs.AdjClose = Convert.ToDouble(cols[6]);

                    retval.Add(hs);
                }
                return retval;
            }

        }



        [JsonObject(MemberSerialization.OptIn)]
        public class HistoricalStock
        {
            [JsonProperty("Date")]
            public DateTime Date { get; set; }
            //[JsonProperty("Open")]
            //public double Open { get; set; }
            //[JsonProperty("High")]
            //public double High { get; set; }
            //[JsonProperty("Low")]
            //public double Low { get; set; }
            [JsonProperty("Close")]
            public double Close { get; set; }
            //[JsonProperty("Volume")]
            //public double Volume { get; set; }
            //[JsonProperty("AdjClose")]
            //public double AdjClose { get; set; }
        }
    }
}
