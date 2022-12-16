using BP.API.Entidades.Excepciones;

namespace srbetancBBDDSQl.Repository.Excepcciones
{
    [Serializable]
    public class RepositorioExcepcion: InfoError
    {
        public RepositorioExcepcion()
        {
        }

        public RepositorioExcepcion(string codigo, string mensaje, string microservicio, string metodo, string backend, Exception excepcion)
             : base(mensaje, excepcion)
        {
            base.Codigo = codigo;
            base.Mensaje = mensaje;
            base.Recurso = microservicio + "/" + metodo;
            base.Componente = metodo;
            base.Tipo = "FATAL";
            base.Backend = backend;
        }
    }
}
