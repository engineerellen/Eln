using System.Collections.Generic;
using System.Linq;
using ATS.Domain.Models;
using ATS.Infra.Context;

namespace ATS.Infra.Repositories
{
    public class EnderecoUsuarioRepository : Repository<EnderecoUsuario>
    {
        public EnderecoUsuarioRepository(AppDbContext context) : base(context)
        {}

        public override EnderecoUsuario GetById(int id)
        {
            var query = _context.Set<EnderecoUsuario>().Where(e => e.Id == id);

            if(query.Any())
                return query.First();

            return null;
        }

        public override IEnumerable<EnderecoUsuario> GetAll()
        {
            var query = _context.Set<EnderecoUsuario>();

            return query.Any() ? query.ToList() : new List<EnderecoUsuario>();
        }
 

    }
}