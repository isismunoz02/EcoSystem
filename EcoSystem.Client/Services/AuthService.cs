using System.Net;
using System.Net.Http.Json;
using EcoSystem.Client.Models;

namespace EcoSystem.Client.Services;

public class AuthService
{
    private readonly HttpClient _http;

    public AuthService(HttpClient http)
    {
        _http = http;
    }

    public async Task<LoginResult> LoginAsync(string username, string password)
    {
        var payload = new LoginRequest
        {
            Username = username,
            Password = password
        };

        var response = await _http.PostAsJsonAsync("api/auth/login", payload);

        return response.StatusCode switch
        {
            HttpStatusCode.OK => await CrearResultadoExitoso(response),

            HttpStatusCode.Unauthorized => new LoginResult
            {
                Success = false,
                ErrorMessage = "Usuario o contraseña incorrectos."
            },

            HttpStatusCode.BadRequest => new LoginResult
            {
                Success = false,
                ErrorMessage = "Debes ingresar usuario y contraseña."
            },

            _ => new LoginResult
            {
                Success = false,
                ErrorMessage = $"Error inesperado: {(int)response.StatusCode}"
            }
        };
    }

    private static async Task<LoginResult> CrearResultadoExitoso(HttpResponseMessage response)
    {
        var authResponse = await response.Content.ReadFromJsonAsync<AuthResponse>();

        return new LoginResult
        {
            Success = true,
            Token = authResponse?.Token,
            Expiration = authResponse?.Expiration
        };
    }
}