using Microsoft.EntityFrameworkCore;
using SchedulerService.Data.Core;
using SchedulerService.Data.Model;

namespace SchedulerService.Data.Context
{
    public class BookContext : BaseContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}