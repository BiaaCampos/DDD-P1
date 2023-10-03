using DDD.Domain.EventosContext;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Interfaces
{
    public interface IEventoRepository
    {
        public List<Eventos> GetEventos();
        public Eventos GetEventoById(int IdEventos);
        public void InsertEvento(Eventos eventos);
        public void UpdateEvento(Eventos eventos);
        public void DeleteEvento(Eventos eventos);
    }
}
