namespace DLL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ve")]
    public partial class Ve
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ve()
        {
            ChiTietDichVus = new HashSet<ChiTietDichVu>();
            ThongTinVes = new HashSet<ThongTinVe>();
        }

        public int VeID { get; set; }

        [Column("Ngày bán vé")]
        public DateTime? Ngày_bán_vé { get; set; }

        [Column("Thành tiền")]
        public double Thành_tiền { get; set; }

        public int? KhachHangId { get; set; }

        [Column("Nhân viên")]
        [StringLength(50)]
        public string Nhân_viên { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDichVu> ChiTietDichVus { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThongTinVe> ThongTinVes { get; set; }
    }
}
