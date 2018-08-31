using System;

namespace Comments.Web.Models
{
    public class AttachmentViewModel
    {
        public string Commentid { get; set; }
        public string ReplyId { get; set; }
        public string Url { get; set; }
        public int LikeCount { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ReplyCount { get; set; }
    }
}