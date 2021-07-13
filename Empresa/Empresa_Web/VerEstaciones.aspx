<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="VerEstaciones.aspx.cs" Inherits="Empresa_Web.VerEstaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="mt-5 col-xl-8 offset-2">

        <asp:GridView ID="EstacionesGrid" runat="server"
            AutoGenerateColumns="false" CssClass="table table-striped table-hover" OnRowCommand="EstacionesGrid_RowCommand"           
            EmptyDataText="No hay Estaciones de Servicio registradas"
            >
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="Id" />
                <asp:BoundField HeaderText="Dirección" DataField="Direccion" />
                <asp:BoundField HeaderText="Capacidad Máxima de puntos de carga" DataField="CapacidadMax" />
                <asp:BoundField HeaderText="Región donde se ubica" DataField="Region" />
                <asp:BoundField HeaderText="Horario de atención" DataField="HorarioAtencion" />
                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>                           
                        <asp:LinkButton ID="LinkButton1" CssClass="btn btn-outline-secondary"  runat="server" CommandName="eliminar" 
                            CommandArgument='<%# Eval("Id") %>'>
                            <i class="bi bi-trash"></i>                       
                        </asp:LinkButton>
                    </ItemTemplate>

                </asp:TemplateField>
            </Columns>        


        </asp:GridView>

        <div > 
        <asp:Button ID="AñadirNBtn" runat="server" Text="Añadir nuevo" CssClass="btn btn-dark" OnClick="AñadirNBtn_Click" />
        </div>
    </div>
    


</asp:Content>
