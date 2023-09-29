using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;


namespace WebAppArticulos
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario users = new Usuario();
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                EmailService emailService = new EmailService();

                users.Email = txtEmail.Text;
                users.Pass = txtPassword.Text;
                int id = usuarioNegocio.insertarNuevo(users);

                emailService.armarCorreo(users.Email, "Bienvenidx Usuarix", "Hola, te damos la bienvenido a la App");
                emailService.enviarEmail();
                
                Response.Redirect("RegistroExitoso.aspx", false);
                
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
            }
        }
    }
}