using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class ArticuloFavoritoNegocio
    {

        public List<ArticuloFavorito> listarFavUserId(int idUser)
        {
            AccesoDatos datos = new AccesoDatos();
            List<ArticuloFavorito> lista = new List<ArticuloFavorito>();

            try
            {
                datos.setearConsulta("Select IdArticulo from FAVORITOS where IdUser = @idUser");
                datos.setearParametro("@idUser", idUser);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {                    
                    int aux = (int)datos.Lector["idArticulo"];                     
                }

                datos.cerrarConexion();
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void insertarNuevoFavorito(ArticuloFavorito nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO FAVORITOS (IdUser, IdArticulo)VALUES(@idUser, @idArticulo)");
                datos.setearParametro("@idUser", nuevo.IdUser);
                datos.setearParametro("@idArticulo", nuevo.IdArticulo);
                datos.ejecutarAccion();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }        

            public void eliminarFavorito(int idUser, int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("delete from FAVORITOS where IdArticulo = @idArticulo and IdUser = @idUser");
                datos.setearParametro("IdArticulo", id);
                datos.setearParametro("idUser", idUser);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
