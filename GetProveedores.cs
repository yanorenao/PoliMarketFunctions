using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using PoliMarketFunctions.Database;

namespace PoliMarketFunctions
{
    public static class GetProveedores
    {
        [FunctionName("GetProveedores")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "proveedores")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request for suppliers.");
            return new OkObjectResult(InMemoryData.Proveedores);
        }
    }
}