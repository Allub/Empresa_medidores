using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa_DAL.DAL
{
    public class PuntoCargaDAL
    {
        //Lista estatica de puntosCarga
        private static List<PuntoCarga> puntosCarga = new List<PuntoCarga>();

        //metodo agregar PuntoCarga a lista puntosCarga
        public void Add(PuntoCarga p)
        {
            puntosCarga.Add(p);
        }
        //metodo para obtener todaos los puntosCarga
        public List<PuntoCarga> GetAll()
        {
            return puntosCarga;
        }
        /*metodo para obtener todaos los puntosCarga
         * que cumplan con ese parametro
        */
        public List<PuntoCarga> GetAll(int tipo)
        {
            return puntosCarga.FindAll(c => c.Tipo == tipo);
        }

        /*Metodo para buscar un PuntoCarga
         * recibe parametro id
         * busca puntoCarga con esa id y devuelve ese PuntoCarga
         */
        public PuntoCarga findById(int id)
        {
            return puntosCarga.Find(c => c.Id == id);
        }
    }
}
