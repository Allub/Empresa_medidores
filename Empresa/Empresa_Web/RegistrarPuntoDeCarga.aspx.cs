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
    public partial class RegistrarPuntoDeCarga : System.Web.UI.Page
    {
        static PuntoCargaDAL puntodal = new PuntoCargaDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }

        protected void RegistrarBtn_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int id = Convert.ToInt32(idTxt.Text.Trim());
                int tipo = Convert.ToInt32(tipoRbl.SelectedValue);
                int capacidad = Convert.ToInt32(capacidadTxt.Text.Trim());
                DateTime vidaUtil = Convert.ToDateTime(vidaUtilTxt.Text.Trim());

                PuntoCarga pc = new PuntoCarga();
                pc.Id = id;
                pc.Tipo = tipo;
                pc.CapacidadMax = capacidad;
                pc.VidaUtil = vidaUtil;

                new PuntoCargaDAL().Add(pc);
                Response.Redirect("VerPuntosDeCarga.aspx");
            }
            else
            {

            }
        }

        protected void idCV_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string id = idTxt.Text.Trim();
            int idN;
            if (id == string.Empty)
            {
                idCV.ErrorMessage = "Debe ingresar ID del punto de carga";
                args.IsValid = false;
            }
            else
            {
                if (!int.TryParse(id, out idN))
                {
                    idCV.ErrorMessage = "El ID debe ser númerico";
                    args.IsValid = false;
                }
                else
                {
                    if (puntodal.findById(int.Parse(id)) != null)
                    {
                        idCV.ErrorMessage = "El punto de carga ya existe";
                        args.IsValid = false;
                    }
                    else
                    {
                        args.IsValid = true;
                    }
                }

            }
        }

        protected void capacidadCV_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string capacidad = capacidadTxt.Text.Trim();
            int capacidadN;
            if (capacidad == string.Empty)
            {
                capacidadCV.ErrorMessage = "Debe ingresar Capacidad Máxima vehículos";
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
    }
}