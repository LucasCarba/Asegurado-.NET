using A.Aplicacion.Entidades;
using A.Aplicacion.Interfaces;

namespace A.Aplicacion.UseCases;

public class ListarTitularesUseCase : TitularUseCase
{

    public ListarTitularesUseCase(ITitular repositorio) : base(repositorio)
    {
    }
    public async Task<List<Titular>> Ejecutar()
    {
        return await Repositorio.ListarTitular();
    }
}
