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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //configuracion inicial de la pantalla
       
            txtId.Enabled = false;
            txtCodigo.Enabled = false;
            txtDescripcion.Enabled = false;
            txtNombre.Enabled = false;
            txtPrecio.Enabled = false;
            txtImagenUrl.Enabled = false;
            ddlCategoria.Enabled = false;
            ddlMarca.Enabled = false;
            try
            {
                if (!IsPostBack)
                {
                    CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                    MarcaNegocio marcaNegocio = new MarcaNegocio();

                    List<Categoria> listaCategoria = categoriaNegocio.listar();

                    ddlCategoria.DataSource = listaCategoria;
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();

                    List<Marca> listaMarca = marcaNegocio.listar();
                    ddlMarca.DataSource = listaMarca;
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();

                }

                //configuracion si estamos modificando
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "" && !IsPostBack)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    //List<Articulo> lista = negocio.listar(id);
                    //Articulo seleccionado = lista[0];
                    Articulo seleccionado = (negocio.listar(id))[0];

                    //precargar los campos

                    txtId.Text = id;
                    txtNombre.Text = seleccionado.Nombre;
                    txtCodigo.Text = seleccionado.Codigo;
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtImagenUrl.Text = seleccionado.ImagenUrl;
                    txtPrecio.Text = seleccionado.Precio.ToString("0.00");

                    //se tienen que cargar los ddl para poder precargarlos

                    ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
                    ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                    txtImagenUrl_TextChanged(sender, e);



                }

            }
            catch (Exception ex)
            {

                Session.Add("Error", ex);
                //throw ex;
            }
        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
             imgArticulo.ImageUrl = txtImagenUrl.Text;
        }
    }
}