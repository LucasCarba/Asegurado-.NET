using A.Aplicacion.Entidades;
using A.Aplicacion.Interfaces;

namespace A.Aplicacion.UseCases;
public class AgregarTitularUseCase : TitularUseCase
{
    public AgregarTitularUseCase(ITitular repositorio) : base(repositorio)
    {
    }
    public async Task Ejecutar(Titular titu)
    {
        
            await Repositorio.Agregar(titu);
    }
}
