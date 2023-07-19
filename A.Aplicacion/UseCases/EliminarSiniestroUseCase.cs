using A.Aplicacion.Interfaces;

namespace A.Aplicacion.UseCases;
public class EliminarSiniestroUseCase : SiniestroUseCase
{
    public EliminarSiniestroUseCase(ISiniestro repositorio) : base(repositorio)
    {
    }

    public async Task Ejecutar(int Id)
    {
        await Repositorio.Eliminar(Id);
    }
}
