namespace MuseeApps.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class oeuvres_expositions
    {
        public int ID { get; set; }

        public int? ID_Oeuvre { get; set; }

        public int? ID_Exposition { get; set; }

        public virtual exposition exposition { get; set; }

        public virtual oeuvre oeuvre { get; set; }
    }
}
