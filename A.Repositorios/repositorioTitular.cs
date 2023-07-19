using A.Aplicacion.Interfaces;
using A.Aplicacion.Entidades;
using Microsoft.EntityFrameworkCore;

namespace A.Repositorios;
public class repositorioTitular : ITitular
{

    public async Task Agregar(Titular t){  
      try{
      using (var db = new AseguradoraContext())
      {
         db.Titulares.Add(t); // se agregará realmente con el db.SaveChanges()
         await db.SaveChangesAsync();
         }
      }
      catch(FileNotFoundException fe){
                Console.WriteLine("ERROR" + fe.Message);
            }catch(Exception e){
                Console.WriteLine("ERROR" + e.Message);
            }

      }
   public async Task Modificar(Titular t){
      using (var db = new AseguradoraContext())
      {
         var tModificar = db.Titulares.Where(
         tit => tit.Id == t.Id).SingleOrDefault();
         if (tModificar != null)
            {
               tModificar.Id= t.Id;
               tModificar.DNI = t.DNI;
               tModificar.Apellido = t.Apellido;
               tModificar.Nombre = t.Nombre;
               tModificar.Telefono = t.Telefono;
               tModificar.Direccion = t.Direccion;
               tModificar.CorreoElectronico = t.CorreoElectronico;
            }
         await db.SaveChangesAsync();
      }
   }
   public async Task Eliminar(int id){
      //Elimino primeramente el titular y luego el vehiculo que corresponde a la persona indicada.
      using (var db = new AseguradoraContext())
      {
         var titularBorrar = db.Titulares.Where(t => t.Id == id).SingleOrDefault();
         var vehiBorrar = db.Vehiculos.Where(v => v.TitularId == id).ToList();
         foreach (var ve in vehiBorrar)
            {
               var poliBorrar = db.Polizas.Where(p => p.VehiculoId == ve.Id).ToList();
               foreach (var poliz in poliBorrar)
                  {
                  var idSiniestro = db.Siniestros.Where(s => s.PolizaId == poliz.Id).ToList();
                  foreach (var idS in idSiniestro){
                     var terceroBorrar = db.Terceros.Where(t => t.SiniestroId == idS.Id).ToList();
                     foreach (var ter in terceroBorrar){
                        db.Remove(ter);
                     }
                     db.Remove(idS);
                  }
                  db.Remove(poliz);
             }
            db.Remove(ve);
            }
         if (titularBorrar != null){
            db.Remove(titularBorrar);
            await db.SaveChangesAsync();  //se borra realmente con el db.SaveChanges()
            }
         }
      }
   
   
     public async Task<List<Titular>> ListarTitular()
    {
       try {
         using (var db = new AseguradoraContext())
         {
            return await db.Titulares.ToListAsync();
         }
       }
       catch(Exception) {
         throw;
       }
    }
    public List<Titular> ListarTitularVehiculo(List<Vehiculo> vehiculos)
    {
      List<Titular> titulares = new List<Titular>();
      List<Titular> titularesConVehiculos = new List<Titular>();
       using (var db = new AseguradoraContext())
         {
            titulares= db.Titulares.ToList();
            vehiculos= db.Vehiculos.ToList();
         }

        foreach (Titular titular in titulares)
        {
            Titular titularConVehiculos = new Titular { Id = titular.Id };

            foreach (Vehiculo vehiculo in vehiculos)
            {
                if (titular.Id == vehiculo.TitularId)
                {
                    titularConVehiculos.vehiculos.Add(vehiculo);
                }
            }

            titularesConVehiculos.Add(titularConVehiculos);
        }

        return titularesConVehiculos;
    
      }

}

