using A.Aplicacion.Entidades;
using A.Aplicacion.Interfaces;

namespace A.Aplicacion.UseCases;

public class ListarSiniestrosUseCase : SiniestroUseCase
{

    public ListarSiniestrosUseCase(ISiniestro repositorio) : base(repositorio)
    {
    }
    public async Task<List<Siniestro>> Ejecutar()
    {
        return  await Repositorio.ListarSiniestro();
    }
}
