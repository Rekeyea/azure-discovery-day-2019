using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;

namespace Arkano.Azure.Discovery.Day
{
    public static class SignalRInfo
    {
        [FunctionName("SignalRInfo")]
        public static SignalRConnectionInfo Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            [SignalRConnectionInfo(HubName = "chat")]SignalRConnectionInfo connectionInfo,
            ILogger log)
        {
            return connectionInfo;    
        }
    }
}
