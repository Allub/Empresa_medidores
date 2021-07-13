<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="VerPuntosDeCarga.aspx.cs" Inherits="Empresa_Web.VerPuntosDeCarga" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="mt-5 col-xl-8 offset-2">
    <div >
    <asp:DropDownList ID="tipoDbl" runat="server" Enabled="false"
        AutoPostBack="true" OnSelectedIndexChanged="tipoDbl_SelectedIndexChanged"
        >
        <asp:ListItem Value="1" Selected="true" Text="Eléctrico"></asp:ListItem>
        <asp:ListItem Value="2" text="Dual"></asp:ListItem>
    </asp:DropDownList>
        <asp:CheckBox ID="todosChx" Checked="true" runat="server" 
            AutoPostBack="true" OnCheckedChanged="todosChx_CheckedChanged" Text="Ver Todos"
            />
    </div>

<div class="mt-5">

        <asp:GridView ID="PuntosCargaGrid" runat="server"
            AutoGenerateColumns="false" CssClass="table table-striped table-hover" OnRowCommand="PuntosCargaGrid_RowCommand"         
            EmptyDataText="No hay Puntos de carga registrados"
            >
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="Id" />
                <asp:BoundField HeaderText="Tipo" DataField="Tipo" />
                <asp:BoundField HeaderText="Capacidad máxima de vehículos" DataField="CapacidadMax" />
                <asp:BoundField HeaderText="Fecha cuando debe ser remplazado" DataField="VidaUtil" />
                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>                           
                        <asp:LinkButton ID="LinkButton1" CssClass="btn btn-outline-secondary"  runat="server" CommandName="actualizar" 
                            CommandArgument='<%# Eval("Id") %>'>
                            <i class="bi bi-arrow-clockwise"></i>                      
                        </asp:LinkButton>
                    </ItemTemplate>

                </asp:TemplateField>
            </Columns>        


        </asp:GridView>


    </div>
        <div > 
        <asp:Button ID="AñadirNuevoBtn" runat="server" Text="Añadir nuevo" CssClass="btn btn-dark" OnClick="AñadirNuevoBtn_Click" />
        </div>
        </div>
</asp:Content>
