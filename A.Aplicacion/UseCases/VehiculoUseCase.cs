using A.Aplicacion.Entidades;
using A.Aplicacion.Interfaces;


namespace A.Aplicacion.UseCases;

    public abstract class VehiculoUseCase
    {
        protected IVehiculos Repositorio { get; private set; }
        public VehiculoUseCase (IVehiculos repositorio){
            this.Repositorio = repositorio;
        }
    }
