using A.Aplicacion.Interfaces;
using A.Aplicacion.Entidades;
using Microsoft.EntityFrameworkCore;

namespace A.Repositorios;
public class repositorioPolizas : IPoliza
{
   public async Task Agregar(Poliza p){  
      try{
      using (var db = new AseguradoraContext())
      {
         var pAgg = db.Vehiculos.Where(ve => ve.Id == p.VehiculoId).SingleOrDefault();
         //Chequear que exista un vehiculo para la poliza.
         if (pAgg != null)
            {
               var polExistente = db.Polizas.Where(pol => pol.VehiculoId == pAgg.Id).SingleOrDefault();
               // chequear si existe una poliza para este vehiculo.
               if (polExistente != null){
                  // Chequear que la poliza a agregar este fuera del periodo de la encontrada.
               if(( p.FechaInicioVigencia < polExistente.FechaInicioVigencia)||( p.FechaFinVigencia > polExistente.FechaInicioVigencia))
                  {      
                  if(( p.FechaFinVigencia < polExistente.FechaInicioVigencia)||( p.FechaFinVigencia > polExistente.FechaInicioVigencia))   
                  {
                     //Chequear que el tipo de cobertura sea o todo riesgo o resposabilidad Civil.
                     if ((p.TipoCobertura == "TR") || (p.TipoCobertura =="RC")) 
                     {
                        db.Polizas.Add(p); 
                        await db.SaveChangesAsync();
                     } else {
                        Console.WriteLine("ERROR, el tipo de cobertura debe ser TR o RC.");
                     }
                     }}
               else {
                  Console.WriteLine("ERROR, ya hay poliza para esta fecha");
               }}
               //Chequear que el tipo de cobertura sea o todo riesgo o resposabilidad Civil.
                     if ((p.TipoCobertura == "TR") || (p.TipoCobertura =="RC")) 
                     {
                        db.Polizas.Add(p); 
                        await db.SaveChangesAsync();
                     } else {
                        Console.WriteLine("ERROR, el tipo de cobertura debe ser TR o RC.");
                     }
            }else {
               Console.WriteLine("ERROR, no existe vehiculo con este ID");   
         }
      }}
      catch(FileNotFoundException fe){
                Console.WriteLine("ERROR" + fe.Message);
      }catch(Exception e){
                Console.WriteLine("ERROR" + e.Message);
            }

      }
   public async Task Modificar(Poliza p){
      using (var db = new AseguradoraContext())
      {
         var pModificar = db.Polizas.Where(
         po => po.Id == p.Id).SingleOrDefault();
         if (pModificar != null)
            {
               pModificar.Id= p.Id;
               pModificar.VehiculoId= p.VehiculoId;
               pModificar.ValorAsegurado = p.ValorAsegurado;
               pModificar.Franquicia = p.Franquicia;
               pModificar.TipoCobertura = p.TipoCobertura;
               pModificar.FechaInicioVigencia = p.FechaInicioVigencia;
               pModificar.FechaFinVigencia = p.FechaFinVigencia;

            }
         await db.SaveChangesAsync();
      }
   }
   public async Task Eliminar(int id){
      using (var db2 = new AseguradoraContext())
      {
         var idSiniestro = db2.Siniestros.Where(s => s.PolizaId == id).ToList();
         foreach (var idS in idSiniestro){
            var terceroBorrar = db2.Terceros.Where(t => t.SiniestroId == idS.Id).ToList();
            foreach (var borrar in terceroBorrar){
               db2.Remove(borrar);
            }
            db2.Remove(idS);
         }
         var polizaBorrar = db2.Polizas.Where(t => t.Id == id).SingleOrDefault();
         if (polizaBorrar != null)
         {
            db2.Remove(polizaBorrar); 
         }
         await db2.SaveChangesAsync();
      }

   }
     public async Task<List<Poliza>> ListarPoliza()
    {
       try {
         using (var db = new AseguradoraContext())
         {
            return await db.Polizas.ToListAsync();
         }
       }
       catch(Exception) {
         throw;
       }
    }

}

