namespace Orderly.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThongKe")]
    public partial class ThongKe
    {
        [Key]
        public int MaThongKe { get; set; }

        public int MaBan { get; set; }

        [Column(TypeName = "date")]
        public DateTime Ngay { get; set; }

        public int SoLuongMon { get; set; }

        public decimal TongTien { get; set; }

        public virtual BanAn BanAn { get; set; }
    }
}
