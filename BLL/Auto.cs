using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Auto : BE.ICrud<BE.Auto>
    {
        DAL.Auto DALAuto = new DAL.Auto();

        public bool Agregar(BE.Auto objAdd)
        {
            return DALAuto.Agregar(objAdd);
        }
        public List<BE.Auto> Listar()
        {
            return DALAuto.Listar();
        }
        public bool Actualizar(BE.Auto objActualizar)
        {
            return DALAuto.Actualizar(objActualizar);
        }

        public bool Borrar(BE.Auto objBorrar)
        {
            return DALAuto.Borrar(objBorrar);
        }
    }
}
