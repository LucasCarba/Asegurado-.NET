using A.Aplicacion.Entidades;
using A.Aplicacion.Interfaces;

namespace A.Aplicacion.UseCases;
public class AgregarSiniestroUseCase : SiniestroUseCase
{
    public AgregarSiniestroUseCase(ISiniestro repositorio) : base(repositorio)
    {
    }
    public async Task Ejecutar(Siniestro s)
    {
            await Repositorio.Agregar(s);
    }
}
