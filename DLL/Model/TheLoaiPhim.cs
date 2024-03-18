namespace DLL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TheLoaiPhim")]
    public partial class TheLoaiPhim
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TheLoaiPhim()
        {
            ChiTIetTheLoaiPhinms = new HashSet<ChiTIetTheLoaiPhinm>();
        }

        [Key]
        public int TheLoaiId { get; set; }

        [Column("Tên Thể loại")]
        [Required]
        [StringLength(50)]
        public string Tên_Thể_loại { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTIetTheLoaiPhinm> ChiTIetTheLoaiPhinms { get; set; }
    }
}
