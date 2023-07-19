using A.Aplicacion.Interfaces;

namespace A.Aplicacion.UseCases;
public class EliminarTitularUseCase : TitularUseCase
{
    public EliminarTitularUseCase(ITitular repositorio) : base(repositorio)
    {
    }

    public async Task Ejecutar(int Id)
    {
        await Repositorio.Eliminar(Id);
    }
}
