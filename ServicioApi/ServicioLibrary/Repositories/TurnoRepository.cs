using Azure.Messaging;
using Microsoft.EntityFrameworkCore;
using ServicioLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLibrary.Repositories
{
    public class TurnoRepository : ITurnoRepository
    {
        private readonly db_turnosContext _db_TurnosContext;

        public TurnoRepository(db_turnosContext db_TurnosContext)
        {
            _db_TurnosContext = db_TurnosContext;
        }
        public bool Add(TTurno turno)
        {
            _db_TurnosContext.TTurnos.Add(turno);
            return _db_TurnosContext.SaveChanges() >0;
        }

        public bool Delete(int id, DateTime fecha, string motivo)
        {
            var entity = _db_TurnosContext.TTurnos.Find(id);
            if (entity != null) 
            { 
                entity.FechaCancelacion = fecha;
                entity.MotivoCancelacion = motivo;
                _db_TurnosContext.TTurnos.Update(entity);
                
            }
            return _db_TurnosContext.SaveChanges() > 0;
        }

        public async Task<List<TTurno>> GetAll()
        {
            return await _db_TurnosContext.TTurnos.Where(t => t.FechaCancelacion == null && string.IsNullOrEmpty(t.MotivoCancelacion)).ToListAsync();
        }

        public List<TTurno> GetAllCancelados()
        {
            return _db_TurnosContext.TTurnos.Where(t => t.FechaCancelacion.HasValue && !string.IsNullOrEmpty(t.MotivoCancelacion)).ToList();
            
        }

        public bool GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(TTurno turno)
        {
            var entity = _db_TurnosContext.TTurnos.Find(turno);
            entity.Cliente = turno.Cliente;
            entity.Hora = turno.Hora;
            entity.MotivoCancelacion = turno.MotivoCancelacion;
            entity.FechaCancelacion = turno.FechaCancelacion;
            entity.Cliente = turno.Cliente.ToString();
            _db_TurnosContext.TTurnos.Update(entity);
            return _db_TurnosContext.SaveChanges() > 0;
        }
    }
}
