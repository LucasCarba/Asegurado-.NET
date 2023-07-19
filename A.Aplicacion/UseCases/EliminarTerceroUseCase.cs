using A.Aplicacion.Interfaces;

namespace A.Aplicacion.UseCases;
public class EliminarTerceroUseCase : TerceroUseCase
{
    public EliminarTerceroUseCase(ITercero repositorio) : base(repositorio)
    {
    }

    public async Task Ejecutar(int Id)
    {
        await Repositorio.Eliminar(Id);
    }
}
