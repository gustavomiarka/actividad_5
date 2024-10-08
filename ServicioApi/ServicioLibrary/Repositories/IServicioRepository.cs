
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServicioLibrary.Models;

namespace ServicioLibrary.Repositories
{
    public interface IServicioRepository
    {
        List<TServicio> GetAll();
        bool GetById(int id);
        bool Add(TServicio servicio);
        bool Update(TServicio servicio);
        bool Delete(int id);
        List<TServicio> GetAllInactivos();
    }
}
