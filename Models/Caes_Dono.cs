using System.ComponentModel.DataAnnotations;

namespace Check2.Models
{
    public class Caes_Dono
    {
        [Key]
        public int CaesDonos { get; set; }
        public string Iddonos { get; set; }
        public string Idcaes { get; set; }
    }
}