using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;
using SchedulerService.Data.Core;

namespace SchedulerService.Data.Core
{
     public abstract class BaseContext : DbContext
    {
        private int _idUser;

        private static readonly LoggerFactory LoggerFactory
            = new LoggerFactory(new[] {new DebugLoggerProvider()});

        protected BaseContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(LoggerFactory);
            base.OnConfiguring(optionsBuilder);
        }

        public void SetIdUser(int idUser)
        {
            _idUser = idUser;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetBaseEntityFields();
            return base.SaveChangesAsync(cancellationToken);
        }
        
        public override int SaveChanges()
        {
            SetBaseEntityFields();
            return base.SaveChanges();
        }

        private void SetBaseEntityFields()
        {
            SetInsertedEntryFields();
            SetUpdatedEntryFields();
        }
        
        private void SetUpdatedEntryFields()
        {
            var updatedEntities = ChangeTracker
                .Entries()
                .Where<EntityEntry>(_ => _.State == EntityState.Modified).ToList();

            foreach (var e in updatedEntities)
            {
                ((BaseEntity)e.Entity).DtUpdate = DateTime.Now;
                ((BaseEntity)e.Entity).IdUserUpdate = _idUser;
            }
        }

        private void SetInsertedEntryFields()
        {
            var insertedEntities = ChangeTracker
                .Entries()
                .Where(_ => _.State == EntityState.Added).ToList();

            foreach (var e in insertedEntities)
            {
                ((BaseEntity)e.Entity).DtCreate = DateTime.Now;
                ((BaseEntity)e.Entity).DtUpdate = DateTime.Now;
                ((BaseEntity)e.Entity).IdUserCreate = _idUser;
                ((BaseEntity)e.Entity).IdUserUpdate = _idUser;
            }
        }
    }
}