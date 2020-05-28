using Microsoft.EntityFrameworkCore;

namespace F.Core.Model
{
    public partial class MySqlContext : DbContext
    {
        public MySqlContext()
        {
        }

        public MySqlContext(DbContextOptions<MySqlContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Sc> Sc { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.Cid)
                    .HasName("PRIMARY");

                entity.ToTable("course");

                entity.Property(e => e.Cid).HasColumnName("cid");

                entity.Property(e => e.Cname)
                    .HasColumnName("cname")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Tid).HasColumnName("tid");
            });

            modelBuilder.Entity<Sc>(entity =>
            {
                entity.HasKey(e => new { e.Sid, e.Cid })
                    .HasName("PRIMARY");

                entity.ToTable("sc");

                entity.Property(e => e.Sid).HasColumnName("sid");

                entity.Property(e => e.Cid).HasColumnName("cid");

                entity.Property(e => e.Score).HasColumnName("score");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Sid)
                    .HasName("PRIMARY");

                entity.ToTable("student");

                entity.Property(e => e.Sid).HasColumnName("sid");

                entity.Property(e => e.Sage).HasColumnName("sage");

                entity.Property(e => e.Sname)
                    .HasColumnName("sname")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Ssex)
                    .HasColumnName("ssex")
                    .HasMaxLength(8)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasKey(e => e.Tid)
                    .HasName("PRIMARY");

                entity.ToTable("teacher");

                entity.Property(e => e.Tid).HasColumnName("tid");

                entity.Property(e => e.Tname)
                    .HasColumnName("tname")
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}