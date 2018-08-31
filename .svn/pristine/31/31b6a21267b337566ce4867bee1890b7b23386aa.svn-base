using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using Comments.Facebook.Model.NotUsed;

//using SMOAPP.Model;

namespace Comments.Facebook
{
    public class Parser
    {
        private Dictionary<string, object> _dictionary;
        private JavaScriptSerializer _serializer;

        private string NextPage(string address)
        {
            try
            {
                var response = new GraphApiResponse();
                var result = response.GetResponse(address);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public List<FacebookPagePosts> PagePost(string result)
        //{

        //    try
        //    {
        //        var lstpost = new List<FacebookPagePosts>();
        //        _serializer = new JavaScriptSerializer();
        //        _dictionary = _serializer.Deserialize<Dictionary<string, object>>(result);
        //        var lstmodel = (ArrayList)_dictionary["data"];

        //        if (lstmodel.Count == 0)
        //            return null;
        //        do
        //        {
        //            if (lstmodel.Count == 0)
        //            {
        //                var nextpage = (Dictionary<string, object>)_dictionary["paging"];
        //                var newresult = NextPage(nextpage["next"].ToString());
        //                _dictionary = _serializer.Deserialize<Dictionary<string, object>>(newresult);
        //                lstmodel = (ArrayList)_dictionary["data"];
        //            }
        //            if (lstmodel.Count > 0)
        //            {
        //                foreach (var item in lstmodel)
        //                {
        //                    if (item is Dictionary<string, object>)
        //                    {
        //                        var a = (Dictionary<string, object>)item;
        //                        var data = new FacebookPagePosts();

        //                        if (a.Keys.Contains("id"))
        //                            data.postid = a["id"].ToString();
        //                        if (a.Keys.Contains("source"))
        //                            data.source = a["source"].ToString();
        //                        if (a.Keys.Contains("link"))
        //                            data.link = a["link"].ToString();
        //                        if (a.Keys.Contains("id"))
        //                            data.postid = a["id"].ToString();
        //                        if (a.Keys.Contains("message"))
        //                            data.message = a["message"].ToString();
        //                        if (a.Keys.Contains("story"))
        //                            data.story = a["story"].ToString();
        //                        if (a.Keys.Contains("created_time"))
        //                            data.created_time = DateTime.Parse(a["created_time"].ToString());
        //                        if (a.Keys.Contains("type"))
        //                            data.type = a["type"].ToString();
        //                        lstpost.Add(data);
        //                    }
        //                }
        //            }
        //            lstmodel.Clear();
        //            if (!_dictionary.Keys.Contains("paging"))
        //            {
        //                return lstpost;
        //            }
        //        } while (((Dictionary<string, object>)_dictionary["paging"]).Keys.Contains("next"));
        //        return lstpost;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        //public FacebookPagePosts PostReactions(FacebookPagePosts posts, string result)
        //{
        //    try
        //    {
        //        _serializer = new JavaScriptSerializer();
        //        _dictionary = _serializer.Deserialize<Dictionary<string, object>>(result);

        //        if (_dictionary.Keys.Contains("shares"))
        //        {
        //            posts.shares = Convert.ToInt32(((Dictionary<string, object>)_dictionary["shares"])["count"]);
        //            posts.total += posts.shares.Value;
        //        }

        //        if (_dictionary.Keys.Contains("comments"))
        //        {
        //            posts.comments =
        //                Convert.ToInt32(
        //                    ((Dictionary<string, object>)
        //                        ((Dictionary<string, object>)_dictionary["comments"])["summary"])
        //                        ["total_count"]);
        //            posts.total += posts.comments.Value;
        //        }

        //        if (_dictionary.Keys.Contains("like"))
        //        {
        //            posts.likes =
        //                Convert.ToInt32(
        //                    ((Dictionary<string, object>)((Dictionary<string, object>)_dictionary["like"])["summary"])
        //                        ["total_count"]);
        //            posts.total += posts.likes.Value;
        //        }

        //        if (_dictionary.Keys.Contains("love"))
        //        {
        //            posts.love =
        //                Convert.ToInt32(
        //                    ((Dictionary<string, object>)((Dictionary<string, object>)_dictionary["love"])["summary"])
        //                        ["total_count"]);
        //            posts.total += posts.love.Value;
        //        }

        //        if (_dictionary.Keys.Contains("wow"))
        //        {
        //            posts.wow =
        //                Convert.ToInt32(
        //                    ((Dictionary<string, object>)((Dictionary<string, object>)_dictionary["wow"])["summary"])
        //                        ["total_count"]);
        //            posts.total += posts.wow.Value;
        //        }

        //        if (_dictionary.Keys.Contains("haha"))
        //        {
        //            posts.haha =
        //                Convert.ToInt32(
        //                    ((Dictionary<string, object>)((Dictionary<string, object>)_dictionary["haha"])["summary"])
        //                        ["total_count"]);
        //            posts.total += posts.haha.Value;
        //        }

        //        if (_dictionary.Keys.Contains("sad"))
        //        {
        //            posts.sad =
        //                Convert.ToInt32(
        //                    ((Dictionary<string, object>)((Dictionary<string, object>)_dictionary["sad"])["summary"])
        //                        ["total_count"]);
        //            posts.total += posts.sad.Value;
        //        }

        //        if (_dictionary.Keys.Contains("angry"))
        //        {
        //            posts.angry =
        //                Convert.ToInt32(
        //                    ((Dictionary<string, object>)((Dictionary<string, object>)_dictionary["angry"])["summary"])
        //                        ["total_count"]);
        //            posts.total += posts.angry.Value;
        //        }

        //        if (_dictionary.Keys.Contains("thankful"))
        //        {
        //            posts.thankful =
        //                Convert.ToInt32(
        //                    ((Dictionary<string, object>)
        //                        ((Dictionary<string, object>)_dictionary["thankful"])["summary"])
        //                        ["total_count"]);
        //            posts.total += posts.thankful.Value;
        //        }


        //        return posts;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        //public FacebookPagePosts PostImages(FacebookPagePosts posts, string result)
        //{
        //    try
        //    {
        //        _serializer = new JavaScriptSerializer();
        //        _dictionary = _serializer.Deserialize<Dictionary<string, object>>(result);

        //        if (_dictionary.Keys.Contains("picture"))
        //        {
        //            posts.source = (string) _dictionary["picture"];
        //        }

        //        //if (_dictionary.Keys.Contains("comments"))
        //        //{
        //        //    posts.comments =
        //        //        Convert.ToInt32(
        //        //            ((Dictionary<string, object>)
        //        //                ((Dictionary<string, object>) _dictionary["comments"])["summary"])
        //        //                ["total_count"]);
        //        //    posts.Total += posts.comments.Value;
        //        //}


        //        return posts;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public FacebookPagePosts Page_User_Info(string result)
        //{
        //    var posts = new FacebookPagePosts();
        //    _serializer = new JavaScriptSerializer();
        //    _dictionary = _serializer.Deserialize<Dictionary<string, object>>(result);

        //    if (_dictionary.Keys.Contains("id"))
        //    {
        //        posts.from_id = (string)_dictionary["id"];
        //    }
        //    if (_dictionary.Keys.Contains("name"))
        //    {
        //        posts.from_name = (string)_dictionary["name"];
        //    }

        //    return posts;
        //}

        //public FacebookPagePosts SinglePost(string result)
        //{
        //    var posts = new FacebookPagePosts();
        //    _serializer = new JavaScriptSerializer();
        //    _dictionary = _serializer.Deserialize<Dictionary<string, object>>(result);

        //    if (_dictionary.Keys.Contains("message"))
        //    {
        //        posts.message = (string)_dictionary["message"];
        //    }
        //    if (_dictionary.Keys.Contains("status_type"))
        //    {
        //        posts.status_type = (string)_dictionary["status_type"];
        //    }
        //    if (_dictionary.Keys.Contains("type"))
        //    {
        //        posts.type = (string)_dictionary["type"];
        //    }
        //    if (_dictionary.Keys.Contains("story"))
        //    {
        //        posts.story = (string)_dictionary["story"];
        //    }
        //    if (_dictionary.Keys.Contains("source"))
        //    {
        //        posts.source = (string)_dictionary["source"];
        //    }
        //    if (_dictionary.Keys.Contains("picture"))
        //    {
        //        posts.picture = (string)_dictionary["picture"];
        //    }
        //    if (_dictionary.Keys.Contains("object_id"))
        //    {
        //        posts.object_id = (string)_dictionary["object_id"];
        //    }
        //    if (_dictionary.Keys.Contains("link"))
        //    {
        //        posts.url = (string)_dictionary["link"];
        //        posts.link = (string)_dictionary["link"];
        //    }
        //    if (_dictionary.Keys.Contains("id"))
        //    {
        //        posts.postid = (string)_dictionary["id"];
        //    }
        //    if (_dictionary.Keys.Contains("created_time"))
        //    {
        //        posts.created_time = DateTime.Parse(_dictionary["created_time"].ToString());
        //    }
        //    if (_dictionary.Keys.Contains("name"))
        //    {
        //        posts.name = (string)_dictionary["name"];
        //    }
        //    if (_dictionary.Keys.Contains("description"))
        //    {
        //        posts.description = (string)_dictionary["description"];
        //    }
        //    if (_dictionary.Keys.Contains("caption"))
        //    {
        //        posts.caption = (string)_dictionary["caption"];
        //    }
        //    if (_dictionary.Keys.Contains("from"))
        //    {
        //        var fromdictionary = (Dictionary<string, object>)_dictionary["from"];

        //        if (fromdictionary.Keys.Contains("id"))
        //        {
        //            posts.from_id = (string)fromdictionary["id"];
        //        }
        //        if (fromdictionary.Keys.Contains("name"))
        //        {
        //            posts.from_name = (string)fromdictionary["name"];
        //        }
        //    }
        //    if (_dictionary.Keys.Contains("full_picture"))
        //    {
        //        posts.full_picture = (string)_dictionary["full_picture"];
        //    }

        //    return posts;
        //}

        public List<FacebookPagePosts> PagePost(string result)
        {
            try
            {
                var lstpost = new List<FacebookPagePosts>();
                _serializer = new JavaScriptSerializer();
                _dictionary = _serializer.Deserialize<Dictionary<string, object>>(result);
                var lstmodel = (ArrayList)_dictionary["data"];

                if (lstmodel.Count == 0)
                    return null;
                do
                {
                    if (lstmodel.Count == 0)
                    {
                        var nextpage = (Dictionary<string, object>)_dictionary["paging"];
                        var newresult = NextPage(nextpage["next"].ToString());
                        _dictionary = _serializer.Deserialize<Dictionary<string, object>>(newresult);
                        lstmodel = (ArrayList)_dictionary["data"];
                    }
                    if (lstmodel.Count > 0)
                    {
                        foreach (var item in lstmodel)
                        {
                            if (item is Dictionary<string, object>)
                            {
                                var a = (Dictionary<string, object>)item;
                                var data = new FacebookPagePosts();

                                if (a.Keys.Contains("id"))
                                    data.postid = a["id"].ToString();
                                if (a.Keys.Contains("source"))
                                    data.source = a["source"].ToString();
                                if (a.Keys.Contains("link"))
                                    data.link = a["link"].ToString();
                                if (a.Keys.Contains("id"))
                                    data.postid = a["id"].ToString();
                                if (a.Keys.Contains("message"))
                                    data.message = a["message"].ToString();
                                if (a.Keys.Contains("story"))
                                    data.story = a["story"].ToString();
                                if (a.Keys.Contains("created_time"))
                                    data.created_time = DateTime.Parse(a["created_time"].ToString());
                                if (a.Keys.Contains("type"))
                                    data.type = a["type"].ToString();
                                lstpost.Add(data);
                            }
                        }
                    }
                    lstmodel.Clear();
                    if (!_dictionary.Keys.Contains("paging"))
                    {
                        return lstpost;
                    }
                } while (((Dictionary<string, object>)_dictionary["paging"]).Keys.Contains("next"));
                return lstpost;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}