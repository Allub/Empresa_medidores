using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa_DAL.DAL
{
    public class EstacionServicioDAL
    {
        private static List<EstacionServicio> estaciones = new List<EstacionServicio>();


        public void Add(EstacionServicio e)
        {
            estaciones.Add(e);
        }

        public List<EstacionServicio> GetAll()
        {
            return estaciones;
        }

        public void Remove(int id)
        {
            EstacionServicio estacionServicio = estaciones.Find(c => c.Id == id);
            estaciones.Remove(estacionServicio);
        }

        public EstacionServicio FindById(int id)
        {
            return estaciones.Find(c => c.Id == id);
        }
    }
}
