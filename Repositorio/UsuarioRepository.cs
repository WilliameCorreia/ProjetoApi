using System.Collections.Generic;
using System.Linq;
using projetoApi.models;

namespace projetoApi.Repositorio
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UsuarioDbContext _contexto;

        public UsuarioRepository(UsuarioDbContext contexto)
        {
            _contexto = contexto;
        }
        public void add(Usuarios usuario)
        {
            _contexto.usuarios.Add(usuario);
            _contexto.SaveChanges();
        }

        public Usuarios Find(long id)
        {
            return _contexto.usuarios.FirstOrDefault(usu => usu.Id == id);
        }

        public IEnumerable<Usuarios> GetAll()
        {
            return _contexto.usuarios.ToList();
        }

        public void Remover(long id)
        {
            var removeUsuario = _contexto.usuarios.First( x => x.Id == id);
            _contexto.usuarios.Remove(removeUsuario);
            _contexto.SaveChanges();
        }

        public void Update(Usuarios usuario)
        {
            _contexto.usuarios.Update(usuario);
            _contexto.SaveChanges();
        }
    }
}