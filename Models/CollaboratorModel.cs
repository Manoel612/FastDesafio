using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace FastDesafio.Models
{
    public class CollaboratorModel
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage= "Nome é nescessário")]
        public required string Name { get; set; }
    }
}
