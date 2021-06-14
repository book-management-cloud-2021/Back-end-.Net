using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BookManagement.Entities
{
    public partial class BookManagementContext : DbContext
    {
        public BookManagementContext()
        {
        }

        public BookManagementContext(DbContextOptions<BookManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<History> Histories { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Book");

                entity.Property(e => e.BookId)
                    .HasColumnName("book_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Author)
                    .HasMaxLength(100)
                    .HasColumnName("author");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .HasColumnName("description");

                entity.Property(e => e.InsertedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("inserted_at");

                entity.Property(e => e.LanguageId).HasColumnName("language_id");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.PrintLength).HasColumnName("print_length");

                entity.Property(e => e.Publisher)
                    .HasMaxLength(100)
                    .HasColumnName("publisher");

                entity.Property(e => e.ReleaseYear).HasColumnName("release_year");

                entity.Property(e => e.Title)
                    .HasMaxLength(200)
                    .HasColumnName("title");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Book_Category");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("FK_Book_Language");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("category_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(100)
                    .HasColumnName("category_name");

                entity.Property(e => e.IsActived).HasColumnName("is_actived");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customer_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Dob)
                    .HasColumnType("datetime")
                    .HasColumnName("dob");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(100)
                    .HasColumnName("fullname");

                entity.Property(e => e.InsertedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("inserted_at");

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<History>(entity =>
            {
                entity.ToTable("History");

                entity.Property(e => e.HistoryId)
                    .HasColumnName("history_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.BorrowDate)
                    .HasColumnType("datetime")
                    .HasColumnName("borrow_date");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.ManagerUsername)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("manager_username");

                entity.Property(e => e.ReturnDate)
                    .HasColumnType("datetime")
                    .HasColumnName("return_date");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Histories)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK_History_Book");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Histories)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_History_Customer");

                entity.HasOne(d => d.ManagerUsernameNavigation)
                    .WithMany(p => p.Histories)
                    .HasForeignKey(d => d.ManagerUsername)
                    .HasConstraintName("FK_History_Manager");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.ToTable("Language");

                entity.Property(e => e.LanguageId)
                    .HasColumnName("language_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.IsActived).HasColumnName("is_actived");

                entity.Property(e => e.LanguageName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("language_name");
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.HasKey(e => e.ManagerUsername);

                entity.ToTable("Manager");

                entity.Property(e => e.ManagerUsername)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("manager_username");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(100)
                    .HasColumnName("fullname");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
