namespace Parcial_3_Actividad_2.Services;

/// <summary>Encapsula el uso de BCrypt.Net-Next (hash y verificación).</summary>
public class PasswordHasher
{
    private const int WorkFactor = 12;

    /// <summary>Genera el hash BCrypt (incluye salt automáticamente).</summary>
    public string GenerarHash(string passwordPlano)
    {
        return BCrypt.Net.BCrypt.HashPassword(passwordPlano, WorkFactor);
    }

    /// <summary>Verifica la contraseña original contra el hash guardado.</summary>
    public bool Verificar(string passwordPlano, string hashGuardado)
    {
        return BCrypt.Net.BCrypt.Verify(passwordPlano, hashGuardado);
    }
}
