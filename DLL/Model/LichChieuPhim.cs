namespace DLL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LichChieuPhim")]
    public partial class LichChieuPhim
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LichChieuPhim()
        {
            ChiTietGhes = new HashSet<ChiTietGhe>();
            ThongTinVes = new HashSet<ThongTinVe>();
        }

        [Key]
        public int LCPId { get; set; }

        public int PhimId { get; set; }

        [Column("Thời gian bắt đầu chiếu")]
        [Required]
        [StringLength(50)]
        public string Thời_gian_bắt_đầu_chiếu { get; set; }

        [Column("Thời gian kết thúc chiếu")]
        [Required]
        [StringLength(50)]
        public string Thời_gian_kết_thúc_chiếu { get; set; }

        public int PhongChieuID { get; set; }

        public DateTime NgayChieu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietGhe> ChiTietGhes { get; set; }

        public virtual PhongChieu PhongChieu { get; set; }

        public virtual ThongtinPhim ThongtinPhim { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThongTinVe> ThongTinVes { get; set; }
    }
}
