using System;
using Comments.Facebook;
using Newtonsoft.Json;

namespace Comments.Web.Models
{
    [JsonConverter(typeof(FacebookCommentJsonConverter))]
    public class FacebookCommentViewModel
    {
        public string CommentId { get; set; }
        public string FromName { get; set; }
        public string FromId { get; set; }
        public string Frompic { get; set; }
        public string Message { get; set; }
        public DateTime CreatedOn { get; set; }
        public int Likes { get; set; }
        public int Replies { get; set; }
        public string CommentAttachmentUrl { get; set; }
        public string AttachmentType { get; set; }
    }
}