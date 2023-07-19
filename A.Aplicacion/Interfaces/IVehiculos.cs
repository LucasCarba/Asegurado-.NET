using A.Aplicacion.Entidades;

namespace A.Aplicacion.Interfaces;
public interface IVehiculos
{
    Task Agregar(Vehiculo vehiculo);
    Task Modificar(Vehiculo vehiculo);
    Task Eliminar(int id);
    Task<List<Vehiculo>> ListarVehiculo();
}
