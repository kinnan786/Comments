using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Comments.Facebook.Model.NotUsed
{
    [Table("activitylog")]
    public class ActivityLog
    {
        [Key]
        public long Id { get; set; }

        public bool Angry { get; set; }

        public bool Haha { get; set; }

        public bool Like { get; set; }

        public bool Love { get; set; }

        public bool Sad { get; set; }

        public bool Wow { get; set; }

        public DateTime CreatedOn { get; set; }

        public long facebookpagepostid { get; set; }

        public long userid { get; set; }

        [ForeignKey("userid")]
        public virtual Users users { get; set; }

        [ForeignKey("facebookpagepostid")]
        public virtual FacebookPagePosts FacebookPagePost { get; set; }
    }
}