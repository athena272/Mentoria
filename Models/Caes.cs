using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
namespace Check2.Models

{
    public class Caes
    {
        [Key]
        public int Idcao { get; set; }
        public string Nome_cao { get; set; }
        public int Idraca { get; set; }
        public string Nome_raca { get; set; }
        public int Iddono { get; set; }
        public string Nome_dono { get; set; }
    }
}