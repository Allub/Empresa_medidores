using Empresa_DAL;
using Empresa_DAL.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Empresa_Web
{
    public partial class VerPuntosDeCarga : System.Web.UI.Page
    {
        PuntoCargaDAL puntosDAL = new PuntoCargaDAL();

        private void CargarTabla(List<PuntoCarga> puntosCargas)
        {
            PuntosCargaGrid.DataSource = puntosCargas;
            PuntosCargaGrid.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTabla(puntosDAL.GetAll());
            }
        }

        protected void PuntosCargaGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "actualizar")
            {
               
                Response.Redirect("ActualizarPuntoCarga.aspx?actualizar=" +e.CommandArgument.ToString());
            }
        }

        protected void tipoDbl_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tipoSel = Convert.ToInt32(tipoDbl.SelectedValue);

            List<PuntoCarga> filtrada = puntosDAL.GetAll(tipoSel);
            CargarTabla(filtrada);
        }

        protected void todosChx_CheckedChanged(object sender, EventArgs e)
        {
            tipoDbl.Enabled = !todosChx.Checked;

            if (todosChx.Checked)
            {
                CargarTabla(puntosDAL.GetAll());
            }
        }

        protected void AñadirNuevoBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistrarPuntoDeCarga.aspx");
        }
    }
}