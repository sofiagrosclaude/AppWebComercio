<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="WebAppArticulos.MiPerfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Mi perfil</h2>
        <div class="row">
            <div class="col-md-4">
                <div class="mb-3">
                    <label class="form-label">Email:</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail"/>
                </div>
                <div class="mb-3">
                    <label class="form-label">Nombre:</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre" />
                </div>
                <div class="mb-3">
                    <label class="form-label">Apellido:</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtApellido"/>
                </div>
            </div>

            <div class="col-md-4">
                <div class="mb-3">
                    <label class="form-label">Imagen Perfil:</label>
                    <input type="file" id="txtImagenPerfil" runat="server" class="form-control" />
                </div>
                <asp:Image ID="imgNuevoPerfil" ImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQt1G2ye1gTauHDy5vh2qNCNyWvAKO_KpcYFgZ17--uBC1CjYuAoqYeC9rIVEQme_p6pjY&usqp=CAU" runat="server" CssClass="img-fluid mb-3" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <asp:Button Text="Guardar" CssClass="btn btn-primary" Onclick="btnGuardar_Click" ID="btnGuardar" runat="server" />
                <a href="/">Regresar</a>
            </div>
        </div>
</asp:Content>
