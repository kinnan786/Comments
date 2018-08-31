using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Comments.Facebook.Model
{
    [Table("facebookaccesstoken")]
    public class FacebookAccessToken
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string accesstoken { get; set; }
        public DateTime? generatedon { get; set; }
        public int? expiry { get; set; }
        public string Fuserid { get; set; }

        public long userid { get; set; }

        [ForeignKey("userid")]
        public virtual Users user { get; set; }
    }
}