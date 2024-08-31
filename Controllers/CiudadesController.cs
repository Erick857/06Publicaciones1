using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _06Publicaciones.Models;
using System.Data;

namespace _06Publicaciones.Controllers
{
    public class CiudadesController
    {
        CiudadesModel _ciudadesModel = new CiudadesModel();

        public DataTable todosconrelacion()
        {
            return _ciudadesModel.todosconrelacion();
        }

        public bool Create(string nombreCiudad, int idPais)
        {
            return _ciudadesModel.Create(nombreCiudad, idPais);
        }

        public bool Update(string id, string nombreCiudad, int idPais)
        {
            return _ciudadesModel.Update(id, nombreCiudad, idPais);
        }
        public bool Delete(int id)
        {
            return _ciudadesModel.Delete(id);
        }

    }
}