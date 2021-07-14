using Empresa_DAL;
using Empresa_DAL.DAL;
using System;
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
            //si pagina es valida(validaciones correctas)
            if (Page.IsValid)
            {
                //se obtiene el valor del textbox idTxt y se guarda en variable int id
                int id = Convert.ToInt32(idTxt.Text.Trim());
                //se obtiene el valor del radioButton tipoRbl y se guarda en variable int tipo
                int tipo = Convert.ToInt32(tipoRbl.SelectedValue);
                //se obtiene el valor del textbox capacidadTxt y se guarda en variable int capacidad
                int capacidad = Convert.ToInt32(capacidadTxt.Text.Trim());
                //se obtiene el valor del textbox idTxt y se guarda en variable int id
                DateTime vidaUtil = Convert.ToDateTime(vidaUtilTxt.Text.Trim());

                //crea un nuevo objeto tipo PuntoCarga
                PuntoCarga pc = new PuntoCarga();
                //se asignan las variables obtenidas al objeto PuntoCarga
                pc.Id = id;
                pc.Tipo = tipo;
                pc.CapacidadMax = capacidad;
                pc.VidaUtil = vidaUtil;
                //se guarda objeto en lista puntosCarga
                new PuntoCargaDAL().Add(pc);
                //redirecciona a pagina VerPuntosDeCarga.aspx
                Response.Redirect("VerPuntosDeCarga.aspx");
            }
            else
            {

            }
        }

        protected void idCV_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //se guarda en variable id, el valor obtenido del textbox idTxt
            string id = idTxt.Text.Trim();
            int idN;
            //si id es vacio
            if (id == string.Empty)
            {
                //muestra error
                idCV.ErrorMessage = "Debe ingresar ID del punto de carga";
                args.IsValid = false;
            }
            else
            {
                //si no se puede convertir la variable string id a int
                if (!int.TryParse(id, out idN))
                {
                    //muestra error
                    idCV.ErrorMessage = "El ID debe ser númerico";
                    args.IsValid = false;
                }
                else
                {
                    // si encuentra la variable id en la lista PuntosCarga
                    if (puntodal.findById(int.Parse(id)) != null)
                    {
                        //muestra error
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
            //se obtiene el valor del texbox capacidadTxt y se guarda en variable capacidad
            string capacidad = capacidadTxt.Text.Trim();
            int capacidadN;
            //si capacidad es vacio
            if (capacidad == string.Empty)
            {
                //muestra error
                capacidadCV.ErrorMessage = "Debe ingresar Capacidad Máxima vehículos";
                args.IsValid = false;
            }
            else
            {
                //si string capacidad no se puede convertir a int
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
            //se obtiene el valor del texbox vidaUtilTxt y se guarda en variable fecha
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

            }
        }
    }
}