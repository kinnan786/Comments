using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Comments.Facebook.Model.NotUsed
{
    [Table("album_facebookpagepost")]
    public class Album_Facebookpagepost
    {
        [Key]
        public long Id { get; set; }

        public long albumid { get; set; }

        public long facebookpagepostid { get; set; }

        [ForeignKey("albumid")]
        public virtual Album album { get; set; }

        [ForeignKey("facebookpagepostid")]
        public virtual FacebookPagePosts FacebookPagePost { get; set; }
    }
}