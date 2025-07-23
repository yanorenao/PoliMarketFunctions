using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PoliMarketFunctions.Models;
using PoliMarketFunctions.Database;

public static class RegistrarVenta
{
    [FunctionName("RegistrarVenta")]
    public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = "ventas")] HttpRequest req,
        ILogger log)
    {
        log.LogInformation("C# HTTP trigger - Registrando nueva venta.");

        string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        var venta = JsonConvert.DeserializeObject<Venta>(requestBody);

        // Buscar vendedor
        Vendedor vendedor = null;
        foreach (var v in InMemoryData.Vendedores)
        {
            if (v.Id == venta.VendedorId)
            {
                vendedor = v;
                break;
            }
        }

        if (vendedor == null || !vendedor.Autorizado)
        {
            return new UnauthorizedResult(); // El vendedor no existe o no está autorizado
        }

        // Aquí iría la lógica para validar productos, etc.
        log.LogInformation($"Venta registrada por {vendedor.Nombre} para el cliente {venta.Cliente}.");

        return new OkObjectResult(venta);
    }
}
