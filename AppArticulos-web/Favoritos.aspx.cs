using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace AppArticulos_web
{
    public partial class Favoritos : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
            //if (!IsPostBack)
            //{
            //    ArticuloFavoritoNegocio negocio = new ArticuloFavoritoNegocio();
            //    ArticuloFavorito nuevo = new ArticuloFavorito();

            //    Trainee user = (Trainee)Session["trainee"];

            //    nuevo.IdUser = user.Id;
            //    nuevo.IdArticulo = int.Parse(id);

            //    negocio.insertarNuevoFavorito(nuevo);

            //    Session.Add("listaArticulosFavoritos", negocio.listarFavoritos());
            //    dgvArticulos.DataSource = Session["listaArticulosFavoritos"];
            //    dgvArticulos.DataBind();

            //}

        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("Favoritos.aspx?id=" + id);
        }

        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvArticulos.DataSource = Session["listaArticulosFavoritos"];
            dgvArticulos.PageIndex = e.NewPageIndex;
            dgvArticulos.DataBind();
        }
    }
}