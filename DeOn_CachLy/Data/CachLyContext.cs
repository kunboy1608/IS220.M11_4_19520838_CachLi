using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DeOn_CachLy.Models;

namespace DeOn_CachLy.Data
{
    public class CachLyContext: DbContext
    {
        public CachLyContext(DbContextOptions<CachLyContext> options) : base(options)
        { 
        }
        public DbSet<DiemCachLyModel> DiemCachLys { get; set; }
        public DbSet<CongNhanModel> CongNhans { get; set; }
        public DbSet<TrieuChungModel> TrieuChungs { get; set; }
        public DbSet<CN_TCModel> CN_TCs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DiemCachLyModel>().ToTable("DiemCachLy");
            modelBuilder.Entity<CongNhanModel>().ToTable("CongNhan");
            modelBuilder.Entity<TrieuChungModel>().ToTable("TrieuChung");
            modelBuilder.Entity<CN_TCModel>().ToTable("CN_TC").
                HasKey(c =>new { c.MaCongNhan, c.MaTrieuChung});
        }
    }
}
