using A.Aplicacion.Entidades;
using A.Aplicacion.Interfaces;


namespace A.Aplicacion.UseCases;

    public abstract class SiniestroUseCase
    {
        protected ISiniestro Repositorio { get; private set; }
        public SiniestroUseCase (ISiniestro repositorio){
            this.Repositorio = repositorio;
        }
    }