namespace DLL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThongtinPhim")]
    public partial class ThongtinPhim
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThongtinPhim()
        {
            ChiTIetTheLoaiPhinms = new HashSet<ChiTIetTheLoaiPhinm>();
            LichChieuPhims = new HashSet<LichChieuPhim>();
        }

        [Key]
        public int PhimId { get; set; }

        [Required]
        [StringLength(50)]
        public string TenPhim { get; set; }

        public DateTime NgayBatDauChieu { get; set; }

        public DateTime NgayKetThuc { get; set; }

        [Required]
        [StringLength(500)]
        public string Mota { get; set; }

        [Column(TypeName = "image")]
        [Required]
        public byte[] anh { get; set; }

        [Column("Thời lượng")]
        [Required]
        [StringLength(50)]
        public string Thời_lượng { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTIetTheLoaiPhinm> ChiTIetTheLoaiPhinms { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichChieuPhim> LichChieuPhims { get; set; }
    }
}
