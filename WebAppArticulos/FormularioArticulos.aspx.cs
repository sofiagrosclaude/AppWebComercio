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
    public partial class WebForm3 : System.Web.UI.Page
    {
        public bool ConfirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            //configuracion inicial de la pantalla
            ConfirmaEliminacion = false;
            txtId.Enabled = false;
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

                    btnEliminar.Enabled = false;
                    btnInactivar.Enabled = false;
                    

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

                    btnEliminar.Enabled = true;
                    btnInactivar.Enabled = true;    
                }

            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
                //throw ex;
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Articulo nuevo = new Articulo();
                ArticuloNegocio negocio = new ArticuloNegocio();
                nuevo.Nombre = txtNombre.Text;
                nuevo.Codigo = txtCodigo.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.ImagenUrl = txtImagenUrl.Text;
                nuevo.Precio = decimal.Parse(txtPrecio.Text);

                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);

                nuevo.Marca = new Marca();
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);

                if (Request.QueryString["id"] != null)
                {
                   nuevo.Id = int.Parse(txtId.Text);
                   negocio.modificarConSP(nuevo);
                }
                else
                   negocio.agregarConSP(nuevo);
                               
                Response.Redirect("ArticulosLista.aspx", false);
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtImagenUrl.Text;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmaEliminacion = true;
        }

        protected void btnConfirmaEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                //if (chkConfirmaEliminacion.Checked)
                //{
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    negocio.eliminar(int.Parse(txtId.Text));
                    Response.Redirect("ArticulosLista.aspx");
                //}
                
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
      
        protected void btnInactivar_Click(object sender, EventArgs e)
        {
            //No puedo construir y llamar al método eliminarLógico por el diseño de la base de datos

            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                negocio.eliminarLogico(int.Parse(txtId.Text));
                Response.Redirect("ArticulosLista.aspx");


            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }

            //visible (?) = false?
                
       
        }
    }
  
}