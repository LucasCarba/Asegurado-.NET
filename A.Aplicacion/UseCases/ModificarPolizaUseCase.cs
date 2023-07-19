using A.Aplicacion.Entidades;
using A.Aplicacion.Interfaces;

namespace A.Aplicacion.UseCases;
public class ModificarPolizaUseCase : PolizaUseCase
{
       public ModificarPolizaUseCase(IPoliza repositorio) : base(repositorio)
    {
    }
    public async Task Ejecutar(Poliza p)
    {
        await Repositorio.Modificar(p);
    }
}
