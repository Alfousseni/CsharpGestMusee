namespace MuseeApps.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class oeuvre
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public oeuvre()
        {
            oeuvres_expositions = new HashSet<oeuvres_expositions>();
        }

        public int ID { get; set; }

        [StringLength(255)]
        public string Nom { get; set; }

        public int? ID_Artiste { get; set; }

        public int? Annee { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        public double? Prix_estime { get; set; }

        public int ID_user { get; set; }

        public virtual artiste artiste { get; set; }

        public virtual user user { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<oeuvres_expositions> oeuvres_expositions { get; set; }

    }
}
