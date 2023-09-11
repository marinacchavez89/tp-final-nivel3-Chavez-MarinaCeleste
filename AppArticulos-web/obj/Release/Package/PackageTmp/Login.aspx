<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AppArticulos_web.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .validacion {
            color: red;
            font-size: 12px;
        }
    </style>    

    <script>

        function validar() {
            //capturar el control
            const txtPassword = document.getElementById("txtPassword");
            
            if (txtPassword.value == "") {
                txtPassword.classList.add("is-invalid");
                txtPassword.classList.remove("is-valid");
                
                return false;
            }
            txtPassword.classList.remove("is-invalid");
            txtPassword.classList.add("is-valid");
            return true;
        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-4">
            <h2>¡Inicia sesión!</h2>
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />
                <asp:RegularExpressionValidator ErrorMessage="Ingrese formato de Email válido. Ej. perez@gmail.com" CssClass="validacion" ControlToValidate="txtEmail" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" runat="server" />
            </div>
            <div class="mb-3">
                <label class="form-label">Contraseña</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtPassword" TextMode="Password" ClientIDMode="Static" />
            </div>
            <div class="mb-3">
                <asp:Button Text="Ingresar" CssClass="btn btn-secondary" ID="btnLogin" OnClientClick="return validar()" OnClick="btnLogin_Click" runat="server" />
                <a href="/">Cancelar</a>
            </div>
        </div>
    </div>

</asp:Content>
