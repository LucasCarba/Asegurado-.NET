using A.Aplicacion.Entidades;
using A.Aplicacion.Interfaces;

namespace A.Aplicacion.UseCases;
public class ModificarVehiculoUseCase : VehiculoUseCase
{
       public ModificarVehiculoUseCase(IVehiculos repositorio) : base(repositorio)
    {
    }
    public async Task Ejecutar(Vehiculo v)
    {
        await Repositorio.Modificar(v);
    }
}
