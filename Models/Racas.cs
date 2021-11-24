using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
namespace Check2.Models

{
    public class Racas
    {
        [Key]
        public int Idraca { get; set; }
        public int iddono { get; set; }
        public string Nome_dono { get; set; }
        public string Nome_raca { get; set; }
    }
}