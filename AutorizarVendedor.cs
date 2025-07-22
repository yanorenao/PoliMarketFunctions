using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Linq;
using PoliMarketFunctions.Database;

public static class AutorizarVendedor
{
    [FunctionName("AutorizarVendedor")]
    public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = "vendedores/{id}/autorizar")] HttpRequest req,
        int id,
        ILogger log)
    {
        log.LogInformation($"C# HTTP trigger - Autorizando vendedor {id}");

        var vendedor = InMemoryData.Vendedores.FirstOrDefault(v => v.Id == id);

        if (vendedor == null)
        {
            return new NotFoundObjectResult($"Vendedor con ID {id} no encontrado.");
        }

        vendedor.Autorizado = true;
        log.LogInformation($"Vendedor {vendedor.Nombre} ha sido autorizado por Recursos Humanos.");

        return new OkObjectResult(vendedor);
    }
}