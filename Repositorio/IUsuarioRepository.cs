using System.Collections.Generic;
using projetoApi.models;

namespace projetoApi.Repositorio
{
    public interface IUsuarioRepository
    {
         void add(Usuarios user);

         IEnumerable<Usuarios> GetAll();

         Usuarios Find(long id);

         void Remover(long id);

         void Update(Usuarios user);
    }
}