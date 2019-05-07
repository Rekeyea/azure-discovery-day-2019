using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Arkano.Azure.Discovery.Day.Models;

namespace Arkano.Azure.Discovery.Day
{
    public static class SendMessage
    {
        [FunctionName("SendMessage")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            [CosmosDB(
                databaseName: "chats", 
                collectionName: "Items", 
                CreateIfNotExists=true,
                ConnectionStringSetting="CosmosDBConnectionString")] out dynamic document,
            ILogger log)
        {
            string requestBody = new StreamReader(req.Body).ReadToEnd();
            InputMessage inputMessage = JsonConvert.DeserializeObject<InputMessage>(requestBody);
            document = new SavedMessage{
                Id = Guid.NewGuid(),
                Message = inputMessage.Message,
                SentDate = inputMessage.SentDate,
                Username = inputMessage.Username
            };
            return new JsonResult(document);
        }
    }
}
