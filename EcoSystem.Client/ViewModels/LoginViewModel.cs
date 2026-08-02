namespace EcoSystem.Client.ViewModels;

public class LoginViewModel
{
    public string NombreUsuario { get; set; } = string.Empty;

    public string Contrasena { get; set; } = string.Empty;

    public string MensajeError { get; set; } = string.Empty;

    public string MensajeResultado { get; set; } = string.Empty;

    public bool TieneError => !string.IsNullOrWhiteSpace(MensajeError);

    public void IniciarSesion()
    {
        MensajeError = string.Empty;
        MensajeResultado = string.Empty;

        if (string.IsNullOrWhiteSpace(NombreUsuario))
        {
            MensajeError = "Debes ingresar un nombre de usuario.";
            return;
        }

        if (string.IsNullOrWhiteSpace(Contrasena))
        {
            MensajeError = "Debes ingresar una contraseña.";
            return;
        }

        MensajeResultado = $"Bienvenido, {NombreUsuario}.";
    }

    public void VerificarBinding()
    {
        MensajeError = string.Empty;

        MensajeResultado =
            $"Binding activo ✓ Usuario: {NombreUsuario} | Contraseña: {new string('*', Contrasena.Length)}";
    }
}