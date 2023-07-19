using A.Aplicacion.Entidades;
using A.Aplicacion.Interfaces;

namespace A.Aplicacion.UseCases;

public class AgregarVehiculoUseCase : VehiculoUseCase
{
    public AgregarVehiculoUseCase(IVehiculos repositorio) : base(repositorio)
    {
    }
    public async Task Ejecutar(Vehiculo v)
    {
        await Repositorio.Agregar(v);
    }
}
