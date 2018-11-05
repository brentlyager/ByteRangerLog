using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;

namespace ByteRangerLogbook
{
    public class MongoContext
    {
        MongoClient _client;
        public IMongoDatabase Database;

        public MongoContext()
        {
            string mongoDatabaseName = "ByteRangerLog";
            string mongoUsername = "demouser";
            string mongoPassword = "Pass@123";
            string mongoPort = "27017";
            string mongoHost = "localhost";

            var credential = MongoCredential.CreateCredential
                            (mongoDatabaseName,
                             mongoUsername,
                             mongoPassword);

            // Creating MongoClientSettings  
            var settings = new MongoClientSettings
            {
                Credential = credential,
                Server = new MongoServerAddress(mongoHost, Convert.ToInt32(mongoPort))
            };
            _client = new MongoClient(settings);
            Database = _client.GetDatabase(mongoDatabaseName);
        }
    }
}
