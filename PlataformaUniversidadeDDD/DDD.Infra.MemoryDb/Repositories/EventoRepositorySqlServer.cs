using DDD.Domain.EventosContext;
using DDD.Infra.MemoryDb.Interfaces;
using DDD.Infra.SQLServer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.MemoryDb.Repositories
{
    public class EventoRepositorySqlServer : IEventoRepository
    {

        private readonly SqlContext _context;

        public EventoRepositorySqlServer(SqlContext context)
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

        public Eventos GetEventoById(int id)
        {
            return _context.Eventos.Find(id);
        }

        public List<Eventos> GetEventos()
        {

            return _context.Eventos.ToList();

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
