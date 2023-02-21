<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="AppArticulos_web.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--<h2>Hola, ¡ups, hubo un error!</h2>
    <asp:Label Text="" ID="lblError" runat="server" />--%>

    <div style="display: flex; justify-content: center;">

        <div class="card  mb-3" style="width: 18rem; text-align: center; justify-content: center">
            <img src="https://us.123rf.com/450wm/alexwhite/alexwhite1505/alexwhite150506935/40220252-exclamaci%C3%B3n-signo-violeta-icono-de-se%C3%B1al-de-advertencia-s%C3%ADmbolo-de-alerta.jpg" class="card-img-top" alt="Error">
            <div class="card-body">
                <h5 class="card-title">Hola, ¡ups, hubo un error!</h5>
                <asp:Label Text="" ID="lblError" runat="server" CssClass="card-text" />
                <div style="padding: 20px;">
                    <a href="Default.aspx" class="btn btn-secondary">Home</a>
                </div>
            </div>
        </div>

    </div>

    <%-- <div class="card mb-3" style="text-align: center;">
        <img style="width: 80px; height: 80px; justify-items:center;" src="https://us.123rf.com/450wm/alexwhite/alexwhite1505/alexwhite150506935/40220252-exclamaci%C3%B3n-signo-violeta-icono-de-se%C3%B1al-de-advertencia-s%C3%ADmbolo-de-alerta.jpg" class="card-img-top" alt="Error">
        <div class="card-body">
            <h5 class="card-title">Hola, ¡ups, hubo un error!</h5>
            <asp:Label Text="" ID="lblError" runat="server" CssClass="card-text" />            
        </div>
    </div>--%>
</asp:Content>
