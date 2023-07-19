using A.Aplicacion.Interfaces;

namespace A.Aplicacion.UseCases;

public class EliminarVehiculoUseCase : VehiculoUseCase
{
    public EliminarVehiculoUseCase(IVehiculos repositorio) : base(repositorio)
    {
    }

    public async Task Ejecutar(int Id)
    {
        await Repositorio.Eliminar(Id);
    }
}
