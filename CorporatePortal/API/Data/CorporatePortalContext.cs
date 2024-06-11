using System;
using System.Collections.Generic;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public partial class CorporatePortalContext : DbContext
{
    public CorporatePortalContext()
    {
    }

    public CorporatePortalContext(DbContextOptions<CorporatePortalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventStatus> EventStatuses { get; set; }

    public virtual DbSet<EventType> EventTypes { get; set; }

    public virtual DbSet<NewType> NewTypes { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<ProjectStage> ProjectStages { get; set; }

    public virtual DbSet<ProjectStateStatus> ProjectStateStatuses { get; set; }

    public virtual DbSet<ProjectStatus> ProjectStatuses { get; set; }

    public virtual DbSet<ProjectType> ProjectTypes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserAccount> UserAccounts { get; set; }

    public virtual DbSet<UserPosition> UserPositions { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-M1UIT3L;Initial Catalog=corporate_portal;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.IdDepartrment);

            entity.Property(e => e.IdDepartrment).HasColumnName("idDepartrment");
            entity.Property(e => e.IdDirectorDepartment).HasColumnName("idDirectorDepartment");
            entity.Property(e => e.IdParentDepartment).HasColumnName("idParentDepartment");
            entity.Property(e => e.IdSupportDirectorDepartment).HasColumnName("idSupportDirectorDepartment");
            entity.Property(e => e.NameDepartment)
                .HasMaxLength(50)
                .HasColumnName("nameDepartment");

            entity.HasOne(d => d.IdParentDepartmentNavigation).WithMany(p => p.InverseIdParentDepartmentNavigation)
                .HasForeignKey(d => d.IdParentDepartment)
                .HasConstraintName("FK_Departments_Departments");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.IdEvent);

            entity.Property(e => e.IdEvent).HasColumnName("idEvent");
            entity.Property(e => e.DescriptionEvent).HasColumnName("descriptionEvent");
            entity.Property(e => e.EndDate).HasColumnName("endDate");
            entity.Property(e => e.IdInitiator).HasColumnName("idInitiator");
            entity.Property(e => e.IdStatusEvent).HasColumnName("idStatusEvent");
            entity.Property(e => e.IdTypeEvent).HasColumnName("idTypeEvent");
            entity.Property(e => e.NameEvent)
                .HasMaxLength(50)
                .HasColumnName("nameEvent");
            entity.Property(e => e.StartDate).HasColumnName("startDate");

            entity.HasOne(d => d.IdInitiatorNavigation).WithMany(p => p.Events)
                .HasForeignKey(d => d.IdInitiator)
                .HasConstraintName("FK_Events_Users");

            entity.HasOne(d => d.IdStatusEventNavigation).WithMany(p => p.Events)
                .HasForeignKey(d => d.IdStatusEvent)
                .HasConstraintName("FK_Events_EventStatuses");

            entity.HasOne(d => d.IdTypeEventNavigation).WithMany(p => p.Events)
                .HasForeignKey(d => d.IdTypeEvent)
                .HasConstraintName("FK_Events_EventTypes");
        });

        modelBuilder.Entity<EventStatus>(entity =>
        {
            entity.HasKey(e => e.IdStatusEvent);

            entity.Property(e => e.IdStatusEvent).HasColumnName("idStatusEvent");
            entity.Property(e => e.NameStatus)
                .HasMaxLength(50)
                .HasColumnName("nameStatus");
        });

        modelBuilder.Entity<EventType>(entity =>
        {
            entity.HasKey(e => e.IdTypeEvent);

            entity.Property(e => e.IdTypeEvent).HasColumnName("idTypeEvent");
            entity.Property(e => e.NameType)
                .HasMaxLength(50)
                .HasColumnName("nameType");
        });

        modelBuilder.Entity<NewType>(entity =>
        {
            entity.HasKey(e => e.IdTypeNew);

            entity.Property(e => e.IdTypeNew).HasColumnName("idTypeNew");
            entity.Property(e => e.NameType)
                .HasMaxLength(50)
                .HasColumnName("nameType");
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => e.IdNew);

            entity.Property(e => e.IdNew).HasColumnName("idNew");
            entity.Property(e => e.CreateDate).HasColumnName("createDate");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.IdCreator).HasColumnName("idCreator");
            entity.Property(e => e.IdTypeNew).HasColumnName("idTypeNew");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");

            entity.HasOne(d => d.IdCreatorNavigation).WithMany(p => p.News)
                .HasForeignKey(d => d.IdCreator)
                .HasConstraintName("FK_News_Users");

            entity.HasOne(d => d.IdTypeNewNavigation).WithMany(p => p.News)
                .HasForeignKey(d => d.IdTypeNew)
                .HasConstraintName("FK_News_NewTypes");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.IdProject);

            entity.Property(e => e.IdProject).HasColumnName("idProject");
            entity.Property(e => e.DescriptoinProject)
                .HasMaxLength(255)
                .HasColumnName("descriptoinProject");
            entity.Property(e => e.EndDate).HasColumnName("endDate");
            entity.Property(e => e.IdDepartment).HasColumnName("idDepartment");
            entity.Property(e => e.IdStatusProject).HasColumnName("idStatusProject");
            entity.Property(e => e.IdTypeProject).HasColumnName("idTypeProject");
            entity.Property(e => e.NameProject)
                .HasMaxLength(50)
                .HasColumnName("nameProject");
            entity.Property(e => e.StartDate).HasColumnName("startDate");

            entity.HasOne(d => d.IdDepartmentNavigation).WithMany(p => p.Projects)
                .HasForeignKey(d => d.IdDepartment)
                .HasConstraintName("FK_Projects_Departments");

            entity.HasOne(d => d.IdStatusProjectNavigation).WithMany(p => p.Projects)
                .HasForeignKey(d => d.IdStatusProject)
                .HasConstraintName("FK_Projects_ProjectStatuses");

            entity.HasOne(d => d.IdTypeProjectNavigation).WithMany(p => p.Projects)
                .HasForeignKey(d => d.IdTypeProject)
                .HasConstraintName("FK_Projects_ProjectTypes");
        });

        modelBuilder.Entity<ProjectStage>(entity =>
        {
            entity.HasKey(e => e.IdStageProject);

            entity.Property(e => e.IdStageProject).HasColumnName("idStageProject");
            entity.Property(e => e.DescriptionStage)
                .HasMaxLength(255)
                .HasColumnName("descriptionStage");
            entity.Property(e => e.EndDate).HasColumnName("endDate");
            entity.Property(e => e.IdProject).HasColumnName("idProject");
            entity.Property(e => e.IdStatusStage).HasColumnName("idStatusStage");
            entity.Property(e => e.NameState)
                .HasMaxLength(50)
                .HasColumnName("nameState");
            entity.Property(e => e.StartDate).HasColumnName("startDate");

            entity.HasOne(d => d.IdProjectNavigation).WithMany(p => p.ProjectStages)
                .HasForeignKey(d => d.IdProject)
                .HasConstraintName("FK_ProjectStages_Projects");

            entity.HasOne(d => d.IdStatusStageNavigation).WithMany(p => p.ProjectStages)
                .HasForeignKey(d => d.IdStatusStage)
                .HasConstraintName("FK_ProjectStages_ProjectStateStatuses");
        });

        modelBuilder.Entity<ProjectStateStatus>(entity =>
        {
            entity.HasKey(e => e.IdStatusStage);

            entity.Property(e => e.IdStatusStage).HasColumnName("idStatusStage");
            entity.Property(e => e.NameStatus)
                .HasMaxLength(50)
                .HasColumnName("nameStatus");
        });

        modelBuilder.Entity<ProjectStatus>(entity =>
        {
            entity.HasKey(e => e.IdStatusProject);

            entity.Property(e => e.IdStatusProject).HasColumnName("idStatusProject");
            entity.Property(e => e.NameStatus)
                .HasMaxLength(50)
                .HasColumnName("nameStatus");
        });

        modelBuilder.Entity<ProjectType>(entity =>
        {
            entity.HasKey(e => e.IdTypeProject);

            entity.Property(e => e.IdTypeProject).HasColumnName("idTypeProject");
            entity.Property(e => e.NameType)
                .HasMaxLength(50)
                .HasColumnName("nameType");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser);

            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.BirthDay).HasColumnName("birthDay");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("firstName");
            entity.Property(e => e.HomeNumber)
                .HasMaxLength(50)
                .HasColumnName("homeNumber");
            entity.Property(e => e.IdDepartment).HasColumnName("idDepartment");
            entity.Property(e => e.IdPosition).HasColumnName("idPosition");
            entity.Property(e => e.IdSwapper).HasColumnName("idSwapper");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(50)
                .HasColumnName("patronymic");
            entity.Property(e => e.PhotoPath)
                .HasMaxLength(50)
                .HasColumnName("photoPath");
            entity.Property(e => e.SecondName)
                .HasMaxLength(50)
                .HasColumnName("secondName");
            entity.Property(e => e.WorkNumber)
                .HasMaxLength(50)
                .HasColumnName("workNumber");

            entity.HasOne(d => d.IdDepartmentNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdDepartment)
                .HasConstraintName("FK_Users_Departments");

            entity.HasOne(d => d.IdPositionNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdPosition)
                .HasConstraintName("FK_Users_UserPositions");

            entity.HasOne(d => d.IdSwapperNavigation).WithMany(p => p.InverseIdSwapperNavigation)
                .HasForeignKey(d => d.IdSwapper)
                .HasConstraintName("FK_Users_Users");

            entity.HasMany(d => d.IdEvents).WithMany(p => p.IdUsers)
                .UsingEntity<Dictionary<string, object>>(
                    "EventMember",
                    r => r.HasOne<Event>().WithMany()
                        .HasForeignKey("IdEvent")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_EventMembers_Events"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_EventMembers_Users"),
                    j =>
                    {
                        j.HasKey("IdUser", "IdEvent");
                        j.ToTable("EventMembers");
                        j.IndexerProperty<int>("IdUser").HasColumnName("idUser");
                        j.IndexerProperty<int>("IdEvent").HasColumnName("idEvent");
                    });

            entity.HasMany(d => d.IdProjects).WithMany(p => p.IdUsers)
                .UsingEntity<Dictionary<string, object>>(
                    "ProjectMember",
                    r => r.HasOne<Project>().WithMany()
                        .HasForeignKey("IdProject")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ProjectMembers_Projects"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ProjectMembers_Users"),
                    j =>
                    {
                        j.HasKey("IdUser", "IdProject");
                        j.ToTable("ProjectMembers");
                        j.IndexerProperty<int>("IdUser").HasColumnName("idUser");
                        j.IndexerProperty<int>("IdProject").HasColumnName("idProject");
                    });
        });

        modelBuilder.Entity<UserAccount>(entity =>
        {
            entity.HasKey(e => e.IdUserAccount).HasName("PK_UserAccount_1");

            entity.ToTable("UserAccount");

            entity.Property(e => e.IdUserAccount).HasColumnName("idUserAccount");
            entity.Property(e => e.IdRole).HasColumnName("idRole");
            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.PasswordHash).HasColumnName("passwordHash");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.UserAccounts)
                .HasForeignKey(d => d.IdRole)
                .HasConstraintName("FK_UserAccount_UserRoles");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.UserAccounts)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserAccount_Users");
        });

        modelBuilder.Entity<UserPosition>(entity =>
        {
            entity.HasKey(e => e.IdPosition);

            entity.Property(e => e.IdPosition).HasColumnName("idPosition");
            entity.Property(e => e.NamePosition)
                .HasMaxLength(50)
                .HasColumnName("namePosition");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.IdRole);

            entity.Property(e => e.IdRole).HasColumnName("idRole");
            entity.Property(e => e.NameRole)
                .HasMaxLength(50)
                .HasColumnName("nameRole");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
