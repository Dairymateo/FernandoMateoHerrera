using System.ComponentModel.DataAnnotations;

namespace FernandoMateoHerrera.Models
{
    public class Carrera

    {
        [Key]
        public int CarreraId { get; set; }
        public String NombreCarrera { get; set; }
        public String Campus {  get; set; }
        public int Semestre { get; set; }

    }
}
