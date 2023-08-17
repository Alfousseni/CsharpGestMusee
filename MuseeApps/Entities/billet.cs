namespace MuseeApps.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class billet
    {
        public int ID { get; set; }

        public int? ID_Visiteur { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date_achat { get; set; }

        [StringLength(50)]
        public string Type_billet { get; set; }

        public int? ID_Exposition { get; set; }

        public int ID_user { get; set; }

        public virtual exposition exposition { get; set; }

        public virtual user user { get; set; }

        public virtual visiteur visiteur { get; set; }
    }
}
