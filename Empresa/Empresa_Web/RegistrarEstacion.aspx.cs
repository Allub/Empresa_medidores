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
    public partial class RegistrarEstacion : System.Web.UI.Page
    {
        static EstacionServicioDAL dal = new EstacionServicioDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
            if (Page.IsValid)
            {
                int id = Convert.ToInt32(idTxt.Text.Trim());
                string direccion = direccionTxt.Text.Trim();
                int capacidad = Convert.ToInt32(capacidadTxt.Text.Trim());
                string region = regionDdl.SelectedValue.ToString();
                string horario = aperturaTxt.Text +"-"+ cierreTxt.Text;

                EstacionServicio es = new EstacionServicio();
                es.Id = id;
                es.Direccion = direccion;
                es.CapacidadMax = capacidad;
                es.Region = region;
                es.HorarioAtencion = horario;

                new EstacionServicioDAL().Add(es);
                Response.Redirect("VerEstaciones.aspx");
           
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
                idCV.ErrorMessage = "Debe ingresar ID de la Estación";
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
                    if (dal.FindById(int.Parse(id)) != null)
                    {
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
            string capacidad = capacidadTxt.Text.Trim();
            int capacidadN;
            if (capacidad == string.Empty)
            {
                capacidadCV.ErrorMessage = "Debe ingresar Capacidad Máxima de Puntos de Carga";
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

        protected void direccionCV_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string direccion = direccionTxt.Text.Trim();
            if (direccion == string.Empty)
            {
                direccionCV.ErrorMessage = "Debe ingresar dirección de la Estación de Servicio";
                args.IsValid = false;
            }
        }

        protected void regionCV_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string region = regionDdl.SelectedValue.ToString();
            if (region == "error")
            {
                regionCV.ErrorMessage = "Debe seleccionar una Región";
                args.IsValid = false;
            }
        }

        protected void aperturaCV_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string apertura = aperturaTxt.Text.Trim();
            if (apertura == string.Empty)
            {
                aperturaCV.ErrorMessage = "Debe ingresar horario de apertura";
                args.IsValid = false;
            }
            else
            {
                string[] aperturaArray = apertura.Split(':');
                if (aperturaArray.Length == 2)
                {
                    if (aperturaArray[0].Length !=2 || aperturaArray[1].Length !=2)
                    {
                        aperturaCV.ErrorMessage = "El formato de hora es: 00:00";
                        args.IsValid = false;
                    }
                    else
                    {
                        int horas = Convert.ToInt32(aperturaArray[0]);
                        int minutos = Convert.ToInt32(aperturaArray[1]);
                        if (horas < 0 || horas > 24 || minutos < 0 || minutos > 59)
                        {
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
            string cierre = cierreTxt.Text.Trim();
            if (cierre == string.Empty)
            {
                cierreCV.ErrorMessage = "Debe ingresar horario de cierre";
                args.IsValid = false;
            }
            else
            {
                string[] cierreArray = cierre.Split(':');
                if (cierreArray.Length == 2)
                {
                    if (cierreArray[0].Length != 2 || cierreArray[1].Length != 2)
                    {
                        cierreCV.ErrorMessage = "El formato de hora es: 00:00";
                        args.IsValid = false;
                    }
                    else
                    {
                        int horas = Convert.ToInt32(cierreArray[0]);
                        int minutos = Convert.ToInt32(cierreArray[1]);
                        if (horas < 0 || horas > 24 || minutos < 0 || minutos > 59)
                        {
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