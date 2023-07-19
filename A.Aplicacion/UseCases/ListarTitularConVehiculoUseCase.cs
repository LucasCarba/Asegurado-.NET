using A.Aplicacion.Entidades;
using A.Aplicacion.Interfaces;

namespace A.Aplicacion.UseCases;

public class ListarTitularConVehiculoUseCase : TitularUseCase
{

    public ListarTitularConVehiculoUseCase(ITitular repositorio) : base(repositorio)
    {
    }
    public List<Titular> Ejecutar(List<Vehiculo> vehiculos)
    {
        return  Repositorio.ListarTitularVehiculo(vehiculos); 
    }
}
