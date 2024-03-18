namespace DLL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        [Key]
        public int TaiKhoannID { get; set; }

        [Required]
        [StringLength(50)]
        public string MatKhau { get; set; }

        public int? VaiTroID { get; set; }

        public int KhachHangId { get; set; }

        [Column("Số điện thoại")]
        [Required]
        [StringLength(50)]
        public string Số_điện_thoại { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual LoaiTaiKhoan LoaiTaiKhoan { get; set; }
    }
}
