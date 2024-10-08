using ServicioLibrary.Models;
using ServicioLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLibrary.Services
{
    public class TurnoService : ITurnoService
    {
        private readonly ITurnoRepository _turnoRepository;

        public TurnoService(ITurnoRepository turnoRepository)
        {
            _turnoRepository = turnoRepository;
        }
        public bool Add(TTurno turno)
        {
            return _turnoRepository.Add(turno);
        }

        public bool Delete(int id, DateTime fecha, string motivo)
        {
            return _turnoRepository.Delete(id, fecha, motivo);
        }

        public async Task<TTurno> GetAll()
        {
            return await _turnoRepository.GetAll();
        }

        public List<TTurno> GetAllCancelados()
        {
            return _turnoRepository.GetAllCancelados();
        }

        public bool GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(TTurno turno)
        {
            return _turnoRepository.Update(turno);
        }
    }
}
