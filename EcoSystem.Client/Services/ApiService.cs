using System.Net.Http.Json;
using EcoSystem.Client.Models;

namespace EcoSystem.Client.Services;

public class ApiService
{
    private readonly HttpClient _http;

    public ApiService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<Producto>> GetProductosAsync()
    {
        try
        {
            var response = await _http.GetAsync("api/Productos");

            // Si la API responde con error 400, 404, 500, etc.,
            // esta línea lanza una excepción.
            response.EnsureSuccessStatusCode();

            var productos = await response.Content.ReadFromJsonAsync<List<Producto>>();

            return productos ?? new List<Producto>();
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Error de red: {ex.Message}");
            return new List<Producto>();
        }
        catch (TaskCanceledException)
        {
            Console.WriteLine("Tiempo de espera agotado.");
            return new List<Producto>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error inesperado: {ex.Message}");
            return new List<Producto>();
        }
    }
}