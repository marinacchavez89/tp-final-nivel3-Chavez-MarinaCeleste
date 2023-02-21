using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace AppArticulos_web
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulo { get; set; }       

        
        protected void Page_Load(object sender, EventArgs e)
        {
            

            ArticuloNegocio negocio = new ArticuloNegocio();
            ListaArticulo = negocio.listarConSP();

            if (!IsPostBack)
            {
                repRepetidor.DataSource = ListaArticulo;
                repRepetidor.DataBind();

            }
        }

        protected void btnComprar_Click(object sender, EventArgs e)
        {

            string valor = ((Button)sender).CommandArgument;

            Session.Add("error", "Disponible próximamente 😁");
            Response.Redirect("Error.aspx");

        }

     
    }
}