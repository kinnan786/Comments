using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Comments.Facebook.Model.NotUsed
{
    [Table("playlist")]
    public class Playlist
    {
        [Key]
        public long Id { get; set; }

        public long userid { get; set; }

        public string name { get; set; }

        [ForeignKey("userid")]
        public virtual Users user { get; set; }
    }
}