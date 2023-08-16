﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebAppArticulos.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Hola!</h1>
    <p>Llegaste a tu carrito de compras :)</p>

        <div class="row row-cols-1 row-cols-md-3 g-4">

            <%
                foreach (Dominio.Articulo art in ListaArticulo)
                {
            %>
                 
                 <div class="col">
                    <div class="card h-100">
                      <img src="<%:art.ImagenUrl %>" class="card-img-top" alt="...">
                      <div class="card-body">
                        <h5 class="card-title"><%: art.Nombre %></h5>
                        <p class="card-text"><%: art.Descripcion %></p>
                          <a href="DetalleArticulo.aspx?id=<%: art.Id %>">Ver Detalle</a>
                      </div>
                    </div>
                 </div>

             <% } %>

        </div>
</asp:Content>
