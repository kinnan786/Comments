﻿using System;
using System.Collections.Generic;

namespace Comments.Web.Models
{
    public class FacebookPostViewModel
    {
        public long Id { get; set; }
        public string Postid { get; set; }
        public string Type { get; set; }
        public int? Shares { get; set; }
        public string Message { get; set; }
        public string CreatedTime { get; set; }
        public int? Likes { get; set; }
        public int? Comments { get; set; }
        public int? Views { get; set; }
        public int? Love { get; set; }
        public int? Wow { get; set; }
        public int? Haha { get; set; }
        public int? Sad { get; set; }
        public int? Angry { get; set; }
        public int? Thankful { get; set; }
        public int Facebookpageid { get; set; }
        public string Link { get; set; }
        public string Source { get; set; }
        public string Story { get; set; }
        public string StatusType { get; set; }
        public string Picture { get; set; }
        public string ObjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Caption { get; set; }
        public int Recordcount { get; set; }
        public string FromName { get; set; }
        public string FromId { get; set; }
        public string FullPicture { get; set; }
        public long Capid { get; set; }
        public bool? IsExpired { get; set; }
        public string Url { get; set; }
        public long WordCloudCount { get; set; }

        public bool? Isprivate { get; set; }
        public DateTime? Lastupdated { get; set; }
        public string Ogurl { get; set; }
        public string Ogtitle { get; set; }
        public string Ogimage { get; set; }
        public string Ogdescription { get; set; }

        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public List<AttachmentViewModel> AttachmentViewModels { get; set; }
        public General General { get; set; }
        public Dictionary<string, long> Wordcloud { get; set; }
        public Dictionary<DateTime, ChartMonth> Chartmonth { get; set; }
        public Dictionary<string, int> Emoji { get; set; }

    }
}