using A.Aplicacion.Entidades;
using A.Aplicacion.Interfaces;

namespace A.Aplicacion.UseCases;
public class ModificarTerceroUseCase : TerceroUseCase
{
       public ModificarTerceroUseCase(ITercero repositorio) : base(repositorio)
    {
    }
    public async Task Ejecutar(Tercero t)
    {
        await Repositorio.Modificar(t);
    }
}
