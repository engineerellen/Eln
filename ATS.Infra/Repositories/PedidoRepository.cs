using System.Collections.Generic;
using System.Linq;
using ATS.Domain.Models;
using ATS.Infra.Context;

namespace ATS.Infra.Repositories
{
    public class PedidoRepository : Repository<Pedido>
    {
        public PedidoRepository(AppDbContext context) : base(context)
        {}

        public  override Pedido GetById(int idUsuario)
        {
            var query = _context.Set<Pedido>().Where(e => e.idUsuario == idUsuario);

            if (query.Any())
                return query.First();

            return null;
        }

        public override IEnumerable<Pedido> GetAll()
        {
            var query = _context.Set<Pedido>();

            return query.Any() ? query.ToList() : new List<Pedido>();
        }


    }
}