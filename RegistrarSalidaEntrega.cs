using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using PoliMarketFunctions.Database;
using PoliMarketFunctions.Models;

public static class RegistrarSalidaEntrega
{
    [FunctionName("RegistrarSalidaEntrega")]
    public static IActionResult Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "entregas/salida")] HttpRequest req,
        ILogger log)
    {
        // Ejemplo: /entregas/salida?productoId=101&cantidad=1&ventaId=1
        int productoId = int.Parse(req.Query["productoId"]);
        int cantidad = int.Parse(req.Query["cantidad"]);
        int ventaId = int.Parse(req.Query["ventaId"]);

        log.LogInformation($"Entregas se comunica con Ventas para la venta {ventaId}.");

        // Buscar producto
        Producto producto = null;
        foreach (var p in InMemoryData.Productos)
        {
            if (p.Id == productoId)
            {
                producto = p;
                break;
            }
        }

        if (producto == null || producto.CantidadEnStock < cantidad)
        {
            return new BadRequestObjectResult("Producto no encontrado o sin stock suficiente.");
        }

        // Entregas se comunica con Bodega para registrar la salida
        log.LogInformation($"Entregas se comunica con Bodega para registrar la salida del producto {producto.Nombre}.");
        producto.CantidadEnStock -= cantidad;

        log.LogInformation($"Salida registrada. Nuevo stock de {producto.Nombre}: {producto.CantidadEnStock}.");

        return new OkObjectResult($"Entrega para la venta {ventaId} procesada. Stock actualizado.");
    }
}
