using A.Aplicacion.Entidades;  
namespace A.Aplicacion.Interfaces;

public interface ISiniestro
{
    Task Agregar(Siniestro siniestro);
    Task Modificar(Siniestro siniestro);
    Task Eliminar(int id);
    Task<List<Siniestro>> ListarSiniestro();
}
