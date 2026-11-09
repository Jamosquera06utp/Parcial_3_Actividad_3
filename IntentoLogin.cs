namespace Parcial_3_Actividad_2.Models;

/// <summary>Representa un registro de la tabla IntentosLogin (para análisis posterior).</summary>
public class IntentoLogin
{
    public int Id { get; set; }
    public int? UsuarioId { get; set; }          // null si el usuario no existe
    public string NombreUsuario { get; set; } = string.Empty;
    public bool Exitoso { get; set; }
    public DateTime FechaIntento { get; set; }
}
