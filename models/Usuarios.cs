using System.ComponentModel.DataAnnotations;

namespace projetoApi.models
{
    public class Usuarios
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string  Email { get; set; }

        public string Senha { get; set; }
    }
}