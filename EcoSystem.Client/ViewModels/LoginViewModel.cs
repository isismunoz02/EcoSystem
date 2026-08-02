using EcoSystem.Client.Services;

namespace EcoSystem.Client.ViewModels;

public class LoginViewModel
{
    private readonly AuthService _authService;

    public LoginViewModel(AuthService authService)
    {
        _authService = authService;
    }

    public string NombreUsuario { get; set; } = string.Empty;
    public string Contrasena { get; set; } = string.Empty;

    public string MensajeError { get; set; } = string.Empty;
    public string MensajeResultado { get; set; } = string.Empty;
    public string TokenMensaje { get; set; } = string.Empty;

    public DateTime? Expiration { get; set; }

    public bool TieneError => !string.IsNullOrWhiteSpace(MensajeError);
    public bool LoginExitoso => !string.IsNullOrWhiteSpace(TokenMensaje);

    public async Task IniciarSesionAsync()
    {
        MensajeError = string.Empty;
        MensajeResultado = string.Empty;
        TokenMensaje = string.Empty;
        Expiration = null;

        if (string.IsNullOrWhiteSpace(NombreUsuario))
        {
            MensajeError = "Debes ingresar un usuario.";
            return;
        }

        if (string.IsNullOrWhiteSpace(Contrasena))
        {
            MensajeError = "Debes ingresar una contraseña.";
            return;
        }

        var resultado = await _authService.LoginAsync(NombreUsuario, Contrasena);

        if (!resultado.Success)
        {
            MensajeError = resultado.ErrorMessage ?? "No se pudo iniciar sesión.";
            return;
        }

        MensajeResultado = "Inicio de sesión exitoso ✓";
        TokenMensaje = "Token recibido correctamente.";
        Expiration = resultado.Expiration;
    }

    public void VerificarBinding()
    {
        MensajeError = string.Empty;
        MensajeResultado =
            $"Binding activo ✓ Usuario: {NombreUsuario} | Contraseña: {new string('*', Contrasena.Length)}";
    }
}