using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace FastDesafio.Models
{
    public class WorkshopModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage= "Nome é nescessário")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Descrição é nescessária")]
        public required string Description { get; set; }

        [Required(ErrorMessage = "Data de realização é nescessária")]
        public required DateTime RealizationDate { get; set; }

    }
}
