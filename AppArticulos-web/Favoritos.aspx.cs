using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using dominio;
using negocio;

namespace AppArticulos_web
{
    public partial class Favoritos : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Trainee user = (Trainee)Session["trainee"];
            string id = Request.QueryString["id"];
            if (!string.IsNullOrEmpty(id) && int.TryParse(id, out int idArticulo))
            {
                ArticuloFavoritoNegocio negocio = new ArticuloFavoritoNegocio();
                ArticuloFavorito nuevo = new ArticuloFavorito();                

                nuevo.IdUser = user.Id;
                nuevo.IdArticulo = int.Parse(id);

                negocio.insertarNuevoFavorito(nuevo);
            }
                ListaArticulo = new List<Articulo>();

            if (user != null)
            {
                ArticuloFavoritoNegocio negocioart = new ArticuloFavoritoNegocio();
                List<int> idArticulosFavoritos = negocioart.listarFavUserId(user.Id);
                if (idArticulosFavoritos.Count > 0)
                {
                    ArticuloNegocio art = new ArticuloNegocio();
                    ListaArticulo = art.listarArtById(idArticulosFavoritos);
                    repRepetidor.DataSource = ListaArticulo;
                    repRepetidor.DataBind();
                }              

                
            }
            else
            {
                Session.Add("error", "No se han podido cargar los articulos favoritos 😕");
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnEliminarFav_Click(object sender, EventArgs e)
        {
            Trainee user = (Trainee)Session["trainee"];
            ArticuloFavoritoNegocio negocio = new ArticuloFavoritoNegocio();

            // Obtener el IdArticuloFav del botón que se hizo click
            //Button btn = (Button)sender;
            //int id = int.Parse(btn.CommandArgument);

            int idArticulo = int.Parse(((Button)sender).CommandArgument);

            // Obtener el IdUser del usuario logueado
            //int idUser = int.Parse(Session["UserId"].ToString());
            int idUser = user.Id;

            // Eliminar el registro de la tabla FAVORITOS, solo si pertenece al usuario logueado
            negocio.eliminarFavorito(idArticulo, idUser);
            //negocio.eliminarFav(id);

            //actualizar la pagina: 
            Page_Load(sender, e);

        }

    }
}

