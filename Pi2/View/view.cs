using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2.View
{
    class view
    {
        [JsonObject(MemberSerialization.OptIn)]
        public class TickerHistoricalPrice
        {
            [JsonProperty("Name")]
            public string Name { get; set; }
            [JsonProperty("HistoricalPrice")]
            public List<Controller.YQLClient.HistoricalStock> HistoricalPrice { get; set; }
            public TickerHistoricalPrice()
            {
                HistoricalPrice = new List<Controller.YQLClient.HistoricalStock>();
            }
        }


        [JsonObject(MemberSerialization.OptIn)]
        public class TrioResult
        {
            [JsonProperty("Name")]
            public string Name { get; set; }
            [JsonProperty("Date")]
            public DateTime Date { get; set; }
            [JsonProperty("Close")]
            public double Close { get; set; }
        }

    }
}
