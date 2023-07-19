using A.Aplicacion.Entidades;

namespace A.Aplicacion.Interfaces;
public interface ITitular
{
Task Agregar(Titular titular);
Task Modificar(Titular titular);
Task Eliminar(int id);
Task<List<Titular>> ListarTitular();
List<Titular>  ListarTitularVehiculo(List<Vehiculo> vehiculos);
}
