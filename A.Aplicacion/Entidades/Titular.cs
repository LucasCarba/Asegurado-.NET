namespace A.Aplicacion.Entidades;

public class Titular : Persona
{
    public string? Direccion { get; set; }
    public string? CorreoElectronico { get; set; }
    public List<Vehiculo> vehiculos { get; set; } = new List<Vehiculo>();
}

