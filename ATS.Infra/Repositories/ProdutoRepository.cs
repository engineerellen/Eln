using System.Collections.Generic;
using System.Linq;
using ATS.Domain.Models;
using ATS.Infra.Context;

namespace ATS.Infra.Repositories
{
    public class ProdutoRepository : Repository<Produto>
    {
        public ProdutoRepository(AppDbContext context) : base(context)
        {}

        public override Produto GetById(int id)
        {
            var query = _context.Set<Produto>().Where(e => e.intStatus == 1 && e.Id == id);

            if(query.Any())
                return query.First();

            return null;
        }

        public override IEnumerable<Produto> GetAll()
        {
            var query = _context.Set<Produto>();

            return query.Any() ? query.Where(p=> p.intStatus == 1).ToList() : new List<Produto>();
        }

   

    }
}