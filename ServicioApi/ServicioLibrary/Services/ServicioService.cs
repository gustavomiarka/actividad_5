
using ServicioLibrary.Models;
using ServicioLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLibrary.Services
{
    public class ServicioService : IServicioService
    { 
        private readonly IServicioRepository _servicioRepository;

        public ServicioService(IServicioRepository servicioRepository)
        {
            _servicioRepository = servicioRepository;
        }

        public bool Add(TServicio servicio)
        {
            return _servicioRepository.Add(servicio);
        }

        public bool Delete(int id)
        {
            return (_servicioRepository.Delete(id));
        }

        public List<TServicio> GetAll()
        {
            return _servicioRepository.GetAll();
        }

        public List<TServicio> GetAllInactivos()
        {
            return _servicioRepository.GetAllInactivos();
        }


        public bool GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(TServicio servicio)
        {
            return _servicioRepository.Update(servicio);
        }
    }
}
