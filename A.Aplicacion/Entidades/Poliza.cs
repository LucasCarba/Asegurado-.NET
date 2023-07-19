namespace A.Aplicacion.Entidades;
public class Poliza
{
    public int Id { get; set; }
    public int VehiculoId { get; set; }
    public decimal ValorAsegurado { get; set; }
    public decimal Franquicia { get; set; }
    public string? TipoCobertura { get; set; }
    public DateTime  FechaInicioVigencia { get; set; }
    public DateTime  FechaFinVigencia { get; set; }

     
    public override string ToString()
    {
        return $"{VehiculoId}, {ValorAsegurado}, {Franquicia}, {TipoCobertura}";
    }
}
