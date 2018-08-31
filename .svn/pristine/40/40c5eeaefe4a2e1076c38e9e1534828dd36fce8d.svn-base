using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Comments.Facebook.Model.NotUsed
{
    [Table("usercollection")]
    public class UserCollection
    {
        [Key]
        public long Id { get; set; }

        public string pageid { get; set; }
        public string postid { get; set; }
        public long userid { get; set; }
        public long facebookpagepostid { get; set; }
        public long mycollectionid { get; set; }

        [ForeignKey("userid")]
        public virtual Users user { get; set; }

        [ForeignKey("facebookpagepostid")]
        public virtual FacebookPagePosts FacebookPagePost { get; set; }

        [ForeignKey("mycollectionid")]
        public virtual MyCollectionName MyCollectionName { get; set; }
    }
}