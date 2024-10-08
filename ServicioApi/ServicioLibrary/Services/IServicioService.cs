
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServicioLibrary.Models;

namespace ServicioLibrary.Services
{
    public interface IServicioService 
    { 
        List<TServicio> GetAll();
        bool GetById(int id);
        bool Add(TServicio servicio);
        bool Update(TServicio servicio);
        bool Delete(int id);
        List<TServicio> GetAllInactivos();
    }
}
