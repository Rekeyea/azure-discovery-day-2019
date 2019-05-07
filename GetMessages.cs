using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using Arkano.Azure.Discovery.Day.Models;

namespace Arkano.Azure.Discovery.Day
{
    public static class GetMessages
    {
        [FunctionName("GetMessages")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            [CosmosDB(
                databaseName: "chats",
                collectionName: "Items",
                ConnectionStringSetting="CosmosDBConnectionString",
                SqlQuery="SELECT * FROM c order by c._ts desc"
            )]IEnumerable<SavedMessage> messages,
            ILogger log)
        {
            return new JsonResult(messages);    
        }
    }
}
