using Parcial_3_Actividad_2.Data;
using Parcial_3_Actividad_2.Models;

namespace Parcial_3_Actividad_2.Services;

/// <summary>Lógica de registro e inicio de sesión.</summary>
public class AuthService
{
    private readonly UsuarioRepository _usuarios = new();
    private readonly IntentoLoginRepository _intentos = new();
    private readonly PasswordHasher _hasher = new();

    public (bool ok, string mensaje, string hash) Registrar(string nombreUsuario, string nombreCompleto, string password)
    {
        if (string.IsNullOrWhiteSpace(nombreUsuario) || string.IsNullOrWhiteSpace(password))
            return (false, "Usuario y contraseña son obligatorios.", "");

        if (_usuarios.ExisteUsuario(nombreUsuario.Trim()))
            return (false, "Ese nombre de usuario ya existe.", "");

        var usuario = new Usuario
        {
            NombreUsuario = nombreUsuario.Trim(),
            NombreCompleto = nombreCompleto.Trim(),
            PasswordHash = _hasher.GenerarHash(password)   // se guarda el hash, nunca la clave
        };

        _usuarios.Insertar(usuario);
        return (true, "Usuario registrado. Hash BCrypt guardado en la BD.", usuario.PasswordHash);
    }

    public ResultadoLogin IniciarSesion(string nombreUsuario, string password)
    {
        var usuario = _usuarios.ObtenerPorNombreUsuario(nombreUsuario.Trim());

        bool exitoso = usuario != null && _hasher.Verificar(password, usuario.PasswordHash);

        // Se registra SIEMPRE el intento (exitoso o fallido) para análisis posterior
        _intentos.Registrar(new IntentoLogin
        {
            UsuarioId = usuario?.Id,
            NombreUsuario = nombreUsuario.Trim(),
            Exitoso = exitoso
        });

        return exitoso
            ? new ResultadoLogin { Exitoso = true, Usuario = usuario, Mensaje = $"¡Acceso exitoso! Bienvenido, {usuario!.NombreCompleto} ({usuario.NombreUsuario})." }
            : new ResultadoLogin { Exitoso = false, Mensaje = "Usuario o contraseña incorrectos." };
    }

    public List<IntentoLogin> ObtenerIntentos() => _intentos.ListarTodos();
}
