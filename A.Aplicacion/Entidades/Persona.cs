namespace A.Aplicacion.Entidades;

public abstract class Persona
{
    public int Id { get; set; }
    public int DNI { get; set; }
    public string? Apellido { get; set; }
    public string? Nombre { get; set; }
    public string? Telefono { get; set; }
    
    public override string ToString()
    {
        return $"{Apellido}, {Nombre}";
    }
}

