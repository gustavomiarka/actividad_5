
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServicioLibrary.Models;


namespace ServicioLibrary.Repositories
{
    public class ServicioRepository : IServicioRepository
    {
        private readonly db_turnosContext _db_turnosContext;
        public ServicioRepository(db_turnosContext db_TurnosContext) 
        {
            _db_turnosContext = db_TurnosContext;
        }

        public bool Add(TServicio servicio)
        {
            //try
            //{
                _db_turnosContext.TServicios.Add(servicio);
                return _db_turnosContext.SaveChanges() > 0;
            //}
            //catch (Exception)
            //{
            //    throw new Exception("Error al insertar un nuevo servicio");
            //}
            
            
        }

        public bool Delete(int id)
        {
            try
            {
                var entity = _db_turnosContext.TServicios.Find(id);
                entity.Activo = "N";
                _db_turnosContext.Update(entity);
                return _db_turnosContext.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw new Exception("Error al eliminar el servicio");
            }
            
        }

        public List<TServicio> GetAll()
        {
            try
            {
                return _db_turnosContext.TServicios.Where(s => s.Activo == "S").ToList();
            }
            catch (Exception)
            {

                throw new Exception("Error al cargar la lista. vuelva a intentarlo");
            }
            
        }

        public List<TServicio> GetAllInactivos()
        {
            try
            {
                return _db_turnosContext.TServicios.Where(s => s.Activo == "N").ToList();
            }
            catch (Exception)
            {

                throw new Exception("Error al cargar la lista. vuelva a intentarlo");
            }
            
        }

        public bool GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(TServicio servicio)
        {
            try
            {
                var entity = _db_turnosContext.TServicios.Find(servicio);
                entity.Nombre = servicio.Nombre;
                entity.EnPromocion = servicio.EnPromocion;
                entity.Costo = servicio.Costo;
                entity.Activo = servicio.Activo;
                _db_turnosContext.Update(entity);
                return _db_turnosContext.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw new Exception("Error al editar el servicio");
            }
            
        }
    }
}
