namespace Parcial_3_Actividad_2.Models;

/// <summary>Representa un registro de la tabla Usuarios.</summary>
public class Usuario
{
    public int Id { get; set; }
    public string NombreUsuario { get; set; } = string.Empty;
    public string NombreCompleto { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public DateTime FechaCreacion { get; set; }
}
