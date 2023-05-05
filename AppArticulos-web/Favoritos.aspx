<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="AppArticulos_web.Favoritos" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Mis articulos favoritos</h2>
    <br />

    <%--<h3>Proximamente... ⭐</h3>--%>

      <div class="row row-cols-1 row-cols-md-3 g-4">

        <asp:Repeater ID="repRepetidor" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <img src="<%#Eval("ImagenUrl") %>" class="card-img-top" alt="Imagen del articulo" Style="max-width:500px;max-height:600px;" 
                            onerror="this.src='https://www.mansor.com.uy/wp-content/uploads/2020/06/imagen-no-disponible2.jpg'">
                        <%--<asp:Image ImageUrl="https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/1200px-Placeholder_view_vector.svg.png"
                        runat="server" ID="imgArticulo" CssClass="card-img-top" Width="60%" />--%>
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre") %></h5>
                            <p class="card-text"><%#Eval("Descripcion") %></p>
                            <a href="DetalleArticulo.aspx?id=<%#Eval("Id") %>">Ver detalle</a>
                            <%--<asp:Button Text="Comprar" CssClass="btn btn-secondary" ID="btnComprar" CommanArgument='<%#Eval("Id") %>' CommandName="ArticuloId" OnClick="btnComprar_Click" runat="server" />
                            --%> 
                            <asp:Button ID="btnEliminarFav" CssClass="btn" runat="server" Text="❌" 
                                CommandName="ArticuloId" CommandArgument='<%#Eval("Id")%>' OnClick="btnEliminarFav_Click"  />                        
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>
    
</asp:Content>
