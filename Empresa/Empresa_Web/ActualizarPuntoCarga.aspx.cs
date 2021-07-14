using Empresa_DAL;
using Empresa_DAL.DAL;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Empresa_Web
{

    public partial class ActualizarPuntoCarga : System.Web.UI.Page
    {
        static PuntoCargaDAL puntoCargaDal = new PuntoCargaDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            //primera carga de pagina
            if (!IsPostBack)
            {
                //se guarda en una variable int, el string que viene desde Response de verPuntosDeCarga.aspx
                int idAEditar = Convert.ToInt32(Request.QueryString["actualizar"]);
                //PuntoCarga es igual a puntoCarga encontrado con la variable idAEditar
                PuntoCarga pc = puntoCargaDal.findById(idAEditar);
                //al textbox se le da el valor id del PuntoCarga
                idTxt.Text = pc.Id + "";
                //para que no sea editable
                idTxt.Enabled = false;
                //Al radioButton tipoRbl se le selecciona el radioButton guardado en PuntoCarga pc
                tipoRbl.SelectedValue = pc.Tipo + "";
                //al textbox se le da el valor capacidadMax del PuntoCarga
                capacidadTxt.Text = pc.CapacidadMax + "";
                //al textbox se le da el valor vidaUtil del PuntoCarga
                vidaUtilTxt.Text = Convert.ToDateTime(pc.VidaUtil)+"";
            }
        }
        protected void capacidadCV_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //se obtiene el valor del textox capacidadTxt y se guarda en variable capacidad
            string capacidad = capacidadTxt.Text.Trim();
            int capacidadN;
            //si capacidad es vacio
            if (capacidad == string.Empty)
            {
                //muestra error
                capacidadCV.ErrorMessage = "Debe ingresar Capacidad Máxima de vehículos";
                args.IsValid = false;
            }
            else
            {
                //si string capacidad no se puede conevrtir a int
                if (!int.TryParse(capacidad, out capacidadN))
                {
                    //muestra error
                    capacidadCV.ErrorMessage = "Debe ser valor númerico";
                    args.IsValid = false;
                }
                else
                {
                    //en caso contrario
                    args.IsValid = true;
                }
            }
        }

        protected void vidaUtilCV_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //se obtiene el valor del textox vidaUtilTxt y se guarda en variable fecha
            string fecha = vidaUtilTxt.Text.Trim();
            //si fecha es vacio
            if (fecha == string.Empty)
            {
                //muestra error
                vidaUtilCV.ErrorMessage = "Debe ingresar Fecha";
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void ActualizarBtn_Click(object sender, EventArgs e)
        {
            //si pagina es valida(validaciones correctas)
            if (Page.IsValid)
            {
                //se obtiene el valor del textbox idTxt y se guarda en variable int id
                int id = Convert.ToInt32(idTxt.Text.Trim());
                //se usa metodo findById para buscar y obtener PuntoCarga que cumpla con ese id 
                PuntoCarga pca = puntoCargaDal.findById(id);
                //se le asignan las nuevas variables al PuntoCarga encontrado
                pca.Tipo = Convert.ToInt32(tipoRbl.SelectedValue);
                pca.CapacidadMax = Convert.ToInt32(capacidadTxt.Text.Trim());
                pca.VidaUtil = Convert.ToDateTime(vidaUtilTxt.Text);
                //redirecciona a pagina VerPuntosDeCarga.aspx
                Response.Redirect("VerPuntosDeCarga.aspx");
            }
            
        }
    }
}