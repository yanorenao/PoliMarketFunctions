namespace PoliMarketFunctions.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Autorizado { get; set; } = false;
    }
}