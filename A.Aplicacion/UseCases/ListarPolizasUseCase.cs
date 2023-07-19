using A.Aplicacion.Entidades;
using A.Aplicacion.Interfaces;

namespace A.Aplicacion.UseCases;

public class ListarPolizasUseCase : PolizaUseCase
{

    public ListarPolizasUseCase(IPoliza repositorio) : base(repositorio)
    {
    }
    public async Task<List<Poliza>> Ejecutar()
    {
        return  await Repositorio.ListarPoliza();
    }
}
