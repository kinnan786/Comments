using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Comments.Facebook.Model.NotUsed
{
    [Table("facebooklinkmetatags")]
    public class FacebookLinkMetaTags
    {
        [Key]
        public long id { get; set; }

        public string url { get; set; }
        public string type { get; set; }
        public string title { get; set; }
        public string image { get; set; }
        public string description { get; set; }
        public int? width { get; set; }
        public int? height { get; set; }

        public long facebookpagepostid { get; set; }

        [ForeignKey("facebookpagepostid")]
        public virtual FacebookPagePosts FacebookPagePost { get; set; }
    }
}