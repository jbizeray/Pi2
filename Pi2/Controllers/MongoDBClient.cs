using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;
using System.Web.Script.Serialization;
using System.IO;
using System.Runtime.Serialization;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApplication2.Controller
{
    class MongoDBClient
    {
        protected static IMongoClient _client;
        protected string connectionString;
        protected static IMongoDatabase _database;

        public MongoDBClient()
        {
            try
            {
                this.connectionString = "mongodb://groupemomentum1:groupemomentum1@ds037215.mongolab.com:37215/groupemomentum1";
                _client = new MongoClient(this.connectionString);
                _database = _client.GetDatabase("groupemomentum1");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void LoadData(string path)
        {
            List<string> tickers = getTickers(path);
            YQLClient yqlClt = new YQLClient();
            foreach(string ticker in tickers)
            {
                View.view.TickerHistoricalPrice tkt = new
                View.view.TickerHistoricalPrice();
                List<Controller.YQLClient.HistoricalStock> data = Controller.YQLClient.DowloadData(ticker, 2000, 2015);
                tkt.Name = ticker;
                foreach (Controller.YQLClient.HistoricalStock stock in data)
                {
                    tkt.HistoricalPrice.Add(stock);
                }


                insertData(tkt);
            }
        }

        public void insertData(
                View.view.TickerHistoricalPrice obj)
        {
            try
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                var collection = _database.GetCollection<BsonDocument>("stockCollection");
                string str = ser.Serialize(obj);
                BsonDocument bson = BsonDocument.Parse(str);
                collection.InsertOneAsync(bson);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private List<string> getTickers(string path)
        {
            List<string> tickers = new List<string>();
            System.IO.StreamReader file =new System.IO.StreamReader(path);
            String line;
            while ((line = file.ReadLine()) != null)
            {
                tickers.Add(line);   
            }
            file.Close();
            return tickers;

        }

        public List<View.view.TrioResult> getByMonth(DateTime date)
        {
            List<View.view.TrioResult> result = new List<View.view.TrioResult>();
            var collection = _database.GetCollection<BsonDocument>("stockCollection");
            var filter = new BsonDocument();
            return result;
        }


        
    }
}
