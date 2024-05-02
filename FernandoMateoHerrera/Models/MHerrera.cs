using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace FernandoMateoHerrera.Models
{
    public class MHerrera
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }

        public Boolean Ecuatoriano { get; set; }
        [AllowNull]
        public double TimpoPromedio { get; set; }
        public DateTime FechaNacimiento { get; set; }

        [ForeignKey("CareraId")]
        public int? CarreraId { get; set; }
        public Carrera? Carrera { get; set; }
    }
}
