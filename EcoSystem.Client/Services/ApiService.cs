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
        var productos = await _http.GetFromJsonAsync<List<Producto>>("api/Productos");
        return productos ?? new List<Producto>();
    }

    public async Task<Producto?> CrearProductoAsync(Producto producto)
    {
        var response = await _http.PostAsJsonAsync("api/Productos", producto);

        if (!response.IsSuccessStatusCode)
            return null;

        return await response.Content.ReadFromJsonAsync<Producto>();
    }

    public async Task<bool> ActualizarProductoAsync(int id, Producto producto)
    {
        var response = await _http.PutAsJsonAsync($"api/Productos/{id}", producto);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> EliminarProductoAsync(int id)
    {
        var response = await _http.DeleteAsync($"api/Productos/{id}");
        return response.IsSuccessStatusCode;
    }
}