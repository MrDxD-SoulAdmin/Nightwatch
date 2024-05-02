using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NightWatchBackend.Database.Models;

namespace NightWatchBackend.Database;

public partial class NightWatchDbContext : DbContext
{
    public NightWatchDbContext(DbContextOptions<NightWatchDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.GenreId).HasName("PK_GenreID");

            entity.ToTable("Genre");

            entity.Property(e => e.GenreId).HasColumnName("GenreID");
            entity.Property(e => e.GenreName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasMany(d => d.Movies).WithMany(p => p.Genres)
                .UsingEntity<Dictionary<string, object>>(
                    "MovieGenre",
                    r => r.HasOne<Movie>().WithMany()
                        .HasForeignKey("MovieId")
                        .HasConstraintName("FK_MovieGenreForMovID"),
                    l => l.HasOne<Genre>().WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_MovieGenreForGenID"),
                    j =>
                    {
                        j.HasKey("GenreId", "MovieId").HasName("MovieGenreID");
                        j.ToTable("MovieGenre");
                        j.IndexerProperty<int>("GenreId").HasColumnName("GenreID");
                        j.IndexerProperty<int>("MovieId").HasColumnName("MovieID");
                    });
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.MovieId).HasName("PK_MovieID");

            entity.ToTable("Movie");

            entity.Property(e => e.MovieId).HasColumnName("MovieID");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.FilePath)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Length).HasPrecision(2);
            entity.Property(e => e.ThumbnailPath)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK_UserID");

            entity.ToTable("User");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.ProfilePath)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasMany(d => d.Movies).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserDislikedMovie",
                    r => r.HasOne<Movie>().WithMany()
                        .HasForeignKey("MovieId")
                        .HasConstraintName("FK_UserDislikedMovieForMovID"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_UserDislikedMovieForUsID"),
                    j =>
                    {
                        j.HasKey("UserId", "MovieId").HasName("DislikedID");
                        j.ToTable("UserDislikedMovie");
                        j.IndexerProperty<int>("UserId").HasColumnName("UserID");
                        j.IndexerProperty<int>("MovieId").HasColumnName("MovieID");
                    });

            entity.HasMany(d => d.MoviesNavigation).WithMany(p => p.UsersNavigation)
                .UsingEntity<Dictionary<string, object>>(
                    "UserLikedMovie",
                    r => r.HasOne<Movie>().WithMany()
                        .HasForeignKey("MovieId")
                        .HasConstraintName("FK_UserlikedMovieForMovID"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_UserLikedMovieForUsID"),
                    j =>
                    {
                        j.HasKey("UserId", "MovieId").HasName("LikedID");
                        j.ToTable("UserLikedMovie");
                        j.IndexerProperty<int>("UserId").HasColumnName("UserID");
                        j.IndexerProperty<int>("MovieId").HasColumnName("MovieID");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
