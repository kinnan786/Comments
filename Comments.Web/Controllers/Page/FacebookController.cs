using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Web.Mvc;
using System.Web.Security;
using Comments.Facebook;
using Comments.Facebook.Model;
using Comments.Web.DbContext;
using Comments.Web.Models;
using FacebookPost = Comments.Facebook.FacebookPost;

namespace Comments.Web.Controllers.Page
{
    public class FacebookController : Controller
    {
        // GET: Comments
        public ActionResult Index(string id)
        {
            try
            {
                Debugger.Launch();
                if (!string.IsNullOrEmpty(id))
                {
                    if (User.Identity.IsAuthenticated)
                    {
                        var facebookComments = new FacebookPost();

                        var userId =
                            Convert.ToInt64(((FormsIdentity)((GenericPrincipal)User).Identity).Ticket.UserData);


                        var postid = id; //"146505212039213_2464275336928844";

                        var userAccessTokenModel =
                            WebUow.Instance.RepoOf<FacebookAccessToken>().Get(q => q.userid == userId).SingleOrDefault();

                        //var acccessoken =
                        //    "EAACEdEose0cBAG7Mrj2NC0goUJk0x4dzcaxQHPZBzu8QLZACQAWyMABwy7wlAFg6c60NrX5wbFAkrVUAaxSruaD8L9nKTTLnVbk930SoQZCNadIyEd9JkDubJHLO5GvagSWkhfVtZAzPI72iJEt6w7SMxFXhVyQCDw4owBywCQZDZD";

                        var obj = facebookComments.GetFacebookPostReactions(postid, userAccessTokenModel.accesstoken);
                        FacebookReactions facebookreactions;

                        if (obj is FacebookReactions)
                        {
                            facebookreactions = (FacebookReactions)obj;
                        }
                        else
                        {
                            var facebookerror = (FacebookError)obj;

                            // Login status or access token has expired, been revoked, or is otherwise invalid. Handle expired access tokens.
                            // Access token has expired
                            // Error validating access token: The session is invalid because the user logged out.
                            if (facebookerror.error.code == "190" &&
                                facebookerror.error.error_subcode == "463")
                            {
                                ViewBag.Error = facebookerror.error.message;
                                FormsAuthentication.SignOut();
                                return RedirectToAction("Index", "Login");
                            }
                            // This post cannot be fetched it is private
                            else if (facebookerror.error.code == "100")
                            {
                                ViewBag.Error = "Due to facebook restriction we cannot Fetch comments of group, user and private facebook posts. Kindly make sure the post is public and not from the user or group.";
                            }
                            // (#803) Some of the aliases you requested do not exist: 1024337415_
                            // something is wrong with the request
                            else if (facebookerror.error.code == "803")
                            {
                                ViewBag.Error = facebookerror.error.message;
                            }

                            return View("Error");
                        }

                        var facebookcomment = facebookComments.GetAllCommentsAndReplies(postid,
                            userAccessTokenModel.accesstoken);


                        var model = new FacebookPostViewModel
                        {
                            General = new General
                            {
                                Angry = facebookreactions.angry.summary.total_count,
                                Haha = facebookreactions.haha.summary.total_count,
                                Like = facebookreactions.like.summary.total_count,
                                Love = facebookreactions.love.summary.total_count,
                                Sad = facebookreactions.sad.summary.total_count,
                                //MostActiveUsers = facebookreactions.angry.summary.total_count,
                                Shares = facebookreactions.shares == null ? 0 : facebookreactions.shares.count,
                                Wow = facebookreactions.wow.summary.total_count,
                                Comments = facebookreactions.comments.summary.total_count
                            }
                        };


                        if (facebookcomment != null && facebookcomment.Count > 0)
                        {
                            model.General.PeopleInConversation = TotalUniuePeopleinConversation(facebookcomment);
                            model.General.Replies = CountFacebookReplies(facebookcomment);
                            model.General.RepliesLikes = CountRepliesLikes(facebookcomment);
                            model.General.CommentsLikes = CountCommentLikes(facebookcomment);

                            var maxCommentDate = facebookcomment.OrderByDescending(q => q.created_time).FirstOrDefault();
                            model.ToDate = maxCommentDate != null ? maxCommentDate.created_time : DateTime.Now;

                            model.Wordcloud = CountWordCloud(facebookcomment);
                            model.WordCloudCount = 0;
                            foreach (var item in model.Wordcloud)
                            {
                                model.WordCloudCount += item.Value;
                            }

                            model.Chartmonth = GetDates(facebookcomment);
                            model.AttachmentViewModels = GetImages(facebookcomment);
                            CountFacebookReplies(facebookcomment);
                        }

                        model.CreatedTime = DateTime.Parse(facebookreactions.created_time).ToString("MMMM dd, yyyy");
                        model.FromDate = DateTime.Parse(facebookreactions.created_time);
                        model.Postid = postid;

                        Session["facebookcomment"] = facebookcomment;

                        return View(model);
                    }
                    return RedirectToAction("Index", "Login");
                }
                ViewBag.Error = "Wrong Facebook PostId";
                return View("Error");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Error");
            }
        }

