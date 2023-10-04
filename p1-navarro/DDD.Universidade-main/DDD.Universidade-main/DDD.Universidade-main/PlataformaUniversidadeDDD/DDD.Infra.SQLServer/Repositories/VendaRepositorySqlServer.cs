using DDD.Domain.GeralContext;
using DDD.Infra.SQLServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Repositories
{
    public class VendaRepositorySqlServer : IVendaRepository
    {
        private readonly SqlContext _context;

        public VendaRepositorySqlServer(SqlContext context)
        {
            _context = context;
        }


        public void DeleteVenda(Venda venda)
        {
            throw new NotImplementedException();
        }

        public Venda GetVendaById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Venda> GetVendas()
        {
            throw new NotImplementedException();
        }

        public Venda InsertVenda(int IdEventos, int IdComprador)
        {
            var comprador = _context.Comprador.First(i => i.UserId == IdComprador);
            var eventos = _context.Eventos.First(i => i.IdEventos == IdEventos);

            var venda = new Venda
            {
                Comprador = comprador,
                Eventos = eventos
            };

            try
            {

                _context.Add(venda);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                var msg = ex.InnerException;
                throw;
            }

            return venda;
        }

        public void UpdateVenda(Venda venda)
        {
            throw new NotImplementedException();
        }
    }
}
