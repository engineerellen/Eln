using ATS.Domain.Interfaces;
using ATS.Domain.Models;
using ATS.Infra.Context;
using ATS.Infra.Repositories;
using ATS.Infra.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ATS.Application.DI {
    public class Initializer {
        public static void Configure (IServiceCollection services, string conection) 
        {
            var Sqlversion = new MySqlServerVersion(new Version());

            services.AddDbContext<AppDbContext> (options => options.UseMySql(conection, Sqlversion));

            services.AddScoped (typeof (IRepository<Usuario>), typeof (UsuarioRepository));

            services.AddScoped(typeof(IRepository<EnderecoUsuario>), typeof(EnderecoUsuarioRepository));
            services.AddScoped(typeof(IRepository<Produto>), typeof(ProdutoRepository));

            services.AddScoped(typeof(IRepository<Pedido>), typeof(PedidoRepository));

            services.AddScoped (typeof (IRepository<>), typeof (Repository<>));
            services.AddScoped(typeof(IService<>), typeof(UsuarioService<>));
            services.AddScoped (typeof (IUnitOfWork), typeof (UnitOfWork));
        }
    }
}