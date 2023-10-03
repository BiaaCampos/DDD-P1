using DDD.Domain.EventosContext;
using DDD.Infra.MemoryDb.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infra.MemoryDb.Repositories
{
    public class EventoRepository : IEventoRepository
    {

        private readonly ApiContext _context;

        public EventoRepository(ApiContext context)
        {
            _context = context;
        }

        public void DeleteEvento(Eventos evento)
        {
            try
            {
                _context.Set<Eventos>().Remove(evento);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Eventos GetEventoById(int IdEventos)
        {
            return _context.Eventos.Find(IdEventos);
        }

        public List<Eventos> GetEventos()
        {
            using (var context = new ApiContext())
            {
                var list = context.Eventos.ToList();
                return list;
            }
        }

        public void InsertEvento(Eventos evento)
        {
            try
            {
                _context.Eventos.Add(evento);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                //log exception

            }
        }

        public void UpdateEvento(Eventos evento)
        {
            try
            {
                _context.Entry(evento).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}