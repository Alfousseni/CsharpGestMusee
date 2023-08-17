namespace MuseeApps.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class employe
    {
        public int ID { get; set; }

        [StringLength(255)]
        public string Nom { get; set; }

        [StringLength(255)]
        public string Prenom { get; set; }

        [StringLength(100)]
        public string Position { get; set; }

        public double? Salaire { get; set; }

        [Required]
        [StringLength(30)]
        public string adresse { get; set; }

        [Required]
        [StringLength(10)]
        public string telephone { get; set; }
    }
}
