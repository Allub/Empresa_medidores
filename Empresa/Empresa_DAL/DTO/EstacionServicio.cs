using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa_DAL
{
    public class EstacionServicio
    {
        private int id;
        private string direccion;
        private int capacidadMax;
        private string region;
        private string horarioAtencion;

        public string Direccion { get => direccion; set => direccion = value; }
        public int CapacidadMax { get => capacidadMax; set => capacidadMax = value; }
        public string Region { get => region; set => region = value; }
        public int Id { get => id; set => id = value; }
        public string HorarioAtencion { get => horarioAtencion; set => horarioAtencion = value; }
    }
}
