using System.ComponentModel.DataAnnotations;

namespace Check2.Models
{
    public class Donos
    {
        [Key]
        public int Iddono { get; set; }
        public string Nome_dono { get; set; }
        public string Telefone { get; set; }

    }
}