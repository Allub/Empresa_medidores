using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa_DAL.DAL
{
    public class EstacionServicioDAL
    {
        //Lista estatica de estaciones
        private static List<EstacionServicio> estaciones = new List<EstacionServicio>();

        //metodo agregar EstacionServicio a lista estaciones
        public void Add(EstacionServicio e)
        {
            estaciones.Add(e);
        }
        //metodo para obtener todas las estaciones 
        public List<EstacionServicio> GetAll()
        {
            return estaciones;
        }
        /*metodo que elimina una estacion de servicio
         * recibe parametro id
         * se busca y obtiene estacion con esa id en lista estaciones
         * elimina esa estacion de la lista estaciones
        */
        public void Remove(int id)
        {
            EstacionServicio estacionServicio = estaciones.Find(c => c.Id == id);
            estaciones.Remove(estacionServicio);
        }
        /*Metodo para buscar una estacion
         * recibe parametro id
         * busca estacion con esa id y devuelve esta estacion
         */ 
        public EstacionServicio FindById(int id)
        {
            return estaciones.Find(c => c.Id == id);
        }
    }
}
