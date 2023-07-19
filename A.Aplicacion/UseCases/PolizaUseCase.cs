using A.Aplicacion.Entidades;
using A.Aplicacion.Interfaces;


namespace A.Aplicacion.UseCases;

    public abstract class PolizaUseCase
    {
        protected IPoliza Repositorio { get; private set; }
        public PolizaUseCase (IPoliza repositorio){
            this.Repositorio = repositorio;
        }
    }
