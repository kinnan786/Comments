﻿using System;

namespace Comments.Facebook.Model
{
    public class FacebookComments
    {
        public FacebookComment[] data { get; set; }
        public Paging paging { get; set; }
        public __Debug__ __debug__ { get; set; }
        public Summary summary { get; set; }
    }

    public class Paging
    {
        public Cursors cursors { get; set; }
        public string next { get; set; }
    }

    public class Cursors
    {
        public string before { get; set; }
        public string after { get; set; }
    }


    public class FacebookComment
    {
        public string id { get; set; }
        public Attachment attachment { get; set; }
        public int comment_count { get; set; }
        public DateTime created_time { get; set; }
        public From from { get; set; }
        public int like_count { get; set; }
        public string message { get; set; }
        public Message_Tags[] message_tags { get; set; }

        //below not mentoned in grapapi
        public Application application { get; set; }
        public Comments comments { get; set; }
    }

    public class Application
    {
        public string category { get; set; }
        public string link { get; set; }
        public string name { get; set; }
        public string _namespace { get; set; }
        public string id { get; set; }
    }

    public class From
    {
        public string name { get; set; }
        public string id { get; set; }
        public Picture picture { get; set; }
    }

    public class Comments
    {
        public FacebookComment[] data { get; set; }
        public Paging paging { get; set; }
    }

    public class Picture
    {
        public PictureData data { get; set; }
    }

    public class PictureData
    {
        public bool is_silhouette { get; set; }
        public string url { get; set; }
    }


    public class Attachment
    {
        public Media media { get; set; }
        public Target target { get; set; }
        public string type { get; set; }
        public string url { get; set; }
    }

    public class Media
    {
        public Image image { get; set; }
    }

    public class Image
    {
        public string height { get; set; }
        public string src { get; set; }
        public string width { get; set; }
    }

    public class Target
    {
        public string id { get; set; }
        public string url { get; set; }
    }

    public class Message_Tags
    {
        public string id { get; set; }
        public string length { get; set; }
        public string name { get; set; }
        public string offset { get; set; }
        public string type { get; set; }
    }


    public class FacebookError
    {
        public Error error { get; set; }
    }

    public class Error
    {
        public string message { get; set; }
        public string type { get; set; }
        public string code { get; set; }
        public string error_subcode { get; set; }
        public string fbtrace_id { get; set; }
    }
}