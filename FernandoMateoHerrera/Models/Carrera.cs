using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FernandoMateoHerrera.Models
{
    public class Carrera

    {
        [Key]
        public int CarreraId { get; set; }
        [AllowedValues(typeof(int))]
        public String NombreCarrera { get; set; }
        [DisplayName("Campus")]
        public String Campus {  get; set; }
        public int Semestre { get; set; }

    }
}
