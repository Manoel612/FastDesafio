using System.ComponentModel.DataAnnotations;

namespace FastDesafio.Models
{
    public class RecordModel
    {
        [Key] 
        public int Id { get; set; }

        [Required]
        public required int WorkshopId { get; set; }

        public List<int> CollaboratorIds { get; set; } = new List<int>();

    }
}
