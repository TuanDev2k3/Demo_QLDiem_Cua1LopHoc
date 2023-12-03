using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QL_DiemHS.Models;

namespace QL_DiemHS.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
       
        public DbSet<MonHoc> MonHoc { get; set; }
        public DbSet<HocSinh> HocSinh { get; set; }
        public DbSet<DiemSo> DiemSo { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DiemSo>()
                .HasKey(d => new { d.MaMon, d.MaHS });
            modelBuilder.Entity<DiemSo>()
           .HasOne(d => d.MonHoc)
           .WithMany()
           .HasForeignKey(d => d.MaMon)
           .OnDelete(DeleteBehavior.Restrict); // Chọn hành vi thích hợp
            // Cấu hình các thuộc tính khác của DiemSo
            base.OnModelCreating(modelBuilder);
        }
    }
    
}