using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;




namespace WebAppArticulos
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            imgAvatar.ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQt1G2ye1gTauHDy5vh2qNCNyWvAKO_KpcYFgZ17--uBC1CjYuAoqYeC9rIVEQme_p6pjY&usqp=CAU";
            if (!(Page is Login || Page is Default || Page is Registro || Page is Error || Page is RegistroExitoso))
            {
                if (!Seguridad.sesionActiva(Session["usuario"]))
                    Response.Redirect("Login.aspx", false);
                else
                {
                    Usuario usuario = (Usuario)Session["usuario"];
                    lblUsuario.Text = usuario.Email;
                    if (!string.IsNullOrEmpty(usuario.urlImagenPerfil))
                        imgAvatar.ImageUrl = "~/Imagenes/" + usuario.urlImagenPerfil;

                }
            }
            
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}