using A.Aplicacion.Interfaces;
using A.Aplicacion.Entidades;
using Microsoft.EntityFrameworkCore;


namespace A.Repositorios;
public class repositorioVehiculo : IVehiculos
{
   public async Task Agregar(Vehiculo ve){  
      try{
      using (var db = new AseguradoraContext())
      {
         var titularExiste = db.Titulares.Where(t => t.Id == ve.TitularId).SingleOrDefault();
         if (titularExiste != null)
            {
            db.Vehiculos.Add(ve); // se agregará realmente con el db.SaveChanges()
            await db.SaveChangesAsync();
            } else {
               Console.WriteLine("ERROR!!! NO EXISTE UN TITULAR CON ESE ID");
            }}
      }
      catch(FileNotFoundException fe){
                Console.WriteLine("ERROR" + fe.Message);
            }catch(Exception e){
                Console.WriteLine("ERROR" + e.Message);
            }

      }
   public async Task Modificar(Vehiculo vehiculo){
      using (var db = new AseguradoraContext())
      {
         var vModificar = db.Vehiculos.Where(
         v => v.Id == vehiculo.Id).SingleOrDefault();
         if (vModificar != null)
            {
               vModificar.Dominio = vehiculo.Dominio; 
               vModificar.Marca = vehiculo.Marca;
               vModificar.AnioFabricacion = vehiculo.AnioFabricacion;
               vModificar.TitularId = vehiculo.TitularId;
            }
         await db.SaveChangesAsync();
      }
   }
   public async Task Eliminar(int id){
      using (var db = new AseguradoraContext())
      {
         var polizasBorrar = db.Polizas.Where(p => p.VehiculoId == id).ToList();
         foreach (var poliz in polizasBorrar){
               var siniestroBorrar = db.Siniestros.Where(s => s.PolizaId == poliz.Id).ToList();
                foreach (var sini in siniestroBorrar){
                  var tercerBorrar = db.Terceros.Where(t => t.SiniestroId == sini.Id).ToList();
                  foreach (var ter in tercerBorrar){
                     db.Remove(ter);
                   }
                   db.Remove(sini);
                }
               db.Remove(poliz);
            }
            var vehiculoBorrar = db.Vehiculos.Where(v => v.Id == id).SingleOrDefault();
             if (vehiculoBorrar != null){
                     db.Remove(vehiculoBorrar); 
                     await db.SaveChangesAsync();
                  }
               }
   }
   
          //se borra realmente con el db.SaveChanges()
      
   
    //LEER VEHICULOS
     public async Task<List<Vehiculo>> ListarVehiculo()
    {
       try {
         using (var db = new AseguradoraContext())
         {
            return await db.Vehiculos.ToListAsync();
         }
       }
       catch(Exception) {
         throw;
       }
    }
   
}



