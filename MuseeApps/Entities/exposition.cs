namespace MuseeApps.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class exposition
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public exposition()
        {
            billets = new HashSet<billet>();
            oeuvres_expositions = new HashSet<oeuvres_expositions>();
        }

        public int ID { get; set; }

        [StringLength(255)]
        public string Nom { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date_debut { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date_fin { get; set; }

        [Required]
        [StringLength(20)]
        public string heurDebut { get; set; }

        [Required]
        [StringLength(20)]
        public string heurFin { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        public int ID_user { get; set; }

        public double prix_classique { get; set; }

        public double prix_vip { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<billet> billets { get; set; }

        public virtual user user { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<oeuvres_expositions> oeuvres_expositions { get; set; }
    }
}
