using System.Collections.Generic;

namespace ATS.Domain.Interfaces
{
    public interface IService<TEntity> where TEntity : class
    {
        string GerarTokenJWT(string email, string issuer, string key, string audience);
    }
}