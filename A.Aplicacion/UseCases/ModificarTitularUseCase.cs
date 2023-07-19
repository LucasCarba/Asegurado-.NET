using A.Aplicacion.Entidades;
using A.Aplicacion.Interfaces;

namespace A.Aplicacion.UseCases;
public class ModificarTitularUseCase : TitularUseCase
{
       public ModificarTitularUseCase(ITitular repositorio) : base(repositorio)
    {
    }
    public async Task Ejecutar(Titular v)
    {
        await Repositorio.Modificar(v);
    }
}
