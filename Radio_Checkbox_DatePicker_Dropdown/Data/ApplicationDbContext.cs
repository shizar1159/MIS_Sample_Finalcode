using Microsoft.EntityFrameworkCore;
using Radio_Checkbox_DatePicker_Dropdown.Models;

namespace Radio_Checkbox_DatePicker_Dropdown.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Physician> Physicians { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
    }
}
