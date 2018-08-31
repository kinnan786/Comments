using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Comments.Facebook.Model.NotUsed
{
    [Table("playlist_facebookpagepost")]
    public class Playlist_Facebookpageposts
    {
        [Key]
        public long Id { get; set; }

        public long playlistid { get; set; }

        public long facebookpagepostid { get; set; }

        [ForeignKey("playlistid")]
        public virtual Playlist Playlist { get; set; }

        [ForeignKey("facebookpagepostid")]
        public virtual FacebookPagePosts FacebookPagePosts { get; set; }
    }
}