using A.Aplicacion.Interfaces;
using A.Aplicacion.Entidades;
using Microsoft.EntityFrameworkCore;

namespace A.Repositorios;
public class repositorioTercero : ITercero
{
   public async Task Agregar(Tercero t){  
      try{
      using (var db = new AseguradoraContext())
      
      {
         var siniestroExiste = db.Siniestros.Where(si => si.Id == t.SiniestroId).SingleOrDefault();
         if (siniestroExiste != null){
            db.Terceros.Add(t); // se agregará realmente con el db.SaveChanges()
            await db.SaveChangesAsync();
            }
            else {
               Console.WriteLine("ERROR!!! NO EXISTE SINIESTRO CON ESE ID");
            }
      }}
      catch(FileNotFoundException fe){
                Console.WriteLine("ERROR" + fe.Message);
            }catch(Exception e){
                Console.WriteLine("ERROR" + e.Message);
            }

      }
   public async Task Modificar(Tercero t){
      using (var db = new AseguradoraContext())
      {
         var tModificar = db.Terceros.Where(
         te => te.Id == t.Id).SingleOrDefault();
         if (tModificar != null)
            {
               tModificar.Id= t.Id;
               tModificar.DNI = t.DNI;
               tModificar.Apellido = t.Apellido;
               tModificar.Nombre = t.Nombre;
               tModificar.Telefono = t.Telefono;
               tModificar.Aseguradora = t.Aseguradora;
               tModificar.SiniestroId = t.SiniestroId;


            }
         await db.SaveChangesAsync();
      }
   }
   public async Task Eliminar(int id){
      using (var db = new AseguradoraContext())
      {
         var terceroBorrar = db.Terceros.Where(t => t.Id == id).SingleOrDefault();
         if (terceroBorrar != null)
         {
            db.Remove(terceroBorrar); 
            await db.SaveChangesAsync();//se borra realmente con el db.SaveChanges()
         }
      }
   }
     public async Task<List<Tercero>> ListarTercero()
    {
       try {
         using (var db = new AseguradoraContext())
         {
            return await db.Terceros.ToListAsync();
         }
       }
       catch(Exception) {
         throw;
       }
    }

}

