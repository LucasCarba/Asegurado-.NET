using A.Aplicacion.Entidades;
using A.Aplicacion.Interfaces;


namespace A.Aplicacion.UseCases;

    public abstract class TerceroUseCase
    {
        protected ITercero Repositorio { get; private set; }
        public TerceroUseCase (ITercero repositorio){
            this.Repositorio = repositorio;
        }
    }
