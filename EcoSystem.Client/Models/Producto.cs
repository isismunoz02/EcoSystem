using System.Text.Json.Serialization;

namespace EcoSystem.Client.Models;

public class Producto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("categoriaId")]
    public int CategoriaId { get; set; }

    [JsonPropertyName("nombre")]
    public string Nombre { get; set; } = string.Empty;

    [JsonPropertyName("descripcion")]
    public string Descripcion { get; set; } = string.Empty;

    [JsonPropertyName("precio")]
    public decimal Precio { get; set; }

    [JsonPropertyName("stock")]
    public int Stock { get; set; }

    [JsonPropertyName("sku")]
    public string SKU { get; set; } = string.Empty;
}