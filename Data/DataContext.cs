using FastDesafio.Models;
using Microsoft.EntityFrameworkCore;

namespace FastDesafio.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {

        }
        public DbSet<WorkshopModel> DbWorkshop { get; set; }
        public DbSet<CollaboratorModel> DbCollaborators { get; set;}
        public DbSet<RecordModel> DbRecord { get; set; }

    }
}
