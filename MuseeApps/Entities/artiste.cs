namespace MuseeApps.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class artiste
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public artiste()
        {
            oeuvres = new HashSet<oeuvre>();
        }

        public int ID { get; set; }

        [StringLength(255)]
        public string Nom { get; set; }

        [StringLength(30)]
        public string email { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date_naissance { get; set; }

        [StringLength(100)]
        public string Nationalite { get; set; }

        [Column(TypeName = "text")]
        public string Biographie { get; set; }

        public int ID_user { get; set; }

        public virtual user user { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<oeuvre> oeuvres { get; set; }
    }
}
