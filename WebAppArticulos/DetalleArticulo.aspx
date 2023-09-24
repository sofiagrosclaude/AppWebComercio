<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="WebAppArticulos.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager runat="server" ID="ScriptManager1" ></asp:ScriptManager>

             <div class="row">
                <div class="col-6">
                    <div class="mb-3">
                        <label for="txtId" class="form-label">Id:</label>
                        <asp:TextBox runat="server" ID="txtId" Cssclass="form-control"/>
                    </div>
                    <div class="mb-3">
                        <label for="txtNombre" class="form-label">Nombre:</label>
                        <asp:TextBox runat="server" ID="txtNombre" Cssclass="form-control"/>
                    </div>
                    <div class="mb-3">
                        <label for="txtCodigo" class="form-label">Código:</label>
                        <asp:TextBox runat="server" ID="txtCodigo" Cssclass="form-control"/>
                    </div>
                    <div class="mb-3">
                        <label for="txtDescripcion" class="form-label">Descripción:</label>
                        <asp:TextBox runat="server" TextMode="MultiLine" ID="txtDescripcion" Cssclass="form-control"/>
                    </div>
                    <div class="mb-3">
                        <label for="ddlCategoria" class="form-label">Categoría:</label>
                        <asp:DropDownList runat="server" ID="ddlCategoria" Cssclass="btn btn-secondary dropdown-toggle" ></asp:DropDownList>
                        <label for="ddlMarca" class="form-label">Marca:</label>
                        <asp:DropDownList runat="server" ID="ddlMarca" Cssclass="btn btn-secondary dropdown-toggle"></asp:DropDownList>
                    </div>
                         <div class="mb-3">
                            <label for="txtPrecio" class="form-label">Precio:</label>
                            <asp:TextBox runat="server" ID="txtPrecio" Cssclass="form-control" ></asp:TextBox>
                        </div>
               </div>
            
        
               <div class="col-6">
                  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                     <ContentTemplate>
                        <div class="mb-3">
                            <label for="txtImagenUrl" class="form-label">Url Imagen:</label>
                            <asp:TextBox runat="server" ID="txtImagenUrl" OnTextChanged="txtImagenUrl_TextChanged" AutoPostBack="true" Cssclass="form-control" ></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <asp:Image runat="server" ID="imgArticulo" Width="60%" ImageUrl="https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/681px-Placeholder_view_vector.svg.png"/>
                       </div>
                  </ContentTemplate>
               </asp:UpdatePanel>
               </div>
        </div>
</asp:Content>


