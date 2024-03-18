namespace DLL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("loaiPhong")]
    public partial class loaiPhong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public loaiPhong()
        {
            PhongChieux = new HashSet<PhongChieu>();
        }

        public int LoaiPhongId { get; set; }

        [Column("Tên loại")]
        [Required]
        [StringLength(50)]
        public string Tên_loại { get; set; }

        [Column("Giá Thêm")]
        public double Giá_Thêm { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhongChieu> PhongChieux { get; set; }
    }
}
