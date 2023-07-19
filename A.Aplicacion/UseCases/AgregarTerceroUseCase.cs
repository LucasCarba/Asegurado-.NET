using A.Aplicacion.Entidades;
using A.Aplicacion.Interfaces;

namespace A.Aplicacion.UseCases;
public class AgregarTerceroUseCase : TerceroUseCase
{
    public AgregarTerceroUseCase(ITercero repositorio) : base(repositorio)
    {
    }
    public async Task Ejecutar(Tercero t)
    {
            await Repositorio.Agregar(t);
    }
}
