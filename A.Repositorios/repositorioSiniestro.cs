using A.Aplicacion.Interfaces;
using A.Aplicacion.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
namespace A.Repositorios;
public class repositorioSiniestro : ISiniestro
{
   public async Task Agregar(Siniestro s){  
   try{
      using (var db = new AseguradoraContext())
      {
        var polizaExiste = db.Polizas.Where(po => po.Id == s.PolizaId).SingleOrDefault();
         if (polizaExiste != null)
           {
            if((polizaExiste.FechaFinVigencia > s.FechaOcurrencia)&&(polizaExiste.FechaInicioVigencia < s.FechaOcurrencia)){
                db.Siniestros.Add(s); 
                await db.SaveChangesAsync();
            }
            else {
               Console.WriteLine("EL VEHICULO NO SE ENCONTRABA ASEGURADO CUANDO OCURRIO EL ACCIDENTE");
            }
             }
       else {
         Console.WriteLine("ERROR!!! NO SE ENCONTRO POLIZA EXISTENTE.");
           }
      }
      }
     catch(FileNotFoundException fe){
                Console.WriteLine("ERROR" + fe.Message);
            }catch(Exception e){
                Console.WriteLine("ERROR" + e.Message);
            }
   }
   public async Task Modificar(Siniestro s){
      using (var db = new AseguradoraContext())
      {
         var sModificar = db.Siniestros.Where(
         si => si.Id == s.Id).SingleOrDefault();
         if (sModificar != null)
            {
               sModificar.Id= s.Id;
                sModificar.PolizaId= s.PolizaId;
                sModificar.FechaIngreso= s.FechaIngreso;
                sModificar.FechaOcurrencia= s.FechaOcurrencia;
                sModificar.Direccion= s.Direccion;
                sModificar.Descripcion = s.Descripcion;

            }
         await db.SaveChangesAsync();
      }
   }
   public async Task Eliminar(int id){
      using (var db = new AseguradoraContext())
      {
         var siniestroBorrar = db.Siniestros.Where(s => s.Id == id).SingleOrDefault();
            if (siniestroBorrar != null)
               {
                  db.Remove(siniestroBorrar); 
                  await db.SaveChangesAsync();
               }
         }
      using (var db2 = new AseguradoraContext())
      {
         var terceroBorrar = db2.Terceros.Where(t => t.SiniestroId == id).ToList();
            foreach (var borra in terceroBorrar){
                  db2.Remove(borra); 
                  await db2.SaveChangesAsync();
               }
         } 
      }
      

     public async Task<List<Siniestro>> ListarSiniestro()
    {
       try {
         using (var db = new AseguradoraContext())
         {
            return await db.Siniestros.ToListAsync();
         }
       }
       catch(Exception) {
         throw;
       }
    }

}

