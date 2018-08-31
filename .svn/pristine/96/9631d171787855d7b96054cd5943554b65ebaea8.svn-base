using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Comments.Facebook.Model.NotUsed
{
    [Table("mycollectionname")]
    public class MyCollectionName
    {
        [Key]
        public long Id { get; set; }

        public string Name { get; set; }
        public DateTime? CreatedOn { get; set; }

        public long userid { get; set; }

        [ForeignKey("userid")]
        public virtual Users user { get; set; }
    }
}