using A.Aplicacion.Entidades;
using A.Aplicacion.Interfaces;

namespace A.Aplicacion.UseCases;
public class ModificarSiniestroUseCase : SiniestroUseCase
{
       public ModificarSiniestroUseCase(ISiniestro repositorio) : base(repositorio)
    {
    }
    public async Task Ejecutar(Siniestro p)
    {
        await Repositorio.Modificar(p);
    }
}
