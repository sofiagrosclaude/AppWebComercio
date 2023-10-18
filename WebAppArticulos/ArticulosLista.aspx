<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ArticulosLista.aspx.cs" Inherits="WebAppArticulos.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Lista de Artículos</h1>

            <div class="row">
                <div class="col-6">
                    <div class="mb-3">
                        <asp:Label Text="Buscar:" runat="server" />
                        <asp:TextBox runat="server" AutoPostBack="true" CssClass="form-control" ID="txtFiltro" OnTextChanged="filtro_TextChanged" />
                    </div>
                </div>
            </div>
                <div class="col-6" style="display:flex; flex-direction: column; justify-content: flex-end;">
                    <div class="mb-3">
                        <asp:Label Text=" 🔎 Búsqueda Avanzada" runat="server" />
                        <asp:CheckBox Text="" runat="server" ID="chkAvanzado" AutoPostback="true" OnCheckedChanged="chkAvanzado_CheckedChanged" />
                    </div>
                </div>
      
        
        <%if (FiltroAvanzado) 
          { %>
            <div class="row">
                <div class="col-3">
                    <div class="mb-3">
                        <asp:DropDownList runat="server" ID="ddlCampo" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control">
                            <asp:ListItem Text="Categoría" />
                            <asp:ListItem Text="Marca" />
                            <asp:ListItem Text="Precio" />
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-3">
                    <div class="mb-3">
                        <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-3">
                    <div class="mb-3">
                        <asp:TextBox runat="server" ID="txtFiltroAvanzado" CssClass="form-control" />  
                    </div>
                </div>
                 <div class="col-3">
                    <div class="mb-3">
                        <asp:Button Text="Buscar" runat="server" ID="btnBuscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" />
                    </div>
                </div>
           </div>
        <%} %>
        
    <asp:GridView ID="dgvArticulos" DataKeyNames="Id" runat="server" CssClass="table" AutoGenerateColumns="false" 
        OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged" OnPageIndexChanging="dgvArticulos_PageIndexChanging" AllowPaging="true" PageSize="5" >
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Categoría" DataField="Categoria.Descripcion" />
            <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" />
            <asp:CommandField HeaderText="Modificar" ShowSelectButton="true" SelectText="✍" />
         </Columns>
    </asp:GridView>
       
     <a href="FormularioArticulos.aspx" class="btn btn-primary">Agregar Artículo</a>
    
</asp:Content>
