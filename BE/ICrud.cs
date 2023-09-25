using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public interface ICrud <T>
    {
        bool Agregar (T objAdd);
        List<T> Listar ();
        bool Actualizar(T objActualizar);
        bool Borrar(T objBorrar);
    }
}
