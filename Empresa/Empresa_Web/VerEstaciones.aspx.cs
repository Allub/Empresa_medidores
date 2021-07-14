using Empresa_DAL;
using Empresa_DAL.DAL;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Empresa_Web
{
    public partial class VerEstaciones : System.Web.UI.Page
    {
        EstacionServicioDAL estacionDAL = new EstacionServicioDAL();

        private void CargarTabla(List<EstacionServicio> estaciones)
        {
            EstacionesGrid.DataSource = estaciones;
            EstacionesGrid.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTabla(estacionDAL.GetAll());
            }
        }

        protected void EstacionesGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "eliminar")
            {
                string idAEliminar = e.CommandArgument.ToString();
                estacionDAL.Remove(Convert.ToInt32(idAEliminar));

                CargarTabla(estacionDAL.GetAll());
            }
        }

        protected void AñadirNBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistrarEstacion.aspx");
        }
    }
}