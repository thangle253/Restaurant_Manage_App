namespace Orderly.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietDonHang")]
    public partial class ChiTietDonHang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaChiTiet { get; set; }

        public int MaDonHang { get; set; }

        public int MaMon { get; set; }

        public int SoLuong { get; set; }

        public virtual DonHang DonHang { get; set; }

        public virtual MonAn MonAn { get; set; }
    }
}
