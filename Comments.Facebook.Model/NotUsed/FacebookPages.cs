using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Comments.Facebook.Model.NotUsed
{
    [Table("facebookpages")]
    public class FacebookPages
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string category { get; set; }
        public DateTime? LastAccessed { get; set; }
        public int? likes { get; set; }
        public string Name { get; set; }
        public string PageId { get; set; }
    }
}