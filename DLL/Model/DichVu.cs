namespace DLL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DichVu")]
    public partial class DichVu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DichVu()
        {
            ChiTietDichVus = new HashSet<ChiTietDichVu>();
        }

        public int DichVuID { get; set; }

        [Column("Tên dịch vụ")]
        [Required]
        [StringLength(50)]
        public string Tên_dịch_vụ { get; set; }

        public double Giá { get; set; }

        [Column(TypeName = "image")]
        [Required]
        public byte[] Anh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDichVu> ChiTietDichVus { get; set; }
    }
}
