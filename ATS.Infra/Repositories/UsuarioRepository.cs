using System.Collections.Generic;
using System.Linq;
using ATS.Domain.Models;
using ATS.Infra.Context;

namespace ATS.Infra.Repositories
{
    public class UsuarioRepository : Repository<Usuario>
    {
        public UsuarioRepository(AppDbContext context) : base(context)
        {}

        public override Usuario GetById(int id)
        {
            var query = _context.Set<Usuario>().Where(e => e.Id == id);

            if(query.Any())
                return query.First();

            return null;
        }

        public override IEnumerable<Usuario> GetAll()
        {
            var query = _context.Set<Usuario>();

            return query.Any() ? query.ToList() : new List<Usuario>();
        }

   

    }
}