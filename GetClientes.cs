using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using PoliMarketFunctions.Database; // Importante para acceder a tus datos

namespace PoliMarketFunctions
{
    public static class GetClientes
    {
        [FunctionName("GetClientes")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "clientes")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger: Se solicitó la lista de clientes.");

            // Devuelve la lista de clientes desde la clase de datos en memoria
            return new OkObjectResult(InMemoryData.Clientes);
        }
    }
}