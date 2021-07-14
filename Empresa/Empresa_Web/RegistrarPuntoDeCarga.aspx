<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="RegistrarPuntoDeCarga.aspx.cs" Inherits="Empresa_Web.RegistrarPuntoDeCarga" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="bg-light">
 <div class="col-xl-3">
        <asp:Label ID="MensajeLbl" CssClass="Text-success H1" runat="server"></asp:Label>
    </div>
    <div class="container offset-4 bg-light">

        <div class="card-header bg-dark text-white col-xl-3">
            Ingresar Punto de Carga
        </div>
       
            <div class="form-group col-xl-3">
                <label class="control-label" for="idTxt">ID del Punto de Carga</label>
                <asp:TextBox ID="idTxt" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:customvalidator ID="idCV" runat="server" errormessage="CustomValidator" ValidateEmptyText="true"
                    CssClass="text-danger" ControlToValidate="idTxt" OnServerValidate="idCV_ServerValidate"
                    ></asp:customvalidator>

            </div>
            <div class="form-group col-xl-3">
                <label class="control-label" for="tipoRbl">Tipo</label>
                <asp:RadioButtonList ID="tipoRbl" runat="server" CssClass="form-control">
                    <asp:ListItem Value="1" Selected="True" Text="Eléctrico"></asp:ListItem>
                    <asp:ListItem Value="2" Text="Dual"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="form-group col-xl-3">
                <label class="control-label" for="capacidadTxt">Capacidad Máxima de Vehículos</label>
                <asp:TextBox ID="capacidadTxt" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:CustomValidator ID="capacidadCV" runat="server" ErrorMessage="CustomValidator" ValidateEmptyText="true"
                    CssClass="text-danger" ControlToValidate="capacidadTxt" OnServerValidate="capacidadCV_ServerValidate"
                    ></asp:CustomValidator>
            </div>
            <div class="form-group col-xl-3">
                <label class="control-label" for="vidaUtilTxt">Fecha en que deber ser remplazado</label>
                <asp:TextBox ID="vidaUtilTxt" runat="server" CssClass="form-control" placeholder="dd-MM-AAAA"></asp:TextBox>
                <asp:CustomValidator ID="vidaUtilCV" runat="server" ErrorMessage="CustomValidator" ValidateEmptyText="true"
                    CssClass="text-danger" ControlToValidate="vidaUtilTxt" OnServerValidate="vidaUtilCV_ServerValidate"
                    
                    ></asp:CustomValidator>
                
            </div>
    


      
        <br />
            <div > 
        <asp:Button ID="RegistrarBtn" runat="server" Text="Registrar Estación" CssClass="btn btn-dark" OnClick="RegistrarBtn_Click" />
        </div>

            
        

           
    </div>
    </div>
</asp:Content>
