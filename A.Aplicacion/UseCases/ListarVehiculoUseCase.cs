using A.Aplicacion.Entidades;
using A.Aplicacion.Interfaces;

namespace A.Aplicacion.UseCases;

public class ListarVehiculoUseCase : VehiculoUseCase
{

    public ListarVehiculoUseCase(IVehiculos repositorio) : base(repositorio)
    {
    }
    public async Task<List<Vehiculo>> Ejecutar()
    {
        return await Repositorio.ListarVehiculo();
    }
}
