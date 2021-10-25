using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchedulerService.Data.HfModel
{
    public partial class HfContext : DbContext
    {
        public HfContext()
        {
        }

        public HfContext(DbContextOptions<HfContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Counter> Counter { get; set; }
        public virtual DbSet<Hash> Hash { get; set; }
        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<Jobparameter> Jobparameter { get; set; }
        public virtual DbSet<Jobqueue> Jobqueue { get; set; }
        public virtual DbSet<List> List { get; set; }
        public virtual DbSet<Lock> Lock { get; set; }
        public virtual DbSet<Schema> Schema { get; set; }
        public virtual DbSet<Server> Server { get; set; }
        public virtual DbSet<Set> Set { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Database=sample_db;Username=hangfire;Password=BfsB+@MmNu2Vf7av");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Counter>(entity =>
            {
                entity.ToTable("counter", "hangfire");

                entity.HasIndex(e => e.Expireat)
                    .HasName("ix_hangfire_counter_expireat");

                entity.HasIndex(e => e.Key)
                    .HasName("ix_hangfire_counter_key");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('counter_id_seq'::regclass)");

                entity.Property(e => e.Expireat).HasColumnName("expireat");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasColumnName("key")
                    .HasMaxLength(100);

                entity.Property(e => e.Updatecount).HasColumnName("updatecount");

                entity.Property(e => e.Value).HasColumnName("value");
            });

            modelBuilder.Entity<Hash>(entity =>
            {
                entity.ToTable("hash", "hangfire");

                entity.HasIndex(e => new { e.Key, e.Field })
                    .HasName("hash_key_field_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('hash_id_seq'::regclass)");

                entity.Property(e => e.Expireat).HasColumnName("expireat");

                entity.Property(e => e.Field)
                    .IsRequired()
                    .HasColumnName("field")
                    .HasMaxLength(100);

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasColumnName("key")
                    .HasMaxLength(100);

                entity.Property(e => e.Updatecount).HasColumnName("updatecount");

                entity.Property(e => e.Value).HasColumnName("value");
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.ToTable("job", "hangfire");

                entity.HasIndex(e => e.Statename)
                    .HasName("ix_hangfire_job_statename");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('job_id_seq'::regclass)");

                entity.Property(e => e.Arguments)
                    .IsRequired()
                    .HasColumnName("arguments");

                entity.Property(e => e.Createdat).HasColumnName("createdat");

                entity.Property(e => e.Expireat).HasColumnName("expireat");

                entity.Property(e => e.Invocationdata)
                    .IsRequired()
                    .HasColumnName("invocationdata");

                entity.Property(e => e.Stateid).HasColumnName("stateid");

                entity.Property(e => e.Statename)
                    .HasColumnName("statename")
                    .HasMaxLength(20);

                entity.Property(e => e.Updatecount).HasColumnName("updatecount");
            });

            modelBuilder.Entity<Jobparameter>(entity =>
            {
                entity.ToTable("jobparameter", "hangfire");

                entity.HasIndex(e => new { e.Jobid, e.Name })
                    .HasName("ix_hangfire_jobparameter_jobidandname");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('jobparameter_id_seq'::regclass)");

                entity.Property(e => e.Jobid).HasColumnName("jobid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(40);

                entity.Property(e => e.Updatecount).HasColumnName("updatecount");

                entity.Property(e => e.Value).HasColumnName("value");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.Jobparameter)
                    .HasForeignKey(d => d.Jobid)
                    .HasConstraintName("jobparameter_jobid_fkey");
            });

            modelBuilder.Entity<Jobqueue>(entity =>
            {
                entity.ToTable("jobqueue", "hangfire");

                entity.HasIndex(e => new { e.Jobid, e.Queue })
                    .HasName("ix_hangfire_jobqueue_jobidandqueue");

                entity.HasIndex(e => new { e.Queue, e.Fetchedat })
                    .HasName("ix_hangfire_jobqueue_queueandfetchedat");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('jobqueue_id_seq'::regclass)");

                entity.Property(e => e.Fetchedat).HasColumnName("fetchedat");

                entity.Property(e => e.Jobid).HasColumnName("jobid");

                entity.Property(e => e.Queue)
                    .IsRequired()
                    .HasColumnName("queue")
                    .HasMaxLength(20);

                entity.Property(e => e.Updatecount).HasColumnName("updatecount");
            });

            modelBuilder.Entity<List>(entity =>
            {
                entity.ToTable("list", "hangfire");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('list_id_seq'::regclass)");

                entity.Property(e => e.Expireat).HasColumnName("expireat");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasColumnName("key")
                    .HasMaxLength(100);

                entity.Property(e => e.Updatecount).HasColumnName("updatecount");

                entity.Property(e => e.Value).HasColumnName("value");
            });

            modelBuilder.Entity<Lock>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("lock", "hangfire");

                entity.HasIndex(e => e.Resource)
                    .HasName("lock_resource_key")
                    .IsUnique();

                entity.Property(e => e.Resource)
                    .IsRequired()
                    .HasColumnName("resource")
                    .HasMaxLength(100);

                entity.Property(e => e.Updatecount).HasColumnName("updatecount");
            });

            modelBuilder.Entity<Schema>(entity =>
            {
                entity.HasKey(e => e.Version)
                    .HasName("schema_pkey");

                entity.ToTable("schema", "hangfire");

                entity.Property(e => e.Version)
                    .HasColumnName("version")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Server>(entity =>
            {
                entity.ToTable("server", "hangfire");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(100);

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.Lastheartbeat).HasColumnName("lastheartbeat");

                entity.Property(e => e.Updatecount).HasColumnName("updatecount");
            });

            modelBuilder.Entity<Set>(entity =>
            {
                entity.ToTable("set", "hangfire");

                entity.HasIndex(e => new { e.Key, e.Value })
                    .HasName("set_key_value_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('set_id_seq'::regclass)");

                entity.Property(e => e.Expireat).HasColumnName("expireat");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasColumnName("key")
                    .HasMaxLength(100);

                entity.Property(e => e.Score).HasColumnName("score");

                entity.Property(e => e.Updatecount).HasColumnName("updatecount");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("state", "hangfire");

                entity.HasIndex(e => e.Jobid)
                    .HasName("ix_hangfire_state_jobid");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('state_id_seq'::regclass)");

                entity.Property(e => e.Createdat).HasColumnName("createdat");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.Jobid).HasColumnName("jobid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(20);

                entity.Property(e => e.Reason)
                    .HasColumnName("reason")
                    .HasMaxLength(100);

                entity.Property(e => e.Updatecount).HasColumnName("updatecount");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.State)
                    .HasForeignKey(d => d.Jobid)
                    .HasConstraintName("state_jobid_fkey");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.ToTable("user");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.DsEmail).HasColumnName("ds_email");

                entity.Property(e => e.DsName).HasColumnName("ds_name");

                entity.Property(e => e.DsPassword).HasColumnName("ds_password");

                entity.Property(e => e.DsPhone).HasColumnName("ds_phone");

                entity.Property(e => e.DsSurname).HasColumnName("ds_surname");

                entity.Property(e => e.DtBirthday).HasColumnName("dt_birthday");

                entity.Property(e => e.DtLastLogin).HasColumnName("dt_last_login");

                entity.Property(e => e.FlActive).HasColumnName("fl_active");

                entity.Property(e => e.FlDeleted).HasColumnName("fl_deleted");

                entity.Property(e => e.FlValidated).HasColumnName("fl_validated");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