        private List<AttachmentViewModel> GetImages(List<FacebookComment> lstFacebookComments)
        {
            try
            {
                var lstAttachments = new List<AttachmentViewModel>();
                foreach (var comment in lstFacebookComments)
                {
                    if (comment.attachment != null)
                    {
                        if (comment.attachment.media != null)
                        {
                            if (comment.attachment.media.image != null)
                            {
                                var attachment = new AttachmentViewModel
                                {
                                    Commentid = comment.id,
                                    Url = comment.attachment.media.image.src,
                                    LikeCount = comment.like_count,
                                    CreatedOn = comment.created_time,
                                    ReplyCount = comment.comment_count
                                };
                                lstAttachments.Add(attachment);
                            }
                        }
                    }

                    if (comment.comments != null)
                    {
                        if (comment.comments.data != null)
                        {
                            foreach (var replies in comment.comments.data)
                            {
                                if (replies.attachment != null)
                                {
                                    if (replies.attachment.media != null)
                                    {
                                        if (replies.attachment.media.image != null)
                                        {
                                            var attachment = new AttachmentViewModel
                                            {
                                                Commentid = comment.id,
                                                ReplyId = replies.id,
                                                Url = replies.attachment.media.image.src,
                                                CreatedOn = replies.created_time,
                                                LikeCount = replies.like_count
                                            };
                                            lstAttachments.Add(attachment);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                return lstAttachments.OrderByDescending(q => q.LikeCount).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private int TotalUniuePeopleinConversation(List<FacebookComment> lstFacebookComments)
        {
            try
            {
                var dick = new Dictionary<string, int>();

                foreach (var comments in lstFacebookComments)
                {
                    if (!dick.ContainsKey(comments.from.name))
                    {
                        dick.Add(comments.from.name, 1);
                    }
                    else
                    {
                        dick[comments.from.name] += 1;
                    }

                    if (comments.comments != null)
                    {
                        if (comments.comments.data != null)
                        {
                            foreach (var replies in comments.comments.data)
                            {
                                if (!dick.ContainsKey(replies.from.name))
                                {
                                    dick.Add(replies.from.name, 1);
                                }
                                else
                                {
                                    dick[replies.from.name] += 1;
                                }
                            }
                        }
                    }
                }
                return dick.Count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Dictionary<string, long> CountWordCloud(List<FacebookComment> lstFacebookComments)
        {
            try
            {
                Debugger.Launch();
                var wordCloudDic = new Dictionary<string, long>();
                foreach (var comments in lstFacebookComments)
                {
                    if (!string.IsNullOrEmpty(comments.message))
                    {
                        var coment =
                            comments.message.Replace(".", "")
                                .Replace(",", "")
                                .Replace("?", "")
                                .Replace("\'", "")
                                .Replace("\\", "")
                                .Replace("\n", "")
                                .Replace("\"", "")
                                .ToLower();
                        var aaa = coment.Split(' ');

                        foreach (var s in aaa)
                        {
                            if (!FacebookSettings.stopwords.Contains(s.ToLower()))
                            {
                                if (!wordCloudDic.ContainsKey(s))
                                {
                                    wordCloudDic.Add(s, 1);
                                }
                                else
                                {
                                    wordCloudDic[s] += 1;
                                }
                            }
                        }

                        if (comments.comments != null)
                        {
                            if (comments.comments.data != null)
                            {
                                foreach (var replies in comments.comments.data)
                                {
                                    var rep =
                                        replies.message
                                            .Replace(".", "")
                                            .Replace(",", "")
                                            .Replace("?", "")
                                            .Replace("\'", "")
                                            .Replace("\\", "")
                                            .Replace("\"", "")
                                            .Replace("\n", "")
                                            .Replace("\"", "")
                                            .ToLower();
                                    var bbb = rep.Split(' ');

                                    foreach (var s in bbb)
                                    {
                                        if (!FacebookSettings.stopwords.Contains(s.ToLower()))
                                        {
                                            if (!wordCloudDic.ContainsKey(s))
                                            {
                                                wordCloudDic.Add(s, 1);
                                            }
                                            else
                                            {
                                                wordCloudDic[s] += 1;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                //var temp = wordCloudDic;
                return wordCloudDic.OrderByDescending(q => q.Value).Take(50).ToDictionary(x => x.Key, x => x.Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Dictionary<DateTime, ChartMonth> GetDates(List<FacebookComment> lstFacebookComments)
        {
            try
            {
                var dick = new Dictionary<DateTime, ChartMonth>();

                foreach (var comments in lstFacebookComments)
                {
                    var commentdate = DateTime.Parse(comments.created_time.ToShortDateString());

                    if (!dick.ContainsKey(commentdate))
                    {
                        dick.Add(commentdate, new ChartMonth { Comments = 1, Replies = 0 });
                    }
                    else
                    {
                        var asd = dick[commentdate];
                        asd.Comments += 1;
                        asd.Replies = asd.Replies;
                        dick[commentdate] = asd;
                    }

                    if (comments.comments != null)
                    {
                        if (comments.comments.data != null)
                        {
                            foreach (var replies in comments.comments.data)
                            {
                                var repliesdate = DateTime.Parse(replies.created_time.ToShortDateString());
                                if (!dick.ContainsKey(repliesdate))
                                {
                                    dick.Add(repliesdate, new ChartMonth { Comments = 0, Replies = 1 });
                                }
                                else
                                {
                                    var asd = dick[repliesdate];
                                    asd.Replies += 1;
                                    asd.Comments = asd.Comments;
                                    dick[repliesdate] = asd;
                                }
                            }
                        }
                    }
                }

                return dick;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private int CountFacebookReplies(List<FacebookComment> lstFacebookComments)
        {
            var repliesCount = 0;

            foreach (var item in lstFacebookComments)
            {
                repliesCount += Convert.ToInt32(item.comment_count);
            }
            return repliesCount;
        }

        private int CountCommentLikes(List<FacebookComment> lstFacebookComments)
        {
            var repliesCount = 0;

            foreach (var comments in lstFacebookComments)
            {
                repliesCount += Convert.ToInt32(comments.comment_count);
            }
            return repliesCount;
        }

        private int CountRepliesLikes(List<FacebookComment> lstFacebookComments)
        {
            var repliesCount = 0;

            foreach (var comments in lstFacebookComments)
            {
                if (comments.comments != null)
                {
                    if (comments.comments.data != null)
                    {
                        foreach (var replies in comments.comments.data)
                        {
                            repliesCount += Convert.ToInt32(replies.like_count);
                        }
                    }
                }
            }
            return repliesCount;
        }
    }
}