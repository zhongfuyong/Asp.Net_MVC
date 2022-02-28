namespace Asp.Net.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_User
    {
        [Key]
        [StringLength(30)]
        public string c_Username { get; set; }

        public int? c_PlannerCodeID { get; set; }

        public int c_Usr00 { get; set; }

        public int c_Usr01 { get; set; }

        public int c_Usr02 { get; set; }

        public int c_Usr03 { get; set; }

        public int c_Usr04 { get; set; }

        public int c_Usr05 { get; set; }

        public int c_Usr06 { get; set; }

        public int c_Usr07 { get; set; }

        public int c_Usr08 { get; set; }

        public int c_Usr09 { get; set; }

        public int c_Usr10 { get; set; }
    }
}
