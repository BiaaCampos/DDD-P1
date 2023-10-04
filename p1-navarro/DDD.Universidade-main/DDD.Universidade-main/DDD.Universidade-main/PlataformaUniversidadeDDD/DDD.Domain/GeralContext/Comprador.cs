using DDD.Domain.UserManagementContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.GeralContext
{
    public class Comprador : User
    {
        //n
        public IList<Eventos>? Eventos { get; set; }
    }
}
