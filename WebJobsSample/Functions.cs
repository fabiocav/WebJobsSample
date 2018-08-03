using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using WebJobsSample.Models;

namespace WebJobsSample
{
    public static class Functions
    {
        [Singleton]
        public static void BlobTrigger(
            [BlobTrigger("test")] string blob, ILogger logger)
        {
            logger.LogInformation("Processed blob: " + blob);
        }

        public static void BlobPoisonBlobHandler(
            [QueueTrigger("webjobs-blobtrigger-poison")] JObject blobInfo, ILogger logger)
        {
            string container = (string)blobInfo["ContainerName"];
            string blobName = (string)blobInfo["BlobName"];

            logger.LogInformation($"Poison blob: {container}/{blobName}");
        }

        public static void ProcessWorkItem(
            [QueueTrigger("test")] WorkItem workItem, ILogger logger)
        {
            logger.LogInformation($"Processed work item {workItem.Id}");
        }
    }
}
