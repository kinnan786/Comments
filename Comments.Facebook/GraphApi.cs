﻿namespace Comments.Facebook
{
    public class GraphApi
    {
        public string Accesstoken;
        public string Enddate;
        public string Pageid;
        public string Pagging;
        public string Startdate;

        public GraphApi(string startdate, string enddate, string accesstoken, string pageid, string pagging)
        {
            Startdate = startdate;
            Enddate = enddate;
            Accesstoken = accesstoken;
            Pageid = pageid;
            Pagging = pagging;
        }

        public GraphApi(string accesstoken)
        {
            Accesstoken = accesstoken;
        }

        public string PostsUrl(string postid)
        {
            return FacebookSettings.Url + postid +
                   "?&fields=id,admin_creator{ id,name},application,caption,created_time,description,call_to_action{ context},feed_targeting{ age_max,age_min,cities,college_years,countries,education_statuses,genders,interested_in,interests,locales,regions,relationship_statuses},from,icon,instagram_eligibility,is_hidden,is_instagram_eligible,is_published,link,message,message_tags,name,object_id,parent_id,permalink_url,picture,place,privacy{ description,value,friends,allow,deny},properties{ name,text,href},shares,source,status_type,story,story_tags,targeting{ countries,locales,regions,cities},to,type,updated_time,with_tags" +
                   "&access_token=" + Accesstoken;
        }

        public string PagePostsUrl()
        {
            return FacebookSettings.Url + Pageid +
                   "/posts?fields=object_id,created_time,source,link,type,message,story,created_time,id" +
                   "&limit=" + Pagging + "&since=" + Startdate + "&until=" + Enddate + "&access_token=" + Accesstoken;
        }

        public string PostsReactionsUrl(string postid)
        {
            return FacebookSettings.Url + postid +
                   "/?fields=created_time,comments.limit(1).summary(true),shares,reactions.type(LIKE).limit(0).summary(true).as(like)," +
                   "reactions.type(LOVE).limit(0).summary(true).as(love),reactions.type(WOW).limit(0).summary(true).as(wow)," +
                   "reactions.type(HAHA).limit(0).summary(true).as(haha),reactions.type(SAD).limit(0).summary(true).as(sad)," +
                   "reactions.type(ANGRY).limit(0).summary(true).as(angry),reactions.type(THANKFUL).limit(0).summary(true).as(thankful)" +
                   "&access_token=" + Accesstoken;
        }

        // it does not return all the comments i.e there is a diffrence between total comments count and returned
        // in cas of unilad total comment count is 529 and it is returing 490????
        public string PostComments(string postId)
        {
            return FacebookSettings.Url + postId +
                   "/comments?fields=application,attachment,comment_count,created_time,from{id,name,picture},id,like_count,message,comments.limit(1000){attachment,application,comment_count,created_time,from{id,name,picture},id,message,message_tags,like_count,comments{comment_count}}&limit=500&access_token=" +
                   Accesstoken;
        }


        public string PostsImages_Url(string objectId)
        {
            return FacebookSettings.Url + objectId + "/?fields=images,picture&access_token=" + Accesstoken;
        }

        public string Page_or_User_Url(string pageid)
        {
            return FacebookSettings.Url + pageid + "/?fields=id,name&access_token=" + Accesstoken;
        }
    }
}