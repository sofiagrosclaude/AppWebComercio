﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
using System.Diagnostics.Eventing.Reader;

namespace WebAppArticulos
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public bool FiltroAvanzado { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Seguridad.esAdmin(Session["usuario"]))
            {
                Session.Add("error", "Se requieren permisos de Admin para acceder a esta pantalla");
                Response.Redirect("Error.aspx");
                
                
            }

            FiltroAvanzado = chkAvanzado.Checked;
            if (!IsPostBack)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                Session.Add("listaArticulos", negocio.listarConSP());
                dgvArticulos.DataSource = Session["listaArticulos"];
                dgvArticulos.DataBind();

            }
            else
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                Session.Add("listaArticulos", negocio.listarConSP());
                dgvArticulos.DataSource = Session["listaArticulos"];
                dgvArticulos.DataBind();

            }

        }
        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvArticulos.PageIndex = e.NewPageIndex;
            dgvArticulos.DataBind();
        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioArticulos.aspx?id=" + id);
        }

        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> lista = (List<Articulo>)Session["listaArticulos"];
            List<Articulo> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            dgvArticulos.DataSource = listaFiltrada;
            dgvArticulos.DataBind();
        }

        protected void chkAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            FiltroAvanzado = chkAvanzado.Checked;
            txtFiltro.Enabled = !FiltroAvanzado;


        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {

            ddlCriterio.Items.Clear();
            if (ddlCampo.SelectedItem.ToString() == "Precio")
            {
                ddlCriterio.Items.Add("Desde:");
                ddlCriterio.Items.Add("Hasta:");


            }
            else
            {
                ddlCriterio.Items.Add("Contiene:");
                ddlCriterio.Items.Add("Comienza con:");

            }
          

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
                try
                {
                        ArticuloNegocio negocio = new ArticuloNegocio();
                        
                        dgvArticulos.DataSource = negocio.filtrar(
                        ddlCampo.SelectedItem.ToString(),
                        ddlCriterio.SelectedItem.ToString(), txtFiltroAvanzado.Text);
                        dgvArticulos.DataBind();

                }
                catch (Exception ex)
                {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
                }
        

        }

       
    } 
}    