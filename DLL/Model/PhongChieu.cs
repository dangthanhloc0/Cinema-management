namespace DLL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhongChieu")]
    public partial class PhongChieu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhongChieu()
        {
            Ghes = new HashSet<Ghe>();
            LichChieuPhims = new HashSet<LichChieuPhim>();
        }

        public int PhongChieuID { get; set; }

        [Column("Tên Phòng")]
        [Required]
        [StringLength(50)]
        public string Tên_Phòng { get; set; }

        [Column("Tổng số ghế")]
        [Required]
        [StringLength(50)]
        public string Tổng_số_ghế { get; set; }

        public int? LoaiPhongId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ghe> Ghes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichChieuPhim> LichChieuPhims { get; set; }

        public virtual loaiPhong loaiPhong { get; set; }
    }
}
