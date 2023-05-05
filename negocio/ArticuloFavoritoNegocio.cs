using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class ArticuloFavoritoNegocio
    {

        public List<int> listarFavUserId(int idUser)
        {
            AccesoDatos datos = new AccesoDatos();
            List<int> lista = new List<int>();

            try
            {
                datos.setearConsulta("Select IdArticulo from FAVORITOS where IdUser = @idUser");
                datos.setearParametro("@idUser", idUser);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {                    
                    int aux = (int)datos.Lector["idArticulo"];
                    lista.Add(aux);
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
                // Comprobar si el usuario ya tiene el artículo en su lista de favoritos
                datos.setearConsulta("SELECT COUNT(*) FROM FAVORITOS WHERE IdUser = @idUser AND IdArticulo = @idArticulo");
                datos.setearParametro("@idUser", nuevo.IdUser);
                datos.setearParametro("@idArticulo", nuevo.IdArticulo);
                datos.ejecutarLectura();

                // Si la consulta devuelve algún resultado, el artículo ya está en la lista de favoritos del usuario y no se debe insertar un nuevo registro
                if (datos.Lector.Read())
                {
                    int cantidad = Convert.ToInt32(datos.Lector[0]);
                    if (cantidad > 0)
                    {
                        datos.cerrarConexion();
                        return;
                    }
                }

                datos.cerrarConexion();
                datos = new AccesoDatos();
                // Insertar el nuevo registro en la tabla "FAVORITOS"
                datos.setearConsulta("INSERT INTO FAVORITOS (IdUser, IdArticulo)VALUES(@idUser, @idArticulo)");
                datos.setearParametro("@idUser", nuevo.IdUser);
                datos.setearParametro("@idArticulo", nuevo.IdArticulo);
                datos.ejecutarAccion();
                datos.cerrarConexion();
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
        public void eliminarFavorito(int idArticulo, int idUser)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("DELETE FROM FAVORITOS WHERE IdArticulo = @idArticulo AND IdUser = @idUser");
                datos.setearParametro("@idArticulo", idArticulo);
                datos.setearParametro("@idUser", idUser);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void eliminarFav(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            datos.setearConsulta("delete from FAVORITOS where IdArticulo = @idArticulo");
            datos.setearParametro("@idArticulo", id);
            datos.ejecutarAccion();
        }

    }
}
