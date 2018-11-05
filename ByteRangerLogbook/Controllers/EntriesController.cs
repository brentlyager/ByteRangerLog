using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ByteRangerLogbook.Data;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace ByteRangerLogbook.Controllers
{
    [Route("api/[controller]")]
    public class EntriesController : Controller
    {
        MongoContext _dbContext;

        public EntriesController()
        {
            _dbContext = new MongoContext();

            var document = _dbContext.Database.GetCollection<LogEntry>("LogEntries");
        }

        // GET api/entries
        [HttpGet]
        public IEnumerable<string> Get()
        {
            List<string> entries = new List<string>();

            IMongoCollection<LogEntry> collection = _dbContext.Database.GetCollection<LogEntry>("LogEntries");

            List<LogEntry> logEntries = collection.Find<LogEntry>(new BsonDocument()).ToList<LogEntry>();

            foreach (LogEntry entry in logEntries)
            {
                entries.Add(JsonConvert.SerializeObject(entry));
            }

            return entries;
        }

        // GET api/entries/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            IMongoCollection<LogEntry> collection = _dbContext.Database.GetCollection<LogEntry>("LogEntries");
            LogEntry entry = collection.Find<LogEntry>(le => le.ID == id).First<LogEntry>();

            return JsonConvert.SerializeObject(entry);
        }

        // POST api/entries
        [HttpPost]
        public void Post([FromBody]string value)
        {
            LogEntry newEntry = JsonConvert.DeserializeObject<LogEntry>(value);

            IMongoCollection<LogEntry> collection = _dbContext.Database.GetCollection<LogEntry>("LogEntries");
            collection.InsertOne(newEntry);
        }

        // PUT api/entries/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            LogEntry newEntry = JsonConvert.DeserializeObject<LogEntry>(value);
            newEntry.ID = id;

            IMongoCollection<LogEntry> collection = _dbContext.Database.GetCollection<LogEntry>("LogEntries");
            collection.InsertOne(newEntry);
        }

        // DELETE api/entries/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            IMongoCollection<LogEntry> collection = _dbContext.Database.GetCollection<LogEntry>("LogEntries");
            collection.FindOneAndDelete(le => le.ID == id);
        }
    }
}
