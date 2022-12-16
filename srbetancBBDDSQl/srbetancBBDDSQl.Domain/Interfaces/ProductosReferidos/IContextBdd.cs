using System.Data;

namespace srbetancBBDDSQl.Domain.Interfaces.ProductosReferidos
{
    public interface IContextBdd
    {
        // <summary>
        /// Método para obtener una conexión hacia la base de datos
        /// </summary>
        /// <returns></returns>
        IDbConnection GetConnection();
        /// <summary>
        /// Método para eliminar una conexión hacia la base de datos
        /// </summary>
        /// <param name="con"></param>
        void Disconnect(IDbConnection con);
    }
}
