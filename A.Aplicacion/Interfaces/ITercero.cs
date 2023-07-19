using A.Aplicacion.Entidades;

namespace A.Aplicacion.Interfaces;
public interface ITercero
{
    Task Agregar(Tercero tercero);
    Task Modificar(Tercero tercero);
    Task Eliminar(int id);
    Task<List<Tercero>> ListarTercero();
}
