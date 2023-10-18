using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace WebAppArticulos
{
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
           
            try
            {
                if(!IsPostBack) {

                    if (Seguridad.sesionActiva(Session["usuario"]))
                    {
                        Usuario usuario = (Usuario)Session["usuario"];
                        txtEmail.Text = usuario.Email;
                        txtEmail.ReadOnly = true;
                        txtNombre.Text = usuario.Nombre;
                        txtApellido.Text = usuario.Apellido;
                        if(!string.IsNullOrEmpty(usuario.urlImagenPerfil))
                            imgNuevoPerfil.ImageUrl = "~/Imagenes/" + usuario.urlImagenPerfil;
                    }
                }

            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
           
            
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                Page.Validate();
                if (!Page.IsValid)
                    return;
                //Escribir img
                UsuarioNegocio negocio = new UsuarioNegocio();
                
                Usuario usuario = (Usuario)Session["usuario"];

                if(txtImagenPerfil.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./Imagenes/");
                    txtImagenPerfil.PostedFile.SaveAs(ruta + "perfil-" + usuario.Id + ".png");
                    usuario.urlImagenPerfil = "perfil-" + usuario.Id + ".png";

                }
               
                usuario.Nombre = txtNombre.Text;
                usuario.Apellido = txtApellido.Text;
                

                //leer img
                
                Image img = (Image)Master.FindControl("imgAvatar");
                img.ImageUrl = "~/Imagenes/" + usuario.urlImagenPerfil;

                //guardar datos
                negocio.actualizar(usuario);
               
               

            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}