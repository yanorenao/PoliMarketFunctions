using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using PoliMarketFunctions.Database;
using PoliMarketFunctions.Models;

public static class RegistrarCompraProveedor
{
    [FunctionName("RegistrarCompraProveedor")]
    public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "bodega/entradas")] HttpRequest req,
        ILogger log)
    {
        log.LogInformation("C# HTTP trigger - Bodega registrando entrada de productos.");

        // Ejemplo: /bodega/entradas?productoId=101&cantidad=10&proveedor=TechSupplier
        string productoIdStr = req.Query["productoId"];
        string cantidadStr = req.Query["cantidad"];
        string proveedor = req.Query["proveedor"];

        int.TryParse(productoIdStr, out int productoId);
        int.TryParse(cantidadStr, out int cantidad);

        // Buscar el producto
        Producto producto = null;
        foreach (var p in InMemoryData.Productos)
        {
            if (p.Id == productoId)
            {
                producto = p;
                break;
            }
        }

        if (producto == null)
        {
            return new NotFoundObjectResult("Producto no encontrado.");
        }

        producto.CantidadEnStock += cantidad;
        log.LogInformation($"Bodega se conecta con Proveedores: Se registraron {cantidad} unidades del producto {producto.Nombre} del proveedor {proveedor}. Nuevo stock: {producto.CantidadEnStock}.");

        return new OkObjectResult(producto);
    }
}
