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

    public partial class ActualizarPuntoCarga : System.Web.UI.Page
    {
        static PuntoCargaDAL puntoCargaDal = new PuntoCargaDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int idAEditar = Convert.ToInt32(Request.QueryString["actualizar"]);
                PuntoCarga pc = puntoCargaDal.findById(idAEditar);
                idTxt.Text = pc.Id + "";
                idTxt.Enabled = false;
                tipoRbl.SelectedValue = pc.Tipo + "";
                capacidadTxt.Text = pc.CapacidadMax + "";
                vidaUtilTxt.Text = Convert.ToDateTime(pc.VidaUtil)+"";
            }
        }
        protected void capacidadCV_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string capacidad = capacidadTxt.Text.Trim();
            int capacidadN;
            if (capacidad == string.Empty)
            {
                capacidadCV.ErrorMessage = "Debe ingresar Capacidad Máxima de vehículos";
                args.IsValid = false;
            }
            else
            {
                if (!int.TryParse(capacidad, out capacidadN))
                {
                    capacidadCV.ErrorMessage = "Debe ser valor númerico";
                    args.IsValid = false;
                }
                else
                {
                    args.IsValid = true;
                }
            }
        }

        protected void vidaUtilCV_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string fecha = vidaUtilTxt.Text.Trim();
            if (fecha == string.Empty)
            {
                vidaUtilCV.ErrorMessage = "Debe ingresar Fecha";
                args.IsValid = false;
            }
            else
            {

            }
        }

        protected void ActualizarBtn_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int id = Convert.ToInt32(idTxt.Text.Trim());

                PuntoCarga pca = puntoCargaDal.findById(id);
                pca.Tipo = Convert.ToInt32(tipoRbl.SelectedValue);
                pca.CapacidadMax = Convert.ToInt32(capacidadTxt.Text.Trim());
                pca.VidaUtil = Convert.ToDateTime(vidaUtilTxt.Text);
                Response.Redirect("VerPuntosDeCarga.aspx");
            }
            
        }
    }
}