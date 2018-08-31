using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Comments.Facebook.Model.NotUsed
{
    [Table("settings")]
    public class Settings
    {
        [Key]
        public long Id { get; set; }

        public bool? protectreactions { get; set; }
        public bool? savereactions { get; set; }
        public DateTime? modifieddate { get; set; }

        public long? userid { get; set; }

        [ForeignKey("userid")]
        public virtual Users user { get; set; }
    }
}