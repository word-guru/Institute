using Institute.Model;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Instituts.DB.Lib
{
    public partial class DbInstituts : DbContext
    {
        public DbInstituts() { }
        public DbInstituts(DbContextOptions<DbInstituts> options) : base(options) { }

        public virtual DbSet<Account> TabAccounts { get; set; }
        public virtual DbSet<AccountRole> TabAccountRoles { get; set; }
        public virtual DbSet<Group> TabGroups { get; set; }
        public virtual DbSet<Person> TabPersons { get; set; }
        public virtual DbSet<Role> TabRoles { get; set; }
        public virtual DbSet<Student> TabStudents { get; set; }
        public virtual DbSet<Teacher> TabTeachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(GetConnectStr());
            }
        }

        private static string GetConnectStr()
        {
            var config = new DbConfig();
            return config.GetConnectionString();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("tab_accounts");

                entity.HasIndex(e => e.Login, "UQ__tab_acco__7838F272FF365E1D")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("login");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");
            });

            modelBuilder.Entity<AccountRole>(entity =>
            {
                entity.ToTable("tab_account_roles");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.TabAccountRoles)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tab_accou__accou__4D94879B");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.TabAccountRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tab_accou__role___4E88ABD4");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("tab_groups");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("tab_persons");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .HasColumnName("date_of_birth");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("last_name");

                entity.Property(e => e.Sex)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("sex")
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.TabPerson)
                    .HasForeignKey<Person>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tab_persons__id__5165187F");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("tab_roles");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("tab_students");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.IsStudy)
                    .IsRequired()
                    .HasColumnName("is_study")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.TabStudents)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tab_stude__group__5AEE82B9");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.TabStudents)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tab_stude__perso__59FA5E80");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("tab_teachers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.TabTeachers)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tab_teach__group__571DF1D5");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.TabTeachers)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tab_teach__perso__5629CD9C");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
