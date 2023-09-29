using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppArticulos
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario users;
            UsuarioNegocio negocio = new UsuarioNegocio();
            try
            {
                users = new Usuario(txtEmail.Text, txtPassword.Text, false);
                if (negocio.Loguear(users))
                {
                    Session.Add("usuario", users);
                    Response.Redirect("LoginExitoso.aspx", false);

                }
                else
                {
                    Session.Add("error", "User o Password incorrecta");
                    Response.Redirect("Error.aspx",false);
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);

            }
        }
    }
}