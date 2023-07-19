using A.Aplicacion.Entidades;
using A.Aplicacion.Interfaces;

namespace A.Aplicacion.UseCases;
public class AgregarPolizaUseCase : PolizaUseCase
{
    public AgregarPolizaUseCase(IPoliza repositorio) : base(repositorio)
    {
    }
    public async Task Ejecutar(Poliza p)
    {
            await Repositorio.Agregar(p);
    }
}
