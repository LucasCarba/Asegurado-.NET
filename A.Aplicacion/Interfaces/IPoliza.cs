using A.Aplicacion.Entidades;  
namespace A.Aplicacion.Interfaces;

public interface IPoliza
{
    Task Agregar(Poliza poliza);
    Task Modificar(Poliza poliza);
    Task Eliminar(int id);
    Task<List<Poliza>> ListarPoliza();
}
