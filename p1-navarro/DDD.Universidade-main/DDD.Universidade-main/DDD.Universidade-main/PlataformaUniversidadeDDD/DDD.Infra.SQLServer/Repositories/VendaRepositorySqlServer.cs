using DDD.Domain.GeralContext;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.EntityFrameworkCore;
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
            return _context.Venda.Find(id);
        }

        public List<Venda> GetVendas()
        {
            return _context.Venda.ToList();
        }

        public void InsertVenda(Venda venda)
        {
            _context.Venda.Add(venda);
            _context.SaveChanges();
        }

        public void UpdateVenda(Venda venda)
        {
            _context.Entry(venda).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
