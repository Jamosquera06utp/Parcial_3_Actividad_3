namespace Parcial_3_Actividad_2.Models;

/// <summary>Resultado devuelto por AuthService al intentar iniciar sesión.</summary>
public class ResultadoLogin
{
    public bool Exitoso { get; set; }
    public string Mensaje { get; set; } = string.Empty;
    public Usuario? Usuario { get; set; }
}
