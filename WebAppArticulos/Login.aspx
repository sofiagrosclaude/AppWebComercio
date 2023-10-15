<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebAppArticulos.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-6">
        <h2>Logueate</h2>
        
        <div class="mb-3">
            <label clas="form-label">Email:</label>
            <asp:TextBox runat="server" REQUIRED ID="txtEmail" CssClass="form-control"/>
        </div>
        <div class="mb-3">
            <label clas="form-label">Password:</label>
            <asp:TextBox runat="server" ID="txtPassword" placeholder="******" CssClass="form-control" TextMode="Password" />
        </div>
        <asp:Button Text="Ingresar" ID="btnIngresar" OnClick="btnIngresar_Click" cssClass="btn btn-primary" runat="server" />
        
    </div>

</asp:Content>
