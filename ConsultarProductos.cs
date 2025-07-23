using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using PoliMarketFunctions.Database;

public static class ConsultarProductos
{
    [FunctionName("ConsultarProductos")]
    public static IActionResult Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "productos")] HttpRequest req,
        ILogger log)
    {
        log.LogInformation("C# HTTP trigger - Consultando productos disponibles desde Ventas.");

        // Simula la comunicación de Ventas a Bodega
        log.LogInformation("Ventas se conecta con Bodega para ver la disponibilidad.");
        var productosDisponibles = InMemoryData.Productos;

        return new OkObjectResult(productosDisponibles);
    }
}