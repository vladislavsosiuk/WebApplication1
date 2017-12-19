namespace DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class students
    {
        [Key]
        public int StudentId { get; set; }

        [StringLength(50)]
        public string StudentFirstName { get; set; }

        [StringLength(50)]
        public string StudentLastName { get; set; }
    }
}
