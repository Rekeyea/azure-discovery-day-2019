using System.Collections.Generic;
using System.Threading.Tasks;
using Arkano.Azure.Discovery.Day.Models;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Arkano.Azure.Discovery.Day
{
    public static class OnMessageCreated
    {
        [FunctionName("OnMessageCreated")]
        public static async Task Run([CosmosDBTrigger(
            databaseName: "chats",
            collectionName: "Items",
            ConnectionStringSetting = "CosmosDBConnectionString",
            LeaseCollectionName = "leases",
            CreateLeaseCollectionIfNotExists=true)]IReadOnlyList<Document> input,
            [SignalR(
                HubName = "chat",
                ConnectionStringSetting="AzureSignalRConnectionString"
            )]IAsyncCollector<SignalRMessage> signalRMessages,
            ILogger log)
        {
            if (input != null && input.Count > 0)
            {
                log.LogInformation("Documents modified " + input.Count);
                log.LogInformation("First document Id " + input[0].Id);
                foreach (var doc in input)
                {
                    await signalRMessages.AddAsync(new SignalRMessage
                    {
                        Target = "newMessage",
                        Arguments = new object[] { doc }
                    });
                }
            }
        }
    }
}
