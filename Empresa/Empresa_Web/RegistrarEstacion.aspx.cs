using Empresa_DAL;
using Empresa_DAL.DAL;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Empresa_Web
{
    public partial class RegistrarEstacion : System.Web.UI.Page
    {
        static EstacionServicioDAL dal = new EstacionServicioDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            //primera carga de pagina
            if (!IsPostBack)
            {
                //elementos que iran en el DropDownList regionDdl
                regionDdl.Items.Insert(0, new ListItem("Selecciona Región", "error"));
                regionDdl.Items.Insert(1, new ListItem("Arica y Parinacota", "Arica y Parinacota"));
                regionDdl.Items.Insert(2, new ListItem("Tarapacá", "Tarapacá"));
                regionDdl.Items.Insert(3, new ListItem("Antofagasta", "Antofagasta"));
                regionDdl.Items.Insert(4, new ListItem("Atacama", "Atacama"));
                regionDdl.Items.Insert(5, new ListItem("Coquimbo", "Coquimbo"));
                regionDdl.Items.Insert(6, new ListItem("Valparaíso", "Valparaíso"));
                regionDdl.Items.Insert(7, new ListItem("Santiago", "Santiago"));
                regionDdl.Items.Insert(8, new ListItem("O’Higgins", "O’Higgins"));
                regionDdl.Items.Insert(9, new ListItem("Maule", "Maule"));
                regionDdl.Items.Insert(10, new ListItem("Ñuble", "Ñuble"));
                regionDdl.Items.Insert(11, new ListItem("Biobío", "Biobío"));
                regionDdl.Items.Insert(12, new ListItem("La Araucanía", "La Araucanía"));
                regionDdl.Items.Insert(13, new ListItem("Los Ríos", "Los Ríos"));
                regionDdl.Items.Insert(14, new ListItem("Los Lagos", "Los Lagos"));
                regionDdl.Items.Insert(15, new ListItem("Aysén", "Aysén"));
                regionDdl.Items.Insert(16, new ListItem("Magallanes", "Magallanes"));
            }

        }

        protected void RegistrarBtn_Click(object sender, EventArgs e)
        {
            //si pagina es valida(validaciones correctas)
            if (Page.IsValid)
            {
                //se obtiene el valor del textbox idTxt y se guarda en variable int id
                int id = Convert.ToInt32(idTxt.Text.Trim());
                //se obtiene el valor del textbox direccionTxt y se guarda en variable string direccion
                string direccion = direccionTxt.Text.Trim();
                //se obtiene el valor del textbox caoacidadTxt y se guarda en variable int capacidad
                int capacidad = Convert.ToInt32(capacidadTxt.Text.Trim());
                //se obtiene el valor del dropDownList regionDdl y se guarda en variable string region
                string region = regionDdl.SelectedValue.ToString();
                //se obtiene el valor del textbox aperturaTxt y cierreTxt y se guarda en variable string horario
                string horario = aperturaTxt.Text + "-" + cierreTxt.Text;

                //crea un nuevo objeto tipo EstacionServicio
                EstacionServicio es = new EstacionServicio();
                //se asignan las variables obtenidas al objeto EstacionServicio
                es.Id = id;
                es.Direccion = direccion;
                es.CapacidadMax = capacidad;
                es.Region = region;
                es.HorarioAtencion = horario;
                //se guarda objeto en lista estacionesServicio
                new EstacionServicioDAL().Add(es);
                //redirecciona a pagina VerEstaciones.aspx
                Response.Redirect("VerEstaciones.aspx");

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
                idCV.ErrorMessage = "Debe ingresar ID de la Estación";
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
                    // si encuentra la variable id en la lista Estaciones
                    if (dal.FindById(int.Parse(id)) != null)
                    {
                        //muestra error
                        idCV.ErrorMessage = "La estación de servicio ya existe";
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
            //se obtiene el valor del textox capacidadTxt y se guarda en variable capacidad
            string capacidad = capacidadTxt.Text.Trim();
            int capacidadN;
            //si capacidad es vacio
            if (capacidad == string.Empty)
            {
                //muestra error
                capacidadCV.ErrorMessage = "Debe ingresar Capacidad Máxima de Puntos de Carga";
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

        protected void direccionCV_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //se obtiene el valor del texbox direccionTxt y se guarda en variable direccion
            string direccion = direccionTxt.Text.Trim();
            //si direccion es vacio
            if (direccion == string.Empty)
            {
                //muestra error
                direccionCV.ErrorMessage = "Debe ingresar dirección de la Estación de Servicio";
                args.IsValid = false;
            }
        }

        protected void regionCV_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //se obtiene el valor seleccionado del DropDownList regionDdl y se guarda en variable region
            string region = regionDdl.SelectedValue.ToString();
            //si region es igual a error(la variable sin datos en Ddl, da el valor error)
            if (region == "error")
            {
                //muestra error
                regionCV.ErrorMessage = "Debe seleccionar una Región";
                args.IsValid = false;
            }
        }

        protected void aperturaCV_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //se obtiene el valor del texbox aperturaTxt y se guarda en variable apertura
            string apertura = aperturaTxt.Text.Trim();
            //si apertura es vacio
            if (apertura == string.Empty)
            {
                //muestra error
                aperturaCV.ErrorMessage = "Debe ingresar horario de apertura";
                args.IsValid = false;
            }
            else
            {
                //se crea Array
                string[] aperturaArray = apertura.Split(':');
                //si la cantidad de variables del array es 2
                if (aperturaArray.Length == 2)
                {
                    //si la variable en posicion 0 y 1 de la array es distinto a 2
                    if (aperturaArray[0].Length != 2 || aperturaArray[1].Length != 2)
                    {
                        //muestra error
                        aperturaCV.ErrorMessage = "El formato de hora es: 00:00";
                        args.IsValid = false;
                    }
                    else
                    {
                        //se guarda en variables horas y minutos, las variables de posicion 0 y 1 de la array
                        int horas = Convert.ToInt32(aperturaArray[0]);
                        int minutos = Convert.ToInt32(aperturaArray[1]);
                        //si horas es menor a 0 o mayor a 24 o minutos menor a 0 o mayor a 59
                        if (horas < 0 || horas > 24 || minutos < 0 || minutos > 59)
                        {
                            //muestra error
                            aperturaCV.ErrorMessage = "Error en el horario ingresado";
                            args.IsValid = false;
                        }
                        else
                        {
                            args.IsValid = true;
                        }
                    }
                }
            }

        }

        protected void cierreCV_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //se obtiene el valor del texbox cierreTxt y se guarda en variable cierre
            string cierre = cierreTxt.Text.Trim();
            //si cierre es vacio
            if (cierre == string.Empty)
            {
                //muestra error
                cierreCV.ErrorMessage = "Debe ingresar horario de cierre";
                args.IsValid = false;
            }
            else
            {
                //se crea Array
                string[] cierreArray = cierre.Split(':');
                //si la cantidad de variables del array es 2
                if (cierreArray.Length == 2)
                {
                    //si la variable en posicion 0 y 1 de la array es distinto a 2
                    if (cierreArray[0].Length != 2 || cierreArray[1].Length != 2)
                    {
                        //muestra error
                        cierreCV.ErrorMessage = "El formato de hora es: 00:00";
                        args.IsValid = false;
                    }
                    else
                    {
                        //se guarda en variables horas y minutos, las variables de posicion 0 y 1 de la array
                        int horas = Convert.ToInt32(cierreArray[0]);
                        int minutos = Convert.ToInt32(cierreArray[1]);
                        //si horas es menor a 0 o mayor a 24 o minutos menor a 0 o mayor a 59
                        if (horas < 0 || horas > 24 || minutos < 0 || minutos > 59)
                        {
                            //muestra error
                            cierreCV.ErrorMessage = "Error en el horario ingresado";
                            args.IsValid = false;
                        }
                        else
                        {
                            args.IsValid = true;
                        }
                    }
                }
            }
        }
    }
}