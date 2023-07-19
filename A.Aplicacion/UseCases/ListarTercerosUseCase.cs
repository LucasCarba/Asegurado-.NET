using A.Aplicacion.Entidades;
using A.Aplicacion.Interfaces;

namespace A.Aplicacion.UseCases;

public class ListarTercerosUseCase : TerceroUseCase
{

    public ListarTercerosUseCase(ITercero repositorio) : base(repositorio)
    {
    }
    public async Task<List<Tercero>> Ejecutar()
    {
        return await Repositorio.ListarTercero();
    }
}
