using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa_DAL.DAL
{
    public class PuntoCargaDAL
    {
        private static List<PuntoCarga> puntosCarga = new List<PuntoCarga>();

        public void Add(PuntoCarga p)
        {
            puntosCarga.Add(p);
        }

        public List<PuntoCarga> GetAll()
        {
            return puntosCarga;
        }

        public List<PuntoCarga> GetAll(int tipo)
        {
            return puntosCarga.FindAll(c => c.Tipo == tipo);
        }

        public PuntoCarga findById(int id)
        {
            return puntosCarga.Find(c => c.Id == id);
        }
    }
}
