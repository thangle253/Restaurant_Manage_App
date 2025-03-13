using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Orderly.Model2
{
    public partial class QuanLyTaiKhoanDB : DbContext
    {
        public QuanLyTaiKhoanDB()
            : base("name=QuanLyTaiKhoanDB")
        {
        }

        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<UserSession> UserSessions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
