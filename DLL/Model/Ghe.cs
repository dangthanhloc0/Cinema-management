namespace DLL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ghe")]
    public partial class Ghe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ghe()
        {
            ChiTietGhes = new HashSet<ChiTietGhe>();
            ThongTinVes = new HashSet<ThongTinVe>();
        }

        [StringLength(50)]
        public string GheID { get; set; }

        public int? LoaiGheID { get; set; }

        public int? PhongChieuID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietGhe> ChiTietGhes { get; set; }

        public virtual LoaiGhe LoaiGhe { get; set; }

        public virtual PhongChieu PhongChieu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThongTinVe> ThongTinVes { get; set; }
    }
}
