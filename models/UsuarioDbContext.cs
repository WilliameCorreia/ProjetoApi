using Microsoft.EntityFrameworkCore;

namespace projetoApi.models
{
    public class UsuarioDbContext: DbContext
    {
        public UsuarioDbContext(DbContextOptions<UsuarioDbContext> options)
            :base(options)
        { }

        public DbSet<Usuarios> usuarios { get; set; }
    }
}