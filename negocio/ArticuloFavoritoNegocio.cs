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

        public List<ArticuloFavorito> listarFavoritos(string id = "")
        {
            List<ArticuloFavorito> lista = new List<ArticuloFavorito>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "Select A.Id, IdUser, IdArticulo from FAVORITOS, ARTICULOS A where A.Id = " + id;
                datos.setearConsulta(consulta);                
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    ArticuloFavorito aux = new ArticuloFavorito();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.IdUser = (int)datos.Lector["IdUser"];
                    aux.IdArticulo = (int)datos.Lector["IdUser"];

                    lista.Add(aux);
                }

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

            public void eliminarFavorito(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("delete from FAVORITOS where Id = @id");
                datos.setearParametro("id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
