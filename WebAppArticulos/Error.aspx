<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="WebAppArticulos.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Hubo un problema ❌ </h1>
    <asp:Label Text="text" ID="lblMensaje" runat="server" />

        <%if (!Negocio.Seguridad.sesionActiva(Session["usuario"])){ %>
                                       
            <asp:Button Text="Reintentar" ID="btnReintentar" OnClick="btnReintentar_Click" CssClass="btn btn-primary" runat="server" />
        <%} %> 
  
</asp:Content>
