using A.Aplicacion.Interfaces;

namespace A.Aplicacion.UseCases;
public class EliminarPolizaUseCase : PolizaUseCase
{
    public EliminarPolizaUseCase(IPoliza repositorio) : base(repositorio)
    {
    }

    public async Task Ejecutar(int Id)
    {
        await Repositorio.Eliminar(Id);
    }
}
