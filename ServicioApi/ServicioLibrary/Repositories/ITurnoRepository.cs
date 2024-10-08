using ServicioLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLibrary.Repositories
{
    public interface ITurnoRepository
    {
        Task<TTurno> GetAll();
        bool GetById(int id);
        bool Add(TTurno turno);
        bool Update(TTurno turno);
        bool Delete(int id, DateTime fecha, string motivo);
        List<TTurno> GetAllCancelados();
    }
}
