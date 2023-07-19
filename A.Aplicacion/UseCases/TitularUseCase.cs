using A.Aplicacion.Entidades;
using A.Aplicacion.Interfaces;


namespace A.Aplicacion.UseCases;

    public abstract class TitularUseCase
    {
        protected ITitular Repositorio { get; private set; }
        public TitularUseCase (ITitular repositorio){
            this.Repositorio = repositorio;
        }
    }
